using Domain.Interfaces;
using Domain.Models;
using Domain.Filters;
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

    public async Task<PagedResult<Room>> GetRoomsAsync(RoomFilter filter)
    {
        var query = _context.Rooms.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Name))
        {
            var name = filter.Name.Trim();
            query = query.Where(x => x.Name.Contains(name));
        }

        if (filter.IsActive.HasValue)
        {
            query = query.Where(x => x.IsActive == filter.IsActive.Value);
        }

        var totalCount = await query.CountAsync();
        var skip = (int)Math.Min((long)(filter.PageNumber - 1) * filter.PageSize, int.MaxValue);
        var items = await query
            .OrderBy(x => x.Id)
            .Skip(skip)
            .Take(filter.PageSize)
            .ToListAsync();

        return new PagedResult<Room>(items, totalCount, filter.PageNumber, filter.PageSize);
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
