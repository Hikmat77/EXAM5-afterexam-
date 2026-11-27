using Domain.Interfaces;
using Domain.Models;
using Domain.Filters;
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
        return await _context.Doctors
            .AsNoTracking()
            .Include(x => x.Room)
            .FirstOrDefaultAsync(x => x.Id == id);
    }

    public async Task<PagedResult<Doctor>> GetDoctorsAsync(DoctorFilter filter)
    {
        var query = _context.Doctors
            .AsNoTracking()
            .Include(x => x.Room)
            .AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Fullname))
        {
            var fullname = filter.Fullname.Trim();
            query = query.Where(x => x.Fullname.Contains(fullname));
        }

        if (!string.IsNullOrWhiteSpace(filter.Specialty))
        {
            var specialty = filter.Specialty.Trim();
            query = query.Where(x => x.Specialty.Contains(specialty));
        }

        if (filter.RoomId.HasValue)
        {
            query = query.Where(x => x.RoomId == filter.RoomId.Value);
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

        return new PagedResult<Doctor>(items, totalCount, filter.PageNumber, filter.PageSize);
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
            && existingDoctor.HireDat == doctor.HireDat
            && existingDoctor.RoomId == doctor.RoomId)
        {
            return true;
        }

        existingDoctor.Fullname = doctor.Fullname;
        existingDoctor.Specialty = doctor.Specialty;
        existingDoctor.IsActive = doctor.IsActive;
        existingDoctor.HireDat = doctor.HireDat;
        existingDoctor.RoomId = doctor.RoomId;
        return await _context.SaveChangesAsync() > 0;
    }
}
