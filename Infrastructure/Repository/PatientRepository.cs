using Domain.Interfaces;
using Domain.Models;
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

    public async Task<List<Patient>> GetPatientsAsync()
    {
        return await _context.Patients.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
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
