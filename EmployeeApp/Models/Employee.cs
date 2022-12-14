using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.Models
{
    public class Employee
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(50, ErrorMessage ="Name cannot exceed 50 character")]        
        public string NameofProducts { get; set; }

        [Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+]+@[a-zA-Z0-9]+\.[a-zA-Z0-9-.]+$", 
            
        //    ErrorMessage = "Invalid Email Format")]
        public string Description { get; set; }

        [Required]
        public Dept? Department { get; set; }

        public string PhotoPath { get; set; }

   }

}
