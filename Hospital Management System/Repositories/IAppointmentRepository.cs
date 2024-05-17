using Hospital_Management_System.Models;

namespace Hospital_Management_System.Repositories
{
    public interface IAppointmentRepository
    {
         
        Task<List<Appointment>> GetAllListAsync();

        Task<Appointment>GetListById(Guid Id);

        Task<Appointment> CreateListAsync(Appointment appointment);

        Task<Appointment> UpdateListAsync(Guid id, Appointment appointment);    

        Task<Appointment> DeleteListAsync(Guid id);

    }
}
