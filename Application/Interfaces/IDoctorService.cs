using Application.DTOs;
using Application.Responces;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<ApiResponse<bool>> AddDoctorAsync(CreateDoctorDto dto);
    Task<ApiResponse<bool>> UpdateDoctorAsync(int id, UpdateDoctorDto dto);
    Task<ApiResponse<bool>> DeactivateDoctorAsync(int id);
    Task<ApiResponse<DoctorDto>> GetDoctorAsync(int id);
    Task<ApiResponse<List<DoctorDto>>> GetDoctorsAsync();
}
