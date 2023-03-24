using AutoMapper;
using BlazorDemo.Backend.Data.Entites;
using BlazorDemo.Backend.Models.DTO;

namespace BlazorDemo.Backend.Mapping
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            CreateMap<Employee, EmployeeDTO>().ForMember(emp => emp.Department, opt => opt.MapFrom(emp => emp.Department.Name));
            CreateMap<EmployeeDTO, Employee>().ForMember(emp => emp.Department, options => options.Ignore());

            CreateMap<Department, DepartmentDTO>();
            CreateMap<DepartmentDTO, Department>();
        }
    }
}
