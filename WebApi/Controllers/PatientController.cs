using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("patients")]
public class PatientController(
    IPatientService patientService,
    ILogger<PatientController> logger) : ControllerBase
{
    private IPatientService service = patientService;
    private ILogger<PatientController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddPatient(CreatePatientDto dto)
    {
        _logger.LogInformation("POST patients {date}", DateTime.Now);
        return await service.AddPatientAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdatePatient(int id, UpdatePatientDto dto)
    {
        _logger.LogInformation("PUT patients/{id} {date}", id, DateTime.Now);
        return await service.UpdatePatientAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivatePatient(int id)
    {
        _logger.LogInformation("PATCH patients/{id}/deactivate {date}", id, DateTime.Now);
        return await service.DeactivatePatientAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<PatientDto>> GetPatient(int id)
    {
        _logger.LogInformation("GET patients/{id} {date}", id, DateTime.Now);
        return await service.GetPatientAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<PatientDto>>> GetPatients()
    {
        _logger.LogInformation("GET patients {date}", DateTime.Now);
        return await service.GetPatientsAsync();
    }
}
