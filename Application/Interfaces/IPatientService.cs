using Application.DTOs;
using Application.Responces;
using Domain.Filters;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResponse<bool>> AddPatientAsync(CreatePatientDto dto);
    Task<ApiResponse<bool>> UpdatePatientAsync(int id, UpdatePatientDto dto);
    Task<ApiResponse<bool>> DeactivatePatientAsync(int id);
    Task<ApiResponse<PatientDto>> GetPatientAsync(int id);
    Task<ApiResponse<List<PatientDto>>> GetPatientsAsync(PatientFilter filter);
}
