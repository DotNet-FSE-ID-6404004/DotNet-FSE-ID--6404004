using Microsoft.AspNetCore.Mvc;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/emp")] // Will be /api/employee
    public class EmployeeController : ControllerBase
    {
        private static List<Employee> employees = new()
        {
            new Employee { Id = 1, Name = "arun", Department = "IT" },
            new Employee { Id = 2, Name = "Neha", Department = "HR" }
        };

        [HttpGet]
        [ProducesResponseType(typeof(IEnumerable<Employee>), 200)]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(employees);
        }

        [HttpPost]
        [ProducesResponseType(typeof(Employee), 201)]
        public ActionResult<Employee> Post(Employee emp)
        {
            emp.Id = employees.Max(e => e.Id) + 1;
            employees.Add(emp);
            return CreatedAtAction(nameof(Get), new { id = emp.Id }, emp);
        }
    }
}
