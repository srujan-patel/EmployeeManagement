using EmployeeManagement.Shared.Models;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Client.Models
{
    public class EditEmployeeModel
    {
        public int EmployeeId { get; set; }
        [Required(ErrorMessage = "FirstName must be provided")]
        [MinLength(3)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        [CompareProperty("Email", ErrorMessage = "The emails dont match")]
        public string ConfirmEmail { get; set; }
        public DateTime DateofBirth { get; set; }
        public Gender gender { get; set; }
        public int DepartmentID { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
