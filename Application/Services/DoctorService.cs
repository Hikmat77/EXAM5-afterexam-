using System.Net;
using Application.DTOs;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;
using Domain.Filters;

namespace Application.Services;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    private IDoctorRepository repository = doctorRepository;
    public async Task<ApiResponse<bool>> AddDoctorAsync(CreateDoctorDto dto)
    {
        var doctor = new Doctor()
        {
            Fullname = dto.Fullname,
            Specialty = dto.Specialty,
            HireDat = dto.HireDat,
            RoomId = dto.RoomId
        };
        var res = await repository.AddDoctorAsync(doctor);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not added.", res);
    }

    public async Task<ApiResponse<bool>> DeactivateDoctorAsync(int id)
    {
        var res = await repository.DeactivateDoctorAsync(id);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Deactivated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not deactivated.", res);
    }

    public async Task<ApiResponse<DoctorDto>> GetDoctorAsync(int id)
    {
        var doctor = await repository.GetDoctorAsync(id);
        var res = doctor==null ? null : new DoctorDto()
        {
            Id = doctor.Id,
            Fullname = doctor.Fullname,
            Specialty = doctor.Specialty,
            IsActive = doctor.IsActive,
            HireDat = doctor.HireDat,
            RoomId = doctor.RoomId,
            Room = doctor.Room is null ? null : new RoomDto()
            {
                Id = doctor.Room.Id,
                Name = doctor.Room.Name,
                IsActive = doctor.Room.IsActive
            }
        };
        return res!=null
        ? new ApiResponse<DoctorDto>(HttpStatusCode.OK, "Doctor with given id.", res)
        : new ApiResponse<DoctorDto>(HttpStatusCode.NotFound, "No doctor with given id.", res!);
    }

    public async Task<ApiResponse<List<DoctorDto>>> GetDoctorsAsync(DoctorFilter filter)
    {
        var doctors = await repository.GetDoctorsAsync(filter);
        var res = doctors.Select(x=>new DoctorDto()
        {
            Id = x.Id,
            Fullname = x.Fullname,
            Specialty = x.Specialty,
            IsActive = x.IsActive,
            HireDat = x.HireDat,
            RoomId = x.RoomId,
            Room = x.Room is null ? null : new RoomDto()
            {
                Id = x.Room.Id,
                Name = x.Room.Name,
                IsActive = x.Room.IsActive
            }
        }).ToList();
        return new ApiResponse<List<DoctorDto>>(HttpStatusCode.OK, "List of doctors.", res);
    }

    public async Task<ApiResponse<bool>> UpdateDoctorAsync(int id, UpdateDoctorDto dto)
    {
        var doctor = new Doctor()
        {
            Id = id,
            Fullname = dto.Fullname,
            Specialty = dto.Specialty,
            IsActive = dto.IsActive,
            HireDat = dto.HireDat,
            RoomId = dto.RoomId
        };
        var res = await repository.UpdateDoctorAsync(doctor);
        return res==true
        ? new ApiResponse<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResponse<bool>(HttpStatusCode.InternalServerError, "Not updated.", res);
    }
}