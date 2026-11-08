using Application.Interfaces;
using Application.Responces;
using Domain.Models;
using Microsoft.AspNetCore.Mvc;


namespace WebApi.Controllers;

[ApiController]
[Route("patients")]
public class PatientController(IPatientService patientService) : ControllerBase
{
    private IPatientService service = patientService;

    [HttpPost]
    public async Task<ApiResronce<bool>> AddPatient(Patient patient)
    {
        return await service.AddPatientAsync(patient);
    }

    [HttpDelete]
    public async Task<ApiResronce<bool>> DeletePatient(int id)
    {
        return await service.DeletePatientAsync(id);
    }

    [HttpGet]
    public async Task<ApiResronce<List<Patient>>> GetPatients()
    {
        return await service.GetPatientsAsync();
    }

    [HttpGet("{id:int}")]
    public async Task<ApiResronce<Patient>> GetPatient(int id)
    {
        return await service.GetPatientAsync(id);
    }

    [HttpPut]
    public async Task<ApiResronce<bool>> UpdatePatient(Patient patient)
    {
        return await service.UpdatePatientAsync(patient);
    }
}