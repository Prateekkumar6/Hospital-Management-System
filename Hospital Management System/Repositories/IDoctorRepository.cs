using Hospital_Management_System.Models.DomainModels;
using Microsoft.AspNetCore.Mvc;

namespace Hospital_Management_System.Repositories
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>>GetAllAsync();

        Task<Doctor> GetById(String Id);

        Task<Doctor> CreateAsync(Doctor doctor);

        Task<Doctor> UpdateAsync( string id,Doctor doctor); 

        Task<Doctor> DeleteAsync(string id);

    }
}
