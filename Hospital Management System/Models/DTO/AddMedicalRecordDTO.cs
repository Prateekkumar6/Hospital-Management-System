using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models.DTO
{
    public class AddMedicalRecordDTO
    {
        public string Diganosis { get; set; }

        public string Treatment { get; set; }


        public Guid PatientId { get; set; }

        public string DoctorId { get; set; }
    }
}
