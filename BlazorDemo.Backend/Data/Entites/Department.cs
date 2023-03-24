using System.ComponentModel.DataAnnotations;

namespace BlazorDemo.Backend.Data.Entites
{
    internal record Department
    {
        [Key]
        public Guid Id { get; set; }
        public required string Name { get; set; }
        public virtual ICollection<Employee>? Employees { get; set; }
    }
}
