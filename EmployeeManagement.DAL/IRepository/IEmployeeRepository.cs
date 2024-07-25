using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.DAL.IRepository;

public interface IEmployeeRepository
{
    Task<IEnumerable<Employee>> GetAllAsync(string search, int page, int pageSize);
    Task<Employee> GetByIdAsync(int id);
    Task AddAsync(Employee employee);
    Task UpdateAsync(Employee employee);
    Task DeleteAsync(int id);
}
