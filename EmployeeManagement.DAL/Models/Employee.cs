using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.DAL.Models;

public class Employee
{
    [Key]
    public int EmployeeId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    
    [ForeignKey("DepartmentIdFK")]
    public int DepartmentId { get; set; }
    public decimal Salary { get; set; }
    public DateTime JoinDate { get; set; }
    public bool IsActive { get; set; }
    public Department Department { get; set; }
}
