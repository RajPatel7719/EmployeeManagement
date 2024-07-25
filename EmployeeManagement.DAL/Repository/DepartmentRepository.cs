﻿using EmployeeManagement.DAL.DBContext;
using EmployeeManagement.DAL.IRepository;
using EmployeeManagement.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DAL.Repository;

public class DepartmentRepository(AppDbContext context) : IDepartmentRepository
{
    private readonly AppDbContext _context = context;

    public async Task<IEnumerable<Department>> GetAllAsync()
    {
        return await _context.Departments.ToListAsync();
    }

    public async Task<Department> GetByIdAsync(int id)
    {
        return await _context.Departments.FindAsync(id);
    }

    public async Task AddAsync(Department department)
    {
        _context.Departments.Add(department);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateAsync(Department department)
    {
        _context.Departments.Update(department);
        await _context.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var department = await _context.Departments.FindAsync(id);
        if (department != null)
        {
            _context.Departments.Remove(department);
            await _context.SaveChangesAsync();
        }
    }
}
