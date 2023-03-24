using Microsoft.AspNetCore.Mvc;

namespace BlazorDemo.WebAssembly.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        [HttpGet]
        public async Task<IActionResult> Getasync()
        {
            return Ok(await _employeeService.GetEmployeesAsync());
        }

        [HttpGet("{employeeId}")]
        public async Task<IActionResult> GetByIdAsync(Guid employeeId)
        {
            return Ok(await _employeeService.GetEmployeeByIdAsync(employeeId));
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync(EmployeeDTO employeeDTO)
        {
            var createdEmployee = await _employeeService.CreateEmployeeAsync(employeeDTO);

            return CreatedAtAction(nameof(GetByIdAsync), new { employeeId = createdEmployee.Id }, createdEmployee);
        }

        [HttpPut("{employeeId}")]
        public async Task<IActionResult> EditAsync(EmployeeDTO employeeDTO, Guid employeeId)
        {
            return Ok(await _employeeService.EditEmployeeAsync(employeeDTO));
        }

        [HttpDelete("{employeeId}")]
        public async Task<IActionResult> DeleteAsync(Guid employeeId)
        {
            await _employeeService.DeleteEmployeeAsync(employeeId);
            return Ok();
        }
    }
}
