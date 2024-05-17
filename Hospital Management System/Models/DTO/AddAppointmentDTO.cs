using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models.DTO
{
    public class AddAppointmentDTO
    {
        public DateTime AppointedDate { get; set; }

        public string Status { get; set; }
       
        public Guid PatientId { get; set; }
      
        public string DoctorId { get; set; }
    }
}
