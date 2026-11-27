using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Filters;
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
    public async Task<PagedResponse<bool>> AddPatient(CreatePatientDto dto)
    {
        _logger.LogInformation("POST patients {date}", DateTime.Now);
        return await service.AddPatientAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<PagedResponse<bool>> UpdatePatient(int id, UpdatePatientDto dto)
    {
        _logger.LogInformation("PUT patients/{id} {date}", id, DateTime.Now);
        return await service.UpdatePatientAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<PagedResponse<bool>> DeactivatePatient(int id)
    {
        _logger.LogInformation("PATCH patients/{id}/deactivate {date}", id, DateTime.Now);
        return await service.DeactivatePatientAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<PagedResponse<PatientDto>> GetPatient(int id)
    {
        _logger.LogInformation("GET patients/{id} {date}", id, DateTime.Now);
        return await service.GetPatientAsync(id);
    }

    [HttpGet]
    public async Task<PagedResponse<List<PatientDto>>> GetPatients([FromQuery] PatientFilter filter)
    {
        _logger.LogInformation("GET patients {date}", DateTime.Now);
        return await service.GetPatientsAsync(filter);
    }
}
