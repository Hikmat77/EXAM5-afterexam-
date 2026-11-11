using Domain.Models;

namespace Domain.Interfaces;

public interface IPatientRepository
{
    Task<bool> AddPatientAsync(Patient patient);
    Task<bool> UpdatePatientAsync(Patient patient);
    Task<bool> DeactivatePatientAsync(int id);
    Task<Patient?> GetPatientAsync(int id);
    Task<List<Patient>> GetPatientsAsync();
}
