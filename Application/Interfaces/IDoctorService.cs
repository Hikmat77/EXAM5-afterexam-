using Application.Responces;
using Domain.Models;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResronce<bool>> AddDoctorAsync(Doctor doctor);
    Task<ApiResronce<bool>> UpdateDoctorAsync(Doctor doctor);
    Task<ApiResronce<bool>> DeleteDoctorAsync(int id);
    Task<ApiResronce<Doctor?>> GetDoctorAsync(int id);
    Task<ApiResronce<List<Doctor>>> GetDoctorsAsync();
}