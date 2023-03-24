using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Backend.Data.Entites
{
    internal record Employee
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public int Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Department? Department { get; set; }
    }
}
