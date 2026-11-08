using Domain.Models;

namespace Domain.Interfaces;

public interface IDoctorRepository
{
    Task<bool> AddDoctorAsync(Doctor doctor);
    Task<bool> UpdateDoctorAsync(Doctor doctor);
    Task<bool> DeleteDoctorAsync(int id);
    Task<Doctor?> GetDoctorAsync(int id);
    Task<List<Doctor>> GetDoctorsAsync(); 
}