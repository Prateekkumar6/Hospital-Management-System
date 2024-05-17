using Hospital_Management_System.Models.DomainModels;
using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models.DTO
{
    public class AppointmentDTO
    {
        public Guid Id { get; set; }

        public DateTime AppointedDate { get; set; }
        public string Status { get; set; }
       
        public Guid PatientId { get; set; }
      
        public string DoctorId { get; set; }

        //Navigation Properties::::

        public Doctor? Doctor { get; set; }

        public Patient? Patient { get; set; }
    }
}
