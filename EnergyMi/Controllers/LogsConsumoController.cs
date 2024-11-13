using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyMi.Data;
using EnergyMi.Models;

namespace EnergyMi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LogsConsumoController : ControllerBase
    {
        private readonly AppDbContext _context;

        public LogsConsumoController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/LogsConsumo
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LogConsumo>>> GetLogConsumos()
        {
            return await _context.LogConsumos.ToListAsync();
        }

        // GET: api/LogsConsumo/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LogConsumo>> GetLogConsumo(int id)
        {
            var logConsumo = await _context.LogConsumos.FindAsync(id);

            if (logConsumo == null)
            {
                return NotFound();
            }

            return logConsumo;
        }

        // PUT: api/LogsConsumo/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLogConsumo(int id, LogConsumo logConsumo)
        {
            if (id != logConsumo.CdLogConsumo)
            {
                return BadRequest();
            }

            _context.Entry(logConsumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LogConsumoExists(id))
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

        // POST: api/LogsConsumo
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LogConsumo>> PostLogConsumo(LogConsumo logConsumo)
        {
            _context.LogConsumos.Add(logConsumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLogConsumo", new { id = logConsumo.CdLogConsumo }, logConsumo);
        }

        // DELETE: api/LogsConsumo/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLogConsumo(int id)
        {
            var logConsumo = await _context.LogConsumos.FindAsync(id);
            if (logConsumo == null)
            {
                return NotFound();
            }

            _context.LogConsumos.Remove(logConsumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LogConsumoExists(int id)
        {
            return _context.LogConsumos.Any(e => e.CdLogConsumo == id);
        }
    }
}
