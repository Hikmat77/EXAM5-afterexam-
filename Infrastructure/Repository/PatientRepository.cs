using Domain.Interfaces;
using Domain.Models;
using Domain.Filters;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class PatientRepository(AppDbContext appDbContext) : IPatientRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddPatientAsync(Patient patient)
    {
        _context.Patients.Add(patient);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeactivatePatientAsync(int id)
    {
        var patient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == id);
        if (patient is null)
        {
            return false;
        }

        if (!patient.IsActive)
        {
            return true;
        }

        patient.IsActive = false;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Patient?> GetPatientAsync(int id)
    {
        return await _context.Patients.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResult<Patient>> GetPatientsAsync(PatientFilter filter)
    {
        var query = _context.Patients.AsNoTracking().AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Fullname))
        {
            var fullname = filter.Fullname.Trim();
            query = query.Where(x => x.Fullname.Contains(fullname));
        }

        if (!string.IsNullOrWhiteSpace(filter.Phone))
        {
            var phone = filter.Phone.Trim();
            query = query.Where(x => x.Phone.Contains(phone));
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

        return new PagedResult<Patient>(items, totalCount, filter.PageNumber, filter.PageSize);
    }

    public async Task<bool> UpdatePatientAsync(Patient patient)
    {
        var existingPatient = await _context.Patients.FirstOrDefaultAsync(x => x.Id == patient.Id);
        if (existingPatient is null)
        {
            return false;
        }

        if (existingPatient.Fullname == patient.Fullname
            && existingPatient.Phone == patient.Phone
            && existingPatient.BirthDate == patient.BirthDate
            && existingPatient.IsActive == patient.IsActive)
        {
            return true;
        }

        existingPatient.Fullname = patient.Fullname;
        existingPatient.Phone = patient.Phone;
        existingPatient.BirthDate = patient.BirthDate;
        existingPatient.IsActive = patient.IsActive;
        return await _context.SaveChangesAsync() > 0;
    }
}
