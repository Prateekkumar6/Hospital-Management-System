using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;
using System.Numerics;

namespace Hospital_Management_System.Repositories
{
    public class SqlPatientRepository:IPatientRepository
    {
        private readonly HospitalManagmentDbContext dbContext;

        public SqlPatientRepository(HospitalManagmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Patient> CreateAsync(Patient patient)
        {

            await dbContext.AddAsync(patient);
            await dbContext.SaveChangesAsync();
            return patient;
        }

        public async Task<Patient> DeleteAsync(Guid id)
        {
            var existingPatient = dbContext.Patients.FirstOrDefault(x => x.Id == id);
            if (existingPatient == null)
            {
                return null;
            }
            dbContext.Remove(existingPatient);
            await dbContext.SaveChangesAsync();
            return existingPatient;
        }

        public async Task<List<Patient>> GetAllAsync()
        {
            return await dbContext.Patients.ToListAsync();
        }

        public async Task<Patient> GetById(Guid Id)
        {
            return await dbContext.Patients.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Patient> UpdateAsync(Guid id, Patient patient)
        {
            var existingPatient = dbContext.Patients.FirstOrDefault(x => x.Id == id);
            if (existingPatient == null)
            {
                return null;
            }
            existingPatient.Id=patient.Id;
            existingPatient.Address=patient.Address;
            existingPatient.FirstName=patient.FirstName;
            existingPatient.LastName=patient.LastName;
            existingPatient.Gender=patient.Gender;
            existingPatient.Email = patient.Email;
            existingPatient.ContactNumber=patient.ContactNumber;
            existingPatient.DOB=patient.DOB;

            await dbContext.SaveChangesAsync();
            return existingPatient;
        }
    }
}
