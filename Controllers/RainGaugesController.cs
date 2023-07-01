using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WateringService;
using WateringService.Models;

namespace WateringService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RainGaugesController : ControllerBase
    {
        private readonly WateringServiceContext _context;

        public RainGaugesController(WateringServiceContext context)
        {
            _context = context;
        }

        // GET: api/RainGauges
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RainGauge>>> GetRainGauges()
        {
          if (_context.RainGauges == null)
          {
              return NotFound();
          }
            return await _context.RainGauges.ToListAsync();
        }

        // GET: api/RainGauges/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RainGauge>> GetRainGauge(Guid id)
        {
          if (_context.RainGauges == null)
          {
              return NotFound();
          }
            var rainGauge = await _context.RainGauges.FindAsync(id);

            if (rainGauge == null)
            {
                return NotFound();
            }

            return rainGauge;
        }

        // PUT: api/RainGauges/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRainGauge(Guid id, RainGauge rainGauge)
        {
            if (id != rainGauge.GaugeId)
            {
                return BadRequest();
            }

            _context.Entry(rainGauge).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RainGaugeExists(id))
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

        // POST: api/RainGauges
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RainGauge>> PostRainGauge(RainGauge rainGauge)
        {
          if (_context.RainGauges == null)
          {
              return Problem("Entity set 'WateringServiceContext.RainGauges'  is null.");
          }
            _context.RainGauges.Add(rainGauge);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRainGauge", new { id = rainGauge.GaugeId }, rainGauge);
        }

        // DELETE: api/RainGauges/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRainGauge(Guid id)
        {
            if (_context.RainGauges == null)
            {
                return NotFound();
            }
            var rainGauge = await _context.RainGauges.FindAsync(id);
            if (rainGauge == null)
            {
                return NotFound();
            }

            _context.RainGauges.Remove(rainGauge);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RainGaugeExists(Guid id)
        {
            return (_context.RainGauges?.Any(e => e.GaugeId == id)).GetValueOrDefault();
        }
    }
}
