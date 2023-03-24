using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Backend.Models.DTO
{
    public class EmployeeDTO : IDbDTO
    {
        public Guid? Id { get; set; }

        [Required]
        public string Name { get; set; } = null!;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = null!;

        [Range(1, double.MaxValue)]
        public int Salary { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string? Department { get; set; }
    }
}
