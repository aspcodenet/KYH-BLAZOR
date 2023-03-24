using AutoMapper;
using BlazorDemo.Backend.Data;
using BlazorDemo.Backend.Data.Entites;
using BlazorDemo.Backend.Models.DTO;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace BlazorDemo.Backend.Services
{
    public class DepartmentService : IDepartmentService
    {
        private readonly IMapper _mapper;
        private readonly ILogger<DepartmentService> _logger;
        private readonly ApplicationDbContext _dbContext;

        public DepartmentService(IMapper mapper, ILogger<DepartmentService> logger, ApplicationDbContext dbContext)
        {
            _mapper = mapper;
            _logger = logger;
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<DepartmentDTO>> GetDepartmentsAsync()
        {

            var departments = await _dbContext.Departments.Include(e => e.Employees).ToListAsync();
            return _mapper.Map<IEnumerable<DepartmentDTO>>(departments);
        }

        public async Task<DepartmentDTO?> GetDepartmentByIdAsync(Guid? departmentId)
        {

            var department = await _dbContext.Departments.FirstOrDefaultAsync(e => e.Id == departmentId);
            return _mapper.Map<DepartmentDTO?>(department);
        }

        public async Task<DepartmentDTO> CreateDepartmentAsync(DepartmentDTO department)
        {
            var newDepartment = _mapper.Map<Department>(department);
            await _dbContext.Departments.AddAsync(newDepartment);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<DepartmentDTO>(newDepartment);
        }

        public async Task<DepartmentDTO> EditDepartmentAsync(DepartmentDTO department)
        {
            var departmentToUpdate = await _dbContext.Departments.FindAsync(department.Id);

            _mapper.Map(department, departmentToUpdate);

            _dbContext.Departments.Update(departmentToUpdate);
            await _dbContext.SaveChangesAsync();
            return _mapper.Map<DepartmentDTO>(departmentToUpdate);
        }

        public async Task DeleteDepartmentAsync(Guid? departmentId)
        {

            var departmentToRemove = _dbContext.Departments.FirstOrDefault(e => e.Id == departmentId);
            if (departmentToRemove is null)
                return;

            _dbContext.Departments.Remove(departmentToRemove);
            await _dbContext.SaveChangesAsync();
        }
    }
}