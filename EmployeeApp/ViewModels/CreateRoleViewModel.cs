using System.ComponentModel.DataAnnotations;

namespace EmployeeApp.ViewModels
{
    public class CreateRoleViewModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
