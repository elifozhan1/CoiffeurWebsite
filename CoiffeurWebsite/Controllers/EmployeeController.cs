using CoiffeurWebsite.Models;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CoiffeurWebsite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        static List<Employee> emp = new List<Employee>()
        {
            new Employee{EmployeeName="Zeynep",EmployeeID=1},
            //new Ogrenci{OgrenciAd="Elma", OgrenciSoyad="Armut",OgrenciID=2},
            //new Ogrenci{OgrenciAd="Üzüm", OgrenciSoyad="Portakal",OgrenciID=3}
        };

        // GET: api/<ApiController>
        [HttpGet]

        public List<Employee> Get()
        {
            return emp;
        }
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<ApiController>/5

        [HttpGet("{id}")]
        public ActionResult<Employee> Get(int id)
        {
            var emp1 = emp.FirstOrDefault(x => x.EmployeeID == id);
            if (emp1 is null)
            {
                return NotFound();
            }
            return emp1;

        }

        //public string Get(int id)
        //{
        //    return "value";
        //}

        // POST api/<ApiController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            emp.Add(value);
        }

        // PUT api/<ApiController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ApiController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
