using System.Net;
using Application.Interfaces;
using Application.Responces;
using Domain.Interfaces;
using Domain.Models;

namespace Application.Services;

public class PatientService(IPatientRepository patientRepository) : IPatientService
{
    private IPatientRepository repository = patientRepository;
    public async Task<ApiResronce<bool>> AddPatientAsync(Patient patient)
    {
        var res = await repository.AddPatientAsync(patient);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Added!", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Added!", res);
    }

    public async Task<ApiResronce<bool>> DeletePatientAsync(int id)
    {
        var res = await repository.DeletePatientAsync(id);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Deleted!", res)
        : new ApiResronce<bool>(HttpStatusCode.OK, "Not Deleted!", res);
    }

    public async Task<ApiResronce<Patient>> GetPatientAsync(int id)
    {
        var res = await repository.GetPatientAsync(id);
        return res == null
        ? new ApiResronce<Patient>(HttpStatusCode.OK, "Patient not found!", res)
        : new ApiResronce<Patient>(HttpStatusCode.InternalServerError, "Patient with given id", res);
    }

    public async Task<ApiResronce<List<Patient>>> GetPatientsAsync()
    {
        var res = await repository.GetPatientsAsync();
        return new ApiResronce<List<Patient>>(HttpStatusCode.OK, "List of Patients", res);
    }

    public async Task<ApiResronce<bool>> UpdatePatientAsync(Patient patient)
    {
        var res = await repository.UpdatePatientAsync(patient);
        return res == true
        ? new ApiResronce<bool>(HttpStatusCode.OK, "Updated!", res)
        : new ApiResronce<bool>(HttpStatusCode.InternalServerError, "Not Updates!", res);
    }

}