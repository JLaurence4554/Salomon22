using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalomonAPI.Data;
using SalomonAPI.Model;

namespace SalomonAPI.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class RentalsController : ControllerBase
    {
        private readonly SalomonDbContext _context;

        public RentalsController(SalomonDbContext context)
        {
            _context = context;
        }

        // GET: api/Rentals
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rental>>> GetRentals()
        {
            return await _context.Set<Rental>().Include(r => r.Customers).Include(r => r.Movies).Include(r => r.RentalDetails).ToListAsync();
        }

        // GET: api/Rentals/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Rental>> GetRental(int id)
        {
            var rental = await _context.Set<Rental>().FindAsync(id);

            if (rental == null)
            {
                return NotFound();
            }

            return rental;
        }

        // POST: api/Rentals
        [HttpPost]
        public async Task<ActionResult<Rental>> PostRental(Rental rental)
        {
            _context.Set<Rental>().Add(rental);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRental", new { id = rental.Id }, rental);
        }

        // PUT: api/Rentals/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRental(int id, Rental rental)
        {
            if (id != rental.Id)
            {
                return BadRequest();
            }

            _context.Entry(rental).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RentalExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Rentals/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRental(int id)
        {
            var rental = await _context.Set<Rental>().FindAsync(id);
            if (rental == null)
            {
                return NotFound();
            }

            _context.Set<Rental>().Remove(rental);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RentalExists(int id)
        {
            return _context.Set<Rental>().Any(e => e.Id == id);
        }
    }

}
