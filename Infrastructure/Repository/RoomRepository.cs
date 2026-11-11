using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class RoomRepository(AppDbContext appDbContext) : IRoomRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddRoomAsync(Room room)
    {
        using var connection = _context.Connection();
        var query = "insert into rooms (name, isactive) values (@name, @isactive)";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }

    public async Task<bool> DeactivateRoomAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "update rooms set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<List<Room>> GetRoomsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from rooms order by id";
        return (await connection.QueryAsync<Room>(query)).ToList();
    }

    public async Task<bool> UpdateRoomAsync(Room room)
    {
        using var connection = _context.Connection();
        var query = "update rooms set name = @name, isactive = @isactive where id = @id";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }
}
