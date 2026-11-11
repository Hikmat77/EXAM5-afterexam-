using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorController(IDoctorService doctorService) : ControllerBase
{
    private IDoctorService service = doctorService;

    [HttpPost]
    public async Task<ApiResponse<bool>> AddDoctor(CreateDoctorDto dto)
    {
        return await service.AddDoctorAsync(dto);
    }

    [HttpPut("{id:int}")]
    public async Task<ApiResponse<bool>> UpdateDoctor(int id, UpdateDoctorDto dto)
    {
        return await service.UpdateDoctorAsync(id, dto);
    }

    [HttpPatch("{id:int}/deactivate")]
    public async Task<ApiResponse<bool>> DeactivateDoctor(int id)
    {
        return await service.DeactivateDoctorAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResponse<DoctorDto>> GetDoctor(int id)
    {
        return await service.GetDoctorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResponse<List<DoctorDto>>> GetDoctors()
    {
        return await service.GetDoctorsAsync();
    }
}
