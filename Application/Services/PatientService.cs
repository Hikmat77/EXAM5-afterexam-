using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;
using Domain.Filters;

namespace Application.Services;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository repository = patientRepository;
    public async Task<PagedResponse<bool>> AddPatientAsync(CreatePatientDto dto)
    {
        var patient = new Patient()
        {
            Fullname = dto.Fullname,
            Phone = dto.Phone,
            BirthDate = (DateTime)dto.BirthDate
        };
        var res = await repository.AddPatientAsync(patient);
        return res==true
        ? new PagedResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new PagedResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<PagedResponse<bool>> DeactivatePatientAsync(int id)
    {
        var res = await repository.DeactivatePatientAsync(id);
        return res==true
        ? new PagedResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new PagedResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }

    public async Task<PagedResponse<PatientDto>> GetPatientAsync(int id)
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
        ? new PagedResponse<PatientDto>(HttpStatusCode.OK, "Patient with given id.", res)
        : new PagedResponse<PatientDto>(HttpStatusCode.NotFound, "No patient with given id.");
    }

    public async Task<PagedResponse<List<PatientDto>>> GetPatientsAsync(PatientFilter filter)
    {
        var patients = await repository.GetPatientsAsync(filter);
        var items = patients.Items.Select(x=>new PatientDto()
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Phone = x.Phone,
            BirthDate = x.BirthDate,
            IsActive = x.IsActive,
            CreatedAt = x.CreateAt
        }).ToList();
        return new PagedResponse<List<PatientDto>>(
            items,
            patients.TotalCount,
            patients.PageNumber,
            patients.PageSize,
            "List of patients.");
    }

    public async Task<PagedResponse<bool>> UpdatePatientAsync(int id, UpdatePatientDto dto)
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
        ? new PagedResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new PagedResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}
