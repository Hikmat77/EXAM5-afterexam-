using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository repository = patientRepository;
    public async Task<ApiResponse<bool>> AddPatientAsync(CreatePatientDto dto)
    {
        var patient = new Patient()
        {
            Fullname = dto.Fullname,
            Phone = dto.Phone,
            BirthDate = (DateTime)dto.BirthDate
        };
        var res = await repository.AddPatientAsync(patient);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeactivatePatientAsync(int id)
    {
        var res = await repository.DeactivatePatientAsync(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }

    public async Task<ApiResponse<PatientDto>> GetPatientAsync(int id)
    {
        var patient = await repository.GetPatientAsync(id);
        var res = patient==null ? null : new PatientDto()
        {
            Id = patient.Id,
            Fullname = patient.Fullname,
            Phone = patient.Phone,
            BirthDate = patient.BirthDate,
            IsActive = patient.IsActive,
            CreatedAt = patient.CreateAt
        };
        return res!=null
        ? new ApiResponse<PatientDto>(HttpStatusCode.OK, "Patient with given id.", res)
        : new ApiResponse<PatientDto>(HttpStatusCode.NotFound, "No patient with given id.", res!);
    }

    public async Task<ApiResponse<List<PatientDto>>> GetPatientsAsync()
    {
        var patients = await repository.GetPatientsAsync();
        var res = patients.Select(x=>new PatientDto()
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Phone = x.Phone,
            BirthDate = x.BirthDate,
            IsActive = x.IsActive,
            CreatedAt = x.CreateAt
        }).ToList();
        return new ApiResponse<List<PatientDto>>(HttpStatusCode.OK, "List of patients.", res);
    }

    public async Task<ApiResponse<bool>> UpdatePatientAsync(int id, UpdatePatientDto dto)
    {
        var patient = new Patient()
        {
            Id = id,
            Fullname = dto.Fullname,
            Phone = dto.Phone,
            BirthDate = (DateTime)dto.BirthDate,
            IsActive = dto.IsActive
        };
        var res = await repository.UpdatePatientAsync(patient);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
