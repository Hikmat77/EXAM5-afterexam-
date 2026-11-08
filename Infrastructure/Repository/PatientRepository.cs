using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repository;

public class PatientRepository(AppDbContext appDbContext) : IPatientRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddPatientAsync(Patient patient)
    {
        using var connection = _context.Connection();
        var query = "insert into patients (fullname, phone, birthdate, isactive, createat) values (@fullname, @phone, @birthdate, @isactive, @createat)";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }

    public async Task<bool> DeletePatientAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "delete from patients where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Patient?> GetPatientAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from patients where id = @id";
        return await connection.QuerySingleOrDefaultAsync<Patient>(query, new { id });
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        using var connection = _context.Connection();
        var query = " select * from patients order by id";
        var res = await connection.QueryAsync<Patient>(query);
        return res.ToList();
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        using var connection = _context.Connection();
        var query = "update patients set fullname = @fullname, phone = @phone, birthdate = @birthdate, isactive = @isactive, createat = @createat where id = @id";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }
}