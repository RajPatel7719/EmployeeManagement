using System.ComponentModel.DataAnnotations;

namespace EmployeeManagement.DAL.Models;

public class Department
{
    [Key]
    public int DepartmentId { get; set; }
    public string Name { get; set; }
    public bool IsActive { get; set; }
}
