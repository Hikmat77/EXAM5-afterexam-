using System.Net;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class DoctorService(IDoctorRepository doctorRepository) : IDoctorService
{
    private IDoctorRepository repository = doctorRepository;
    public async Task<ApiResronce<bool>> AddDoctorAsync(Doctor doctor)
    {
        var res = await repository.AddDoctorAsync(doctor);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResronce<bool>> DeleteDoctorAsync(int id)
    {
        var res = await repository.DeleteDoctorAsync(id);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Deleted!", res);
    }

    public async Task<ApiResronce<Doctor?>> GetDoctorAsync(int id)
    {
        var res = await repository.GetDoctorAsync(id);
        return res == null
        ? new ApiResronce<Doctor?>(HttpStatusCode.OK, "Doctor Not Found!", res)
        : new ApiResronce<Doctor?>(HttpStatusCode.InternalServerError, "Doctor with given id", res);
    }

    public async Task<ApiResronce<List<Doctor>>> GetDoctorsAsync()
    {
        var res = await repository.GetDoctorsAsync();
        return new ApiResronce<List<Doctor>>(HttpStatusCode.OK, "List of Doctors", res);
    }

    public async Task<ApiResronce<bool>> UpdateDoctorAsync(Doctor doctor)
    {
        var res = await repository.UpdateDoctorAsync(doctor);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Updated", res);
    }

}