using Microsoft.AspNetCore.Mvc;

namespace Apideneme.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private static List<string> values = new List<string> { "value1", "value2" };

        // GET: api/Values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(values); // 200 OK ve JSON formatında liste döner
        }

        // GET api/Values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= values.Count)
            {
                return NotFound("Value not found."); // 404 Not Found
            }
            return Ok(values[id]); // 200 OK
        }

        // POST api/Values
        [HttpPost]
        public ActionResult Post([FromBody] string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty."); // 400 Bad Request
            }

            values.Add(value);
            return CreatedAtAction(nameof(Get), new { id = values.Count - 1 }, value); // 201 Created
        }

        // PUT api/Values/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string value)
        {
            if (id < 0 || id >= values.Count)
            {
                return NotFound("Value not found."); // 404 Not Found
            }

            if (string.IsNullOrEmpty(value))
            {
                return BadRequest("Value cannot be null or empty."); // 400 Bad Request
            }

            values[id] = value;
            return NoContent(); // 204 No Content
        }

        // DELETE api/Values/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= values.Count)
            {
                return NotFound("Value not found."); // 404 Not Found
            }

            values.RemoveAt(id);
            return NoContent(); // 204 No Content
        }
    }
}
