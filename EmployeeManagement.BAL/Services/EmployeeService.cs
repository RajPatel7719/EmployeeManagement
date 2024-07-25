using AutoMapper;
using EmployeeManagement.BAL.DataModels;
using EmployeeManagement.BAL.IServices;
using EmployeeManagement.DAL.IRepository;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BAL.Services;

public class EmployeeService(IEmployeeRepository employeeRepository, IMapper mapper) : IEmployeeService
{
    private readonly IEmployeeRepository _employeeRepository = employeeRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<EmployeeDto>> GetAllAsync(string search, int page, int pageSize)
    {
        var employees = await _employeeRepository.GetAllAsync(search, page, pageSize);
        return _mapper.Map<IEnumerable<EmployeeDto>>(employees);
    }

    public async Task<EmployeeDto> GetByIdAsync(int id)
    {
        var employee = await _employeeRepository.GetByIdAsync(id);
        return _mapper.Map<EmployeeDto>(employee);
    }

    public async Task AddAsync(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.AddAsync(employee);
    }

    public async Task UpdateAsync(EmployeeDto employeeDto)
    {
        var employee = _mapper.Map<Employee>(employeeDto);
        await _employeeRepository.UpdateAsync(employee);
    }

    public async Task DeleteAsync(int id)
    {
        await _employeeRepository.DeleteAsync(id);
    }
}
