using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models.DomainModels
{
    public class MedicalRecord
    {
        public Guid Id { get; set; }

        public string Diganosis { get; set; }

        public string Treatment { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Please Enter PateintId")]

        public Guid PatientId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Please Enter DcotorId")]
        public string DoctorId { get; set; }


        //Navigation Properties ::

        public Doctor? DoctorList { get; set; }

        public Patient? Patient { get; set; }

    }
}
