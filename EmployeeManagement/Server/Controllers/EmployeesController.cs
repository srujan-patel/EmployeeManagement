using EmployeeManagement.Server.Dal.Repositories;
using EmployeeManagement.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Web.Server.Controllers
{

    [Route("api/[controller]")]//base route for all the methods in the class
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeesController(IEmployeeRepository empRepository) {
            _employeeRepository = empRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Employee>>> GetEmployees()
        {
            try
            {
                return Ok(await _employeeRepository.GetEmployees());
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpGet("{id:int}")]
        public async Task<ActionResult<Employee>> GetEmployee(int id)
        {
            try
            {
                var result = await _employeeRepository.GetEmployee(id);

                if (result == null) return NotFound();

                return result;
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error retrieving data from the database");
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> CreateEmployee([FromBody] Employee employee)
        {
            try
            {
                if (employee == null)
                    return BadRequest();
                var emp = await _employeeRepository.GetEmployeebyEmail(employee.Email);
                
                if (emp != null)
                {
                    ModelState.AddModelError("email", "Employee Already in Use");
                    return BadRequest(ModelState);
                }

                var createdEmployee = await _employeeRepository.AddEmployee(employee);

                return CreatedAtAction(nameof(GetEmployee),
                    new { id = createdEmployee.EmployeeId }, createdEmployee);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }


        [HttpPut]
        public async Task<ActionResult<Employee>> UpdateEmployee([FromBody] Employee employee)
        {

            try
            {

                var employeeToUpdate= await _employeeRepository.GetEmployee(employee.EmployeeId);
                if (employeeToUpdate == null)
                {
                    return NotFound();
                }

                return await _employeeRepository.UpdateEmployee(employee);


            }

            catch (Exception)
            {


                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error updating the data");

            }

        }

        [HttpDelete("{id:int}")]
        public async Task<ActionResult<Employee>> DeleteEmployee(int id)
        {
            try
            {
                var employeeToDelete = await _employeeRepository.GetEmployee(id);

                if (employeeToDelete == null)
                {
                    return NotFound($"Employee with Id = {id} not found");
                }

                 return await _employeeRepository.DeleteEmployee(id);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    "Error deleting data");
            }
        }


    }

}
