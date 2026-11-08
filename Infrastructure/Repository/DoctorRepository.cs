using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class DoctorRepository(AppDbContext appDbContext) : IDoctorRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddDoctorAsync(Doctor doctor)
    {
        using var connection = _context.Connection();
        var query = "insert into doctor (fullname, specialty, isactive, hiredat) values (@fullname, @specialty, @isactive, @hiredat)";
        var res = await connection.ExecuteAsync(query, doctor);
        return res > 0;
    }

    public async Task<bool> DeleteDoctorAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "delete from doctors where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Doctor?> GetDoctorAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from doctors where id = @id";
        return await connection.QuerySingleOrDefaultAsync<Doctor>(query, new { id });
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from doctor order by id";
        var res = await connection.QueryAsync<Doctor>(query);
        return res.ToList();
    }

    public async Task<bool> UpdateDoctorAsync(Doctor doctor)
    {
        using var connection = _context.Connection();
        var query = "update doctors set fullname = @fullname, specialty = @specialty, isactive = @isactive, hiredat = hiredat where id = @id";
        var res = await connection.ExecuteAsync(query, doctor);
        return res > 0;
    }
}