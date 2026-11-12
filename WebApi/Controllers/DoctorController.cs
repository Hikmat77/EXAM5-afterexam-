using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorController(
    IDoctorService doctorService,
    ILogger<DoctorController> logger) : ControllerBase
{
    private IDoctorService service = doctorService;
    private ILogger<DoctorController> _logger = logger;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDoctor(CreateDoctorDto dto)
    {
        _logger.LogInformation("POST doctors {date}", DateTime.Now);
        return await service.AddDoctorAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateDoctor(int id, UpdateDoctorDto dto)
    {
        _logger.LogInformation("PUT doctors/{id} {date}", id, DateTime.Now);
        return await service.UpdateDoctorAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateDoctor(int id)
    {
        _logger.LogInformation("PATCH doctors/{id}/deactivate {date}", id, DateTime.Now);
        return await service.DeactivateDoctorAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<DoctorDto>> GetDoctor(int id)
    {
        _logger.LogInformation("GET doctors/{id} {date}", id, DateTime.Now);
        return await service.GetDoctorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<DoctorDto>>> GetDoctors()
    {
        _logger.LogInformation("GET doctors {date}", DateTime.Now);
        return await service.GetDoctorsAsync();
    }
}
