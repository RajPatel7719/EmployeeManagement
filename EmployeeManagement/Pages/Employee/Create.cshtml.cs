using Dapper;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data;
using System.Data.SqlClient;

namespace EmployeeManagement.Pages
{
    public class CreateModel : PageModel
    {
        private readonly IConfiguration _config;
        public CreateModel(IConfiguration config)
        {
            _config = config;
        }

        [BindProperty]
        public Employees employee { get; set; }
        
        private string ConnectionString => _config.GetConnectionString(Constant.ConnectionString)!;

        public IActionResult OnGet()
        {
            return Page();
        }

        public IActionResult OnPost(Employees employees)
        {
            if (ModelState.IsValid)
            {
                var queryParameter = new DynamicParameters();

                queryParameter.Add("@FirstName", employees.FirstName);
                queryParameter.Add("@LastName", employees.LastName);
                queryParameter.Add("@WorkDept", employees.WorkDept);
                queryParameter.Add("@PhoneNumber", employees.PhoneNumber);
                queryParameter.Add("@Email", employees.Email);
                queryParameter.Add("@Designation", employees.Designation);
                queryParameter.Add("@Salary", employees.Salary);
                InsertData("InserEmployee",queryParameter);
            }

            return Redirect("Employees/Index");
        }

        private async Task<long> InsertData(string storedProcedureName, DynamicParameters parameters)
        {
            await using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync().ConfigureAwait(false);

            return await connection.ExecuteScalarAsync<long>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
        }
    }
}
