using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class DoctorRepository(AppDbContext appDbContext) : IDoctorRepository
{
    private readonly AppDbContext _context = appDbContext;

    public async Task<bool> AddDoctorAsync(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeactivateDoctorAsync(int id)
    {
        var doctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == id);
        if (doctor is null)
        {
            return false;
        }

        if (!doctor.IsActive)
        {
            return true;
        }

        doctor.IsActive = false;
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Doctor?> GetDoctorAsync(int id)
    {
        return await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<List<Doctor>> GetDoctorsAsync()
    {
        return await _context.Doctors.AsNoTracking().OrderBy(x => x.Id).ToListAsync();
    }

    public async Task<bool> UpdateDoctorAsync(Doctor doctor)
    {
        var existingDoctor = await _context.Doctors.FirstOrDefaultAsync(x => x.Id == doctor.Id);
        if (existingDoctor is null)
        {
            return false;
        }

        if (existingDoctor.Fullname == doctor.Fullname
            && existingDoctor.Specialty == doctor.Specialty
            && existingDoctor.IsActive == doctor.IsActive
            && existingDoctor.HireDat == doctor.HireDat)
        {
            return true;
        }

        existingDoctor.Fullname = doctor.Fullname;
        existingDoctor.Specialty = doctor.Specialty;
        existingDoctor.IsActive = doctor.IsActive;
        existingDoctor.HireDat = doctor.HireDat;
        return await _context.SaveChangesAsync() > 0;
    }
}
