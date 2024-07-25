using EmployeeManagement.BAL.DataModels;

namespace EmployeeManagement.BAL.IServices;

public interface IEmployeeService
{
    Task<IEnumerable<EmployeeDto>> GetAllAsync(string search, int page, int pageSize);
    Task<EmployeeDto> GetByIdAsync(int id);
    Task AddAsync(EmployeeDto employee);
    Task UpdateAsync(EmployeeDto employee);
    Task DeleteAsync(int id);
}
