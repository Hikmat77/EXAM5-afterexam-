using Application.Interfaces;
using Application.Responces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("doctors")]
public class DoctorController(IDoctorService doctorService) : ControllerBase
{
    private IDoctorService service = doctorService;

    [HttpGet]
    public async Task<ApiResronce<bool>> AddDoctor(Doctor doctor)
    {
        return await service.AddDoctorAsync(doctor);
    }

    [HttpPut]
    public async Task<ApiResronce<bool>> UpdateDoctor(Doctor doctor)
    {
        return await service.UpdateDoctorAsync(doctor);
    }

    [HttpDelete]
    public async Task<ApiResronce<bool>> DeleteDotor(int id)
    {
        return await service.DeleteDoctorAsync(id);
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResronce<Doctor?>> GetDoctor(int id)
    {
        return await service.GetDoctorAsync(id);
    }

    [HttpGet]
    public async Task<ApiResronce<List<Doctor>>> GetDoctors()
    {
        return await service.GetDoctorsAsync();
    }
}