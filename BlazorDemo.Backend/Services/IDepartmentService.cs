using BlazorDemo.Backend.Models.DTO;

namespace BlazorDemo.Backend.Services
{
    public interface IDepartmentService
    {
        Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO Department);
        Task DeleteDepartmentAsync(Guid? departmentId);
        Task<DepartmentDTO> EditDepartmentAsync(DepartmentDTO Department);
        Task<DepartmentDTO?> GetDepartmentByIdAsync(Guid? departmentId);
        Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync();
    }
}