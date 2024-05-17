using Hospital_Management_System.Data;
using Hospital_Management_System.Models.DomainModels;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repositories
{
    public class SqlDoctorRepository : IDoctorRepository
    {
        private readonly HospitalManagmentDbContext dbContext;

        public SqlDoctorRepository(HospitalManagmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Doctor> CreateAsync([FromBody] Doctor doctor)
        {
           
            await dbContext.AddAsync(doctor);
            await dbContext.SaveChangesAsync();
            return doctor;
        }

        public async Task<Doctor> DeleteAsync(string id)
        {
            var existingDoctor = dbContext.Doctors.FirstOrDefault(x => x.Id == id);
            if(existingDoctor==null)
            {
                return null;  
            }
            dbContext.Remove(existingDoctor);
            await dbContext.SaveChangesAsync();
            return existingDoctor;
        }

        public async Task<List<Doctor>> GetAllAsync()
        {
           return await dbContext.Doctors.ToListAsync();
            
        }

        public  async Task<Doctor> GetById(string id)
        {
            return await dbContext.Doctors.FirstOrDefaultAsync(x => x.Id == id);
            
        }

        public async Task<Doctor> UpdateAsync(string id, Doctor doctor)
        {
            var existingDoctor = dbContext.Doctors.FirstOrDefault(x => x.Id == id);
            if (existingDoctor ==null) 
            {
                return null;
            }
            existingDoctor.Id= doctor.Id;
            existingDoctor.doctorName=doctor.doctorName;
            existingDoctor.Speciality=doctor.Speciality;
            existingDoctor.Timings=doctor.Timings;

            await dbContext.SaveChangesAsync();
            return existingDoctor;  
        }
    }
}
