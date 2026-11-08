using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

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

    public async Task<bool> DeleteRoomAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "delete from rooms where id = @id";
        var res  = await connection.ExecuteAsync(query, new {id});
        return res > 0;
    }

    public async Task<bool> UpdateRoomAsync(Room room)
    {
        using var connection = _context.Connection();
        var query = "update rooms set name = @name, isactive = isactive where id = @id";
        var res = await connection.ExecuteAsync(query, room);
        return res > 0;
    }
}