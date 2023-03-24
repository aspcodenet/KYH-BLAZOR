using BlazorDemo.Backend.Data.Entites;
using Microsoft.EntityFrameworkCore;

namespace BlazorDemo.Backend.Data
{
    public class DataInitializer
    {
        private readonly ApplicationDbContext _dbContext;

        public DataInitializer(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task MigrateDataAsync()
        {
            await _dbContext.Database.MigrateAsync();
            await SeedDataAsync();
            await _dbContext.SaveChangesAsync();
        }

        private async Task SeedDataAsync()
        {
            await SeedDepartmentsAsync();
            await SeedEmployeesAsync();
        }

        private async Task SeedDepartmentsAsync()
        {
            if (!_dbContext.Departments.Any(e => e.Name == "Stockholm"))
            {
                await _dbContext.Departments.AddAsync(new Department() { Name = "Stockholm" });
            }

            if (!_dbContext.Departments.Any(e => e.Name == "Göteborg"))
            {
                await _dbContext.Departments.AddAsync(new Department() { Name = "Göteborg" });
            }
        }

        private async Task SeedEmployeesAsync()
        {
            if (!_dbContext.Employees.Any(e => e.Name == "Richard"))
            {
                await _dbContext.Employees.AddAsync(new Employee
                {
                    Name = "Richard",
                    Email = "richard@email.com",
                    Salary = 55000,
                    DateOfBirth = new DateTime(1970, 05, 21),
                });
            }

            if (!_dbContext.Employees.Any(e => e.Name == "Joseph"))
            {
                await _dbContext.Employees.AddAsync(new Employee
                {
                    Name = "Joseph",
                    Email = "Joseph@email.com",
                    Salary = 32500,
                    DateOfBirth = new DateTime(1996, 01, 02),
                });
            }

            if (!_dbContext.Employees.Any(e => e.Name == "Stefan"))
            {
                await _dbContext.Employees.AddAsync(new Employee
                {
                    Name = "Stefan",
                    Email = "Stefan@email.com",
                    Salary = 72000,
                    DateOfBirth = new DateTime(1969, 05, 21),
                });
            }
        }
    }
}
