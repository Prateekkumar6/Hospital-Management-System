using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Doctor
    {
       
        public string Id { get; set; }
        [Required]
        [MinLength(3,ErrorMessage ="Please enter a valid Name")]
        public string doctorName { get; set; }
        public string Speciality { get; set; }  

        public string Timings {  get; set; }    

    }
}
