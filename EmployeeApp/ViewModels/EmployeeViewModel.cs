using EmployeeApp.Models;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModels
{
    public class EmployeeViewModel
    {
        [Required]
        [MaxLength(50, ErrorMessage = "Name cannot exceed 50 character")]
        public string NameofProduct { get; set; }

        //[Required]
        //[RegularExpression(@"^[a-zA-Z0-9_.+]+@[a-zA-Z0-9]+\.[a-zA-Z0-9-.]+$",

        //    ErrorMessage = "Invalid Email Format")]
        public string Description { get; set; }

        [Required]
        public Dept? Department { get; set; }

        public IFormFile Photo { get; set; }
    }
}
