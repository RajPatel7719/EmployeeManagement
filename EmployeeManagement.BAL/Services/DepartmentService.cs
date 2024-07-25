using AutoMapper;
using EmployeeManagement.BAL.DataModels;
using EmployeeManagement.BAL.IServices;
using EmployeeManagement.DAL.IRepository;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BAL.Services;

public class DepartmentService(IDepartmentRepository departmentRepository, IMapper mapper) : IDepartmentService
{
    private readonly IDepartmentRepository _departmentRepository = departmentRepository;
    private readonly IMapper _mapper = mapper;

    public async Task<IEnumerable<DepartmentDto>> GetAllAsync()
    {
        var departments = await _departmentRepository.GetAllAsync();
        return _mapper.Map<IEnumerable<DepartmentDto>>(departments);
    }

    public async Task<DepartmentDto> GetByIdAsync(int id)
    {
        var department = await _departmentRepository.GetByIdAsync(id);
        return _mapper.Map<DepartmentDto>(department);
    }

    public async Task AddAsync(DepartmentDto departmentDto)
    {
        var department = _mapper.Map<Department>(departmentDto);
        await _departmentRepository.AddAsync(department);
    }

    public async Task UpdateAsync(DepartmentDto departmentDto)
    {
        var department = _mapper.Map<Department>(departmentDto);
        await _departmentRepository.UpdateAsync(department);
    }

    public async Task DeleteAsync(int id)
    {
        await _departmentRepository.DeleteAsync(id);
    }
}
