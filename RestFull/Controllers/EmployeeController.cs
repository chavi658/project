using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestFull.Entities;

namespace RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : Controller
    {

        private static List<Employee> employees = new List<Employee> {
            new Employee(){Id="123",Name="natan",Salary=12300,Status=true},
            new Employee(){Id="456",Name="noam",Salary=123,Status=false},
            new Employee(){Id="456",Name="yair",Salary=1230,Status=false}, };



        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Employee> Get() => employees;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Employee> Get(string id)
        {

           var x=employees.Find(x=>x.Id==id);
            if (x ==null)
            {
                return NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Employee value)
        {
            employees.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Employee> Put(string id, [FromBody] Employee value)
        {
            var eve = employees.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            eve.Status = value.Status;
            eve.Salary = value.Salary;
            return eve;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            var eve = employees.Find(e => e.Id == id);
            if (eve == null)
            {
                 NotFound();
            }
            employees.Remove(eve);
        }
    }
}

