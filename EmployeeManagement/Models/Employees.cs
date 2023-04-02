using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.Models
{
    public class Employees
    {
        public int EmpId { get; set; }
        
        [Required(ErrorMessage ="First name is required")]
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string WorkDept { get; set; } = string.Empty;

        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [EmailAddress] 
        public string Email { get; set; } = string.Empty;
        public string Designation { get; set; } = string.Empty;
        public decimal Salary { get; set; }
    }
}
