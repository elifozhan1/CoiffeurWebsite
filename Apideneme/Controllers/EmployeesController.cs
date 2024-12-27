using Microsoft.AspNetCore.Mvc;

namespace Apideneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private static List<Employee> employees = new List<Employee>
        {
            new Employee { Id = 1, Name = "Zeynep", Treatment = "Saç Boyama", Salon = "Coiffeur Lotus" },
            new Employee { Id = 2, Name = "Elifnur", Treatment = "Saç Boyama", Salon = "Coiffeur Lotus" }
        };

        [HttpGet]
        public ActionResult<IEnumerable<Employee>> Get()
        {
            return Ok(employees); // Tüm çalışanları döner
        }

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var employee = employees.FirstOrDefault(e => e.Id == id);
            if (employee == null)
            {
                return NotFound("Employee not found.");
            }
            return Ok(employee); // Belirli bir çalışanı döner
        }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Treatment { get; set; }
        public string Salon { get; set; }
    }
}
