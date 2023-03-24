using AutoMapper;
using BlazorDemo.Backend.Data;
using BlazorDemo.Backend.Data.Entites;
using BlazorDemo.Backend.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorDemo.Backend.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<EmployeeService> _logger;
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(IMapper mapper, ILogger<EmployeeService> logger, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync()
        {
            var employees = await _dbContext.Employees.Include(e => e.Department).ToListAsync();
            return _mapper.Map<IEnumerable<EmployeeDTO>>(employees);
        }

        public async Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid? id)
        {
            var employee = await _dbContext.Employees.Include(emp => emp.Department).FirstOrDefaultAsync(emp => emp.Id == id);
            return _mapper.Map<EmployeeDTO?>(employee);
        }

        public async Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employee)
        {
            var newEmployee = _mapper.Map<Employee>(employee);

            if (!string.IsNullOrWhiteSpace(employee.Department))
            {
                newEmployee.Department = await _dbContext.Departments.FirstOrDefaultAsync(dep => dep.Name == employee.Department);
            }

            await _dbContext.Employees.AddAsync(newEmployee);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(newEmployee);
        }

        public async Task<EmployeeDTO> EditEmployeeAsync(EmployeeDTO employee)
        {
            var employeeToUpdate = _dbContext.Employees.Include(e => e.Department).First(e => e.Id == employee.Id);

            _mapper.Map(employee, employeeToUpdate);

            if (string.IsNullOrWhiteSpace(employee.Department))
            {
                employeeToUpdate.Department = null;
            }
            else
            {
                employeeToUpdate.Department = await _dbContext.Departments.FirstOrDefaultAsync(dep => dep.Name == employee.Department);
            }

            _dbContext.Employees.Update(employeeToUpdate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<EmployeeDTO>(employeeToUpdate);
        }

        public async Task DeleteEmployeeAsync(Guid? employeeId)
        {
            var employeeToRemove = _dbContext.Employees.FirstOrDefault(e => e.Id == employeeId);
            if (employeeToRemove is null)
                return;

            _dbContext.Employees.Remove(employeeToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }
}