using EmployeeManagement.BAL.DataModels;

namespace EmployeeManagement.BAL.IServices;

public interface IDepartmentService
{
    Task<IEnumerable<DepartmentDto>> GetAllAsync();
    Task<DepartmentDto> GetByIdAsync(int id);
    Task AddAsync(DepartmentDto department);
    Task UpdateAsync(DepartmentDto department);
    Task DeleteAsync(int id);
}
