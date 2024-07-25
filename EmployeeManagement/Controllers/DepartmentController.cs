using EmployeeManagement.BAL.DataModels;
using EmployeeManagement.BAL.IServices;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers;

public class DepartmentController(IDepartmentService departmentService) : Controller
{
    private readonly IDepartmentService _departmentService = departmentService;

    // GET: /Department/
    public async Task<IActionResult> Index()
    {
        var departments = await _departmentService.GetAllAsync();
        return View(departments);
    }

    // GET: /Department/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        var department = await _departmentService.GetByIdAsync(id);
        return PartialView("_EditDepartment", department);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(DepartmentDto department)
    {
        if (ModelState.IsValid)
        {
            await _departmentService.UpdateAsync(department);
            return Json(new { success = true });
        }
        return Json(new { success = false, errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage) });
    }

    [HttpPost]
    public async Task<IActionResult> Delete(int id)
    {
        await _departmentService.DeleteAsync(id);
        return Json(new { success = true });
    }
}
