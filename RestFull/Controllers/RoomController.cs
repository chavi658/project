using Microsoft.AspNetCore.Mvc;
using RestFull.Entities;

namespace RestFull.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : Controller
    {

        private static List<Room> rooms = new List<Room> {
            new Room(){Id=7,Avialable=false},
            new Room(){Id=6,Avialable=true},
            new Room(){Id=5,Avialable=false}, };




        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<Room> Get() => rooms;


        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public ActionResult<Room> Get(int id)
        {
            var x = rooms.Find(x => x.Id == id);
            if (x == null)
            {
                return NotFound();
            }

            return x;
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] Room value)
        {
            rooms.Add(value);
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public ActionResult<Room> Put(int id, [FromBody] Room value)
        {
            var eve = rooms.Find(e => e.Id == id);
            if (eve == null)
            {
                return NotFound();
            }
            eve.Avialable = value.Avialable;
            eve.Id=id;
            
            return eve;
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var eve = rooms.Find(e => e.Id == id);
            if (eve==null)
            {
                NotFound();
            }
            rooms.Remove(eve);
        }
    }
}
