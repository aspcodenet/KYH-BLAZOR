using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Backend.Models.DTO
{
    public class DepartmentDTO : IDbDTO
    {
        public Guid? Id { get; set; }
        [Required]
        public string Name { get; set; } = null!;
        public virtual ICollection<EmployeeDTO>? Employees { get; set; }
    }
}
