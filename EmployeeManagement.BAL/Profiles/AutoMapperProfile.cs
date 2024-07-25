using AutoMapper;
using EmployeeManagement.BAL.DataModels;
using EmployeeManagement.DAL.Models;

namespace EmployeeManagement.BAL.Profiles;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<Department, DepartmentDto>().ReverseMap();
        CreateMap<Employee, EmployeeDto>().ReverseMap();
    }
}
