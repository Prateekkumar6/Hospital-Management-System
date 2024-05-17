using System.ComponentModel.DataAnnotations;

namespace Hospital_Management_System.Models
{
    public class Patient
    {
     
       public Guid Id {  get; set; }
       [Required]
       [MinLength(3,ErrorMessage ="Please Enter the Name")]
       public string FirstName { get; set; }
        [Required]
        [MinLength(3, ErrorMessage = "Please Enter the Name")]
        public string LastName { get; set; }

        [Required]
        [MinLength(10, ErrorMessage = "Please Enter the valid DOB")]
        public string DOB { get; set; }

       public string Gender {  get; set; }
       public string Address { get; set; }
        [Required]
        [MinLength(10, ErrorMessage = "Please Enter the valid Phone Number")]
        public string ContactNumber {  get; set; }
    
        public string?Email { get; set; } 


    }
}
