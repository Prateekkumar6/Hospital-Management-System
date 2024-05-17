using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace Hospital_Management_System.Models
{
    public class Appointment
    {
        public Guid Id { get; set; }

        public DateTime AppointedDate{ get; set; }

        public string Status { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Please Enter PateintId")]
        public Guid PatientId { get; set; }
        [Required]
        [MaxLength(100, ErrorMessage = "Please Enter DcotorId")]
        public string DoctorId { get; set; }

        //Navigation Properties::::

        public Doctor? Doctor { get; set; }  

        public Patient?Patient { get; set; }  

    }
}
