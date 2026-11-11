using Application.DTOs;
using Application.Responces;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResponse<bool>> AddPatientAsync(CreatePatientDto dto);
    Task<ApiResponse<bool>> UpdatePatientAsync(int id, UpdatePatientDto dto);
    Task<ApiResponse<bool>> DeactivatePatientAsync(int id);
    Task<ApiResponse<PatientDto>> GetPatientAsync(int id);
    Task<ApiResponse<List<PatientDto>>> GetPatientsAsync();
}
