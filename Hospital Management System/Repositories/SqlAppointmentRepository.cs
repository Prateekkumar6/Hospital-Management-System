using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hospital_Management_System.Repositories
{
    public class SqlAppointmentRepository:IAppointmentRepository
    {
        private readonly HospitalManagmentDbContext dbContext;

        public SqlAppointmentRepository(HospitalManagmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Appointment> CreateListAsync(Appointment appointment)
        {
           
            await dbContext.AddAsync(appointment);
            await dbContext.SaveChangesAsync();
            return appointment;
        }

        public async Task<Appointment> DeleteListAsync(Guid id)
        {
            var existingAppointment = dbContext.Appointments.FirstOrDefault(x => x.Id == id);
            if (existingAppointment == null)
            {
                return null;
            }
            dbContext.Remove(existingAppointment);
            await dbContext.SaveChangesAsync();
            return existingAppointment;
        }

        public async Task<List<Appointment>> GetAllListAsync()
        {
            return await dbContext.Appointments.Include("Doctor").Include("Patient").ToListAsync();
        }

        public async Task<Appointment> GetListById(Guid Id)
        {
          return await dbContext.Appointments.Include("Doctor").Include("Patient").FirstOrDefaultAsync(x => x.Id == Id);   
            
        }

        public async Task<Appointment> UpdateListAsync(Guid id, Appointment appointment)
        {
            var existingAppointment = dbContext.Appointments.FirstOrDefault(x => x.Id == id);
            if (existingAppointment == null)
            {
                return null;
            }
            
            existingAppointment.AppointedDate = appointment.AppointedDate;
            existingAppointment.Status = appointment.Status;
            existingAppointment.DoctorId = appointment.DoctorId;
            existingAppointment.PatientId=appointment.PatientId;

            await dbContext.SaveChangesAsync();
            return existingAppointment;
        }
    }
}
