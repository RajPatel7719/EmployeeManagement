using EmployeeManagement.DAL.DBContext;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EmployeeManagement.DAL;

public class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
{
    public AppDbContext CreateDbContext(string[] args)
    {

        var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
        var connectionString = "Data Source=localhost\\SQLEXPRESS;Initial Catalog=EmployeeManagment;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;";

        optionsBuilder.UseSqlServer(connectionString);

        return new AppDbContext(optionsBuilder.Options);
    }
}
