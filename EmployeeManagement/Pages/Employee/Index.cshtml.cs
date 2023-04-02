using Dapper;
using EmployeeManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Data.SqlClient;
using System.Data;

namespace EmployeeManagement.Pages.Employee
{
    public class IndexModel : PageModel
    {
        private readonly IConfiguration _config;
        public IndexModel(IConfiguration config)
        {
            _config = config;
        }
        
        private string ConnectionString => _config.GetConnectionString(Constant.ConnectionString)!;

        [BindProperty]
        public IEnumerable<Employees> EmployeeList { get; set; }

        public async Task OnGet()
        {
            EmployeeList = await GetDataViaStoredProcedure<Employees>("GetEmployees");
        }

        private async Task<IEnumerable<T>> GetDataViaStoredProcedure<T>(string storedProcedureName, DynamicParameters parameters = null!)
        {
            await using var connection = new SqlConnection(ConnectionString);
            await connection.OpenAsync().ConfigureAwait(false);

            var result = await connection.QueryAsync<T>(storedProcedureName, parameters, commandType: CommandType.StoredProcedure).ConfigureAwait(false);
            return result;
        }
    }
}
