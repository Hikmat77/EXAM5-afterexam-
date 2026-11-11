using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("patients")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    private IPatientService service = patientService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPatient(CreatePatientDto dto)
    {
        return await service.AddPatientAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdatePatient(int id, UpdatePatientDto dto)
    {
        return await service.UpdatePatientAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivatePatient(int id)
    {
        return await service.DeactivatePatientAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<PatientDto>> GetPatient(int id)
    {
        return await service.GetPatientAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<PatientDto>>> GetPatients()
    {
        return await service.GetPatientsAsync();
    }
}
