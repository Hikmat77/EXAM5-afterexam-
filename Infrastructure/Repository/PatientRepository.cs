using Dapper;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;

namespace Infrastructure.Repositories;

public class PatientRepository(AppDbContext appDbContext) : IPatientRepository
{
    private AppDbContext _context = appDbContext;
    public async Task<bool> AddPatientAsync(Patient patient)
    {
        using var connection = _context.Connection();
        var query = "insert into patients (fullname, phone, birthdate, isactive) values (@fullname, @phone, @birthdate, @isactive)";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }

    public async Task<bool> DeactivatePatientAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "update patients set isactive = false where id = @id";
        var res = await connection.ExecuteAsync(query, new { id });
        return res > 0;
    }

    public async Task<Patient?> GetPatientAsync(int id)
    {
        using var connection = _context.Connection();
        var query = "select * from patients where id = @id";
        var patient = await connection.QuerySingleOrDefaultAsync<Patient>(query, new { id });
        return patient;
    }

    public async Task<List<Patient>> GetPatientsAsync()
    {
        using var connection = _context.Connection();
        var query = "select * from patients order by id";
        return (await connection.QueryAsync<Patient>(query)).ToList();
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        using var connection = _context.Connection();
        var query = "update patients set fullname = @fullname, phone = @phone, birthdate = @birthdate, isactive = @isactive where id = @id";
        var res = await connection.ExecuteAsync(query, patient);
        return res > 0;
    }
}
