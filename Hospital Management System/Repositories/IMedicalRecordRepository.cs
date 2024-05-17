using Hospital_Management_System.Models.DomainModels;

namespace Hospital_Management_System.Repositories
{
    public interface IMedicalRecordRepository
    {
        Task<List<MedicalRecord>> GetAllListAsync();

        Task<MedicalRecord> GetListById(Guid Id);

        Task<MedicalRecord> CreateListAsync(MedicalRecord record);

        Task<MedicalRecord> UpdateListAsync(Guid id, MedicalRecord record);

        Task<MedicalRecord> DeleteListAsync(Guid id);
    }
}
