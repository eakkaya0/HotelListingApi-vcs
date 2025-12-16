using HotelListing.Api.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelListing.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        public static List<Hotel> hotels = new List<Hotel>
        {
            new Hotel { Id = 1, Name = "Grand Istanbul Hotel", Address = "Başakşehir / İstanbul", Rating = 4.5 },
            new Hotel { Id = 2, Name = "Ege Paradise Resort", Address = "Çeşme / İzmir", Rating = 4.2 }

        };
        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Hotel>> Get()
        {
            return Ok(hotels);
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Hotel> Get(int id)
        {
            var hotel=hotels.FirstOrDefault(h=>h.Id==id);

            if(hotel==null)
            {
                return NotFound();
            }
            return Ok(hotel);
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Hotel> Post([FromBody] Hotel newHotel)
        {
            if(hotels.Any(h=>h.Id==newHotel.Id))
            {
                return BadRequest("Hotel with the same Id already exists.");
            }
            hotels.Add(newHotel);
            return CreatedAtAction(nameof(Get), new { id = newHotel.Id }, newHotel);
            
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Hotel UpdatedHotel)
        {
            var existingHotel = hotels.FirstOrDefault(h => h.Id == id);
            if (existingHotel == null)
            {
                return NotFound();
            }

            existingHotel.Name = UpdatedHotel.Name;
            existingHotel.Address = UpdatedHotel.Address;
            existingHotel.Rating = UpdatedHotel.Rating;

            return NoContent();
            
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hotel = hotels.FirstOrDefault(h => h.Id == id);
            if(hotel==null)
            {
                return NotFound(new { Message = "Hotel not found." });
            }
            hotels.Remove(hotel);
            return NoContent();
           
        }
    }
}
