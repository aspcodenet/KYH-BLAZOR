using Microsoft.AspNetCore.Mvc;

namespace BlazorDemo.WebAssembly.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<IActionResult> Getasync()
        {
            return Ok(await _departmentService.GetDepartmentsAsync());
        }

        [HttpGet("{departmentId}")]
        public async Task<IActionResult> GetByIdAsync(Guid departmentId)
        {
            return Ok(await _departmentService.GetDepartmentByIdAsync(departmentId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(DepartmentDTO departmentDTO)
        {
            var createdEmployee = await _departmentService.CreateDepartmentAsync(departmentDTO);
            var http = new HttpClient();
            return CreatedAtAction(nameof(GetByIdAsync), new { departmentId = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{departmentId}")]
        public async Task<IActionResult> EditAsync(DepartmentDTO departmentDTO, Guid departmentId)
        {
            return Ok(await _departmentService.EditDepartmentAsync(departmentDTO));
        }

        [HttpDelete("{departmentId}")]
        public async Task<IActionResult> DeleteAsync(Guid departmentId)
        {
            await _departmentService.DeleteDepartmentAsync(departmentId);
            return Ok();
        }
    }
}
