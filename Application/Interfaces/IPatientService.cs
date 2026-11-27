using Application.DTOs;
using Application.Responces;
using Domain.Filters;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<PagedResponse<bool>> AddPatientAsync(CreatePatientDto dto);
    Task<PagedResponse<bool>> UpdatePatientAsync(int id, UpdatePatientDto dto);
    Task<PagedResponse<bool>> DeactivatePatientAsync(int id);
    Task<PagedResponse<PatientDto>> GetPatientAsync(int id);
    Task<PagedResponse<List<PatientDto>>> GetPatientsAsync(PatientFilter filter);
}
