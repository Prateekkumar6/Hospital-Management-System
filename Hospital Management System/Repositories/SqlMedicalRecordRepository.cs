using Hospital_Management_System.Data;
using Hospital_Management_System.Models;
using Microsoft.EntityFrameworkCore;

namespace Hospital_Management_System.Repositories
{
    public class SqlMedicalRecordRepository:IMedicalRecordRepository
    {
        private readonly HospitalManagmentDbContext dbContext;

        public SqlMedicalRecordRepository(HospitalManagmentDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<MedicalRecord> CreateListAsync(MedicalRecord record)
        {
            await dbContext.AddAsync(record);
            await dbContext.SaveChangesAsync();
            return record;
        }

        public async Task<MedicalRecord> DeleteListAsync(Guid id)
        {
            var existingMedicalRecord = dbContext.MedicalRecords.FirstOrDefault(x => x.Id == id);
            if (existingMedicalRecord == null)
            {
                return null;
            }
            dbContext.Remove(existingMedicalRecord);
            await dbContext.SaveChangesAsync();
            return existingMedicalRecord;
        }

        public async Task<List<MedicalRecord>> GetAllListAsync()
        {
            return await dbContext.MedicalRecords.Include("DoctorList").Include("Patient").ToListAsync();
        }

        public async Task<MedicalRecord> GetListById(Guid Id)
        {
            return await dbContext.MedicalRecords.Include("DoctorList").Include("Patient").FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<MedicalRecord> UpdateListAsync(Guid id, MedicalRecord record)
        {
            var existingMedicalRecord = dbContext.MedicalRecords.FirstOrDefault(x => x.Id == id);
            if (existingMedicalRecord == null)
            {
                return null;
            }

            existingMedicalRecord.Diganosis = record.Diganosis;
            existingMedicalRecord.Treatment = record.Treatment;
            existingMedicalRecord.DoctorId = record.DoctorId;
            existingMedicalRecord.PatientId = record.PatientId;

            await dbContext.SaveChangesAsync();
            return existingMedicalRecord;
        }
    }
}
