using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using WebApplication1.Filters;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    [Authorize(Roles = "Admin,POC")]
    [Route("api/emp2")]
    [ApiController]
    public class EmployeeV2Controller : ControllerBase
    {

        private static readonly List<EmployeeV2> _data = new()
        {
            new EmployeeV2
            {
                Id = 1,
                Name = "Furnia",
                Salary = 45000,
                Permanent = true,
                DateOfBirth = new DateTime(1996, 4, 15),
                Department = new WebApplication1.Models.Department { Id = 1, Name = "IT" }, // Explicitly specify the correct namespace
                Skills = new List<Skill> {
                    new Skill { Id = 1, Name = "C#" },
                    new Skill { Id = 2, Name = "SQL" }
                }
            }
        };

        [HttpGet(Name = "GetAllEmployeesV2")]
        [ProducesResponseType(typeof(IEnumerable<EmployeeV2>), 200)]
        [ProducesResponseType(500)]
        public ActionResult<IEnumerable<EmployeeV2>> GetStandard()
        {
            return Ok(_data);
        }

        [HttpPost]
        [ProducesResponseType(typeof(EmployeeV2), 201)]
        public ActionResult<EmployeeV2> Post([FromBody] EmployeeV2 emp)
        {
            emp.Id = _data.Max(e => e.Id) + 1;
            _data.Add(emp);
            return CreatedAtAction(nameof(GetStandard), new { id = emp.Id }, emp);
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(EmployeeV2), 200)]
        [ProducesResponseType(400)]
        public ActionResult<EmployeeV2> Put(int id, [FromBody] EmployeeV2 updated)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = _data.FirstOrDefault(e => e.Id == id);
            if (emp is null)
                return BadRequest("Invalid employee id");

            emp.Name = updated.Name;
            emp.Salary = updated.Salary;
            emp.Permanent = updated.Permanent;
            emp.DateOfBirth = updated.DateOfBirth;
            emp.Department = updated.Department;
            emp.Skills = updated.Skills;

            return Ok(emp);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult Delete(int id)
        {
            if (id <= 0)
                return BadRequest("Invalid employee id");

            var emp = _data.FirstOrDefault(e => e.Id == id);
            if (emp is null)
                return BadRequest("Invalid employee id");

            _data.Remove(emp);
            return NoContent();
        }
    }
}
