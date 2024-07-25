using EmployeeManagement.BAL.DataModels;
using EmployeeManagement.BAL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

public class EmployeeController(IEmployeeService employeeService, IDepartmentService departmentService) : Controller
{
    private readonly IEmployeeService _employeeService = employeeService;
    private readonly IDepartmentService _departmentService = departmentService;

    // GET: /Employee/
    public async Task<IActionResult> Index(string search, int page = 1, int pageSize = 10)
    {
        var employees = await _employeeService.GetAllAsync(search, page, pageSize);
        var totalEmployees = employees.Count();

        ViewBag.CurrentPage = page;
        ViewBag.TotalPages = (int)Math.Ceiling(totalEmployees / (double)10);

        return View(employees);
    }

    // GET: /Employee/Create
    public async Task<IActionResult> Create()
    {
        ViewBag.Departments = await _departmentService.GetAllAsync();
        return View();
    }

    // POST: /Employee/Create
    [HttpPost]
    public async Task<IActionResult> Create(EmployeeDto employee)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.AddAsync(employee);
            return Json(new { success = true });
        }
        ViewBag.Departments = await _departmentService.GetAllAsync();
        return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }

    // GET: /Employee/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var employee = await _employeeService.GetByIdAsync(id);
        if (employee == null)
        {
            return NotFound();
        }
        ViewBag.Departments = await _departmentService.GetAllAsync();
        return View(employee);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(EmployeeDto employee)
    {
        if (ModelState.IsValid)
        {
            await _employeeService.UpdateAsync(employee);
            return Json(new { success = true });
        }
        return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _employeeService.DeleteAsync(id);
        return Json(new { success = true });
    }
}
