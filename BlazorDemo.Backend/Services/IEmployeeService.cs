using BlazorDemo.Backend.Models.DTO;

namespace BlazorDemo.Backend.Services
{
    public interface IEmployeeService
    {
        Task<EmployeeDTO> CreateEmployeeAsync(EmployeeDTO employee);
        Task<EmployeeDTO> EditEmployeeAsync(EmployeeDTO employee);
        Task<EmployeeDTO?> GetEmployeeByIdAsync(Guid? id);
        Task<IEnumerable<EmployeeDTO>> GetEmployeesAsync();
        Task DeleteEmployeeAsync(Guid? employeeId);
    }
}