using EmployeeManagement.BAL.CustomAttribute;
using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.BAL.DataModels;

public class EmployeeDto
{
    public int EmployeeId { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "First name must contain only alphabetic characters.")]
    public string FirstName { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Last name must contain only alphabetic characters.")]
    public string LastName { get; set; }

    [Required]
    public int DepartmentId { get; set; }

    [Required]
    [Range(0, double.MaxValue)]
    [RegularExpression(@"^\d+(\.\d{1,2})?$", ErrorMessage = "Salary must be a decimal number with up to two decimal places.")]
    public decimal Salary { get; set; }

    [Required]
    [DataType(DataType.Date)]
    [CustomDate(ErrorMessage = "Join date cannot be in the future.")]
    public DateTime JoinDate { get; set; }

    public bool IsActive { get; set; }
    public DepartmentDto DepartmentDto { get; set; }
}
