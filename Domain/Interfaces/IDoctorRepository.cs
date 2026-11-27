using Domain.Models;
using Domain.Filters;

namespace Domain.Interfaces;

public interface IDoctorRepository
{
    Task<bool> AddDoctorAsync(Doctor doctor);
    Task<bool> UpdateDoctorAsync(Doctor doctor);
    Task<bool> DeactivateDoctorAsync(int id);
    Task<Doctor?> GetDoctorAsync(int id);
    Task<List<Doctor>> GetDoctorsAsync(DoctorFilter filter);
}
