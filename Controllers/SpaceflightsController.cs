using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Space_Flight_News.Data;
using Space_Flight_News.Models;

namespace Space_Flight_News.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpaceflightsController : ControllerBase
    {
        private readonly SpaceflightDBContext _context;

        public SpaceflightsController(SpaceflightDBContext context)
        {
            _context = context;
        }

        // GET: api/Spaceflights
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Spaceflight>>> GetSpaceflights()
        {
            return await _context.Spaceflights.ToListAsync();
        }

        // GET: api/Spaceflights/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Spaceflight>> GetSpaceflight(int id)
        {
            var spaceflight = await _context.Spaceflights.FindAsync(id);

            if (spaceflight == null)
            {
                return NotFound();
            }

            return spaceflight;
        }

        // PUT: api/Spaceflights/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutSpaceflight(int id, Spaceflight spaceflight)
        {
            if (id != spaceflight.Id)
            {
                return BadRequest();
            }

            _context.Entry(spaceflight).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SpaceflightExists(id))
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

        // POST: api/Spaceflights
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Spaceflight>> PostSpaceflight(Spaceflight spaceflight)
        {
            _context.Spaceflights.Add(spaceflight);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetSpaceflight", new { id = spaceflight.Id }, spaceflight);
        }

        // DELETE: api/Spaceflights/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSpaceflight(int id)
        {
            var spaceflight = await _context.Spaceflights.FindAsync(id);
            if (spaceflight == null)
            {
                return NotFound();
            }

            _context.Spaceflights.Remove(spaceflight);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SpaceflightExists(int id)
        {
            return _context.Spaceflights.Any(e => e.Id == id);
        }
    }
}
