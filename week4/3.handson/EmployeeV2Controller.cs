using Microsoft.AspNetCore.Mvc;
using WebApplication1.Filters;
using WebApplication1.Models;
using System.Linq;
namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/emp2")]
    [ServiceFilter(typeof(CustomAuthFilter))]
    public class EmployeeV2Controller : ControllerBase
    {
        private readonly List<EmployeeV2> _data = new()
        {
            new EmployeeV2 {
                Id = 1,
                Name = "Furnia",
                Salary = 45000,
                Permanent = true,
                DateOfBirth = new DateTime(1996, 4, 15),
                Department = new WebApplication1.Models.Department { Id = 1, Name = "IT" },
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
    }
}
