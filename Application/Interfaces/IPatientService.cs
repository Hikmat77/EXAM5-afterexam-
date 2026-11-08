using Application.Responces;
using Domain.Models;

namespace Application.Interfaces;

public interface IPatientService
{
    Task<ApiResronce<bool>> AddPatientAsync(Patient patient);
    Task<ApiResronce<bool>> UpdatePatientAsync(Patient patient);
    Task<ApiResronce<bool>> DeletePatientAsync(int id);
    Task<ApiResronce<Patient>> GetPatientAsync(int id);
    Task<ApiResronce<List<Patient>>> GetPatientsAsync();
}