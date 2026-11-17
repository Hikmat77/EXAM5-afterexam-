using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class RoomRepository(AppDbContext appDbContext) : IRoomRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddRoomAsync(Room room)
    {
        _context.Rooms.Add(room);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeactivateRoomAsync(int id)
    {
        var room = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == id);
        if (room is null)
        {
            return false;
        }

        if (!room.IsActive)
        {
            return true;
        }

        room.IsActive = false;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<List<Room>> GetRoomsAsync()
    {
        return await _context.Rooms.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<bool> UpdateRoomAsync(Room room)
    {
        var existingRoom = await _context.Rooms.FirstOrDefaultAsync(x => x.Id == room.Id);
        if (existingRoom is null)
        {
            return false;
        }

        if (existingRoom.Name == room.Name && existingRoom.IsActive == room.IsActive)
        {
            return true;
        }

        existingRoom.Name = room.Name;
        existingRoom.IsActive = room.IsActive;
        return await _context.SaveChangesAsync() > 0;
    }
}
