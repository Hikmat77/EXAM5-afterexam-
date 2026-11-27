using Application.DTOs;
using Application.Responces;
using Domain.Filters;

namespace Application.Interfaces;

public interface IDoctorService
{
    Task<PagedResponse<bool>> AddDoctorAsync(CreateDoctorDto dto);
    Task<PagedResponse<bool>> UpdateDoctorAsync(int id, UpdateDoctorDto dto);
    Task<PagedResponse<bool>> DeactivateDoctorAsync(int id);
    Task<PagedResponse<DoctorDto>> GetDoctorAsync(int id);
    Task<PagedResponse<List<DoctorDto>>> GetDoctorsAsync(DoctorFilter filter);
}
