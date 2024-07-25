using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.BAL.DataModels;

public class DepartmentDto
{
    public int DepartmentId { get; set; }

    [Required]
    [RegularExpression("^[a-zA-Z]+$", ErrorMessage = "Name must contain only alphabetic characters.")]
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
