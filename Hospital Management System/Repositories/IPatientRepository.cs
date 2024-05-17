using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repositories
{
    public interface IPatientRepository
    {

        Task<List<Patient>> GetAllAsync();

        Task<Patient> GetById(Guid Id);

        Task<Patient> CreateAsync(Patient patient);

        Task<Patient> UpdateAsync(Guid id, Patient patient);

        Task<Patient> DeleteAsync(Guid id);


    }
}
