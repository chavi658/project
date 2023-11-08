using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RestFull.Entities;

namespace RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GuestController : Controller
    {
        private static List<Guest> guests = new List<Guest> {
            new Guest(){Id=7,Status=false,Phone=0222},
            new Guest(){Id=6,Status=true,Phone=55},
            new Guest(){Id=5,Status=false,Phone=89}, };




        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Guest> Get() => guests;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Guest> Get(int id)
        {
            var x = guests.Find(x => x.Id == id);
            if (x==null)
            {
              return  NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Guest value)
        {
            guests.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Guest> Put(int id, [FromBody] Guest value)
        {
            var eve = guests.Find(e => e.Id == id);
            eve.Status = value.Status;
            if (eve == null)
            {
               return  NotFound();
            }

            return eve;
        }
        [HttpPut("{id}/status")]
        public Guest Put(int id, [FromBody] string status)
        {
            //find the object by id
            var eve = guests.Find(e => e.Id == id);
            //udpate properties
            //eve.Title = updateEvent.Title;
            return eve;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = guests.Find(e => e.Id == id);
            if (eve == null)
            {
                NotFound();
            }
         else   guests.Remove(eve);
        }
    }
}
