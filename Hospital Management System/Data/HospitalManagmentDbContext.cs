using Hospital_Management_System.Models.DomainModels;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Data
{
    public class HospitalManagmentDbContext: DbContext
    {
        public HospitalManagmentDbContext(DbContextOptions dbContextOptions): base(dbContextOptions)
        {
            

        }

        public DbSet<Patient> Patients { get; set; }

        public DbSet<Doctor>  Doctors { get; set; }   

        public DbSet<MedicalRecord> MedicalRecords { get; set; }    

        public DbSet<Appointment> Appointments { get; set; }    

 

    }
}
