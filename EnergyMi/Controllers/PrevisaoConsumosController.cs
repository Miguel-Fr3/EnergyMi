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
    public class PrevisaoConsumosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public PrevisaoConsumosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/PrevisaoConsumos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PrevisaoConsumo>>> GetPrevisaoConsumos()
        {
            return await _context.PrevisaoConsumos.ToListAsync();
        }

        // GET: api/PrevisaoConsumos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PrevisaoConsumo>> GetPrevisaoConsumo(int id)
        {
            var previsaoConsumo = await _context.PrevisaoConsumos.FindAsync(id);

            if (previsaoConsumo == null)
            {
                return NotFound();
            }

            return previsaoConsumo;
        }

        // PUT: api/PrevisaoConsumos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPrevisaoConsumo(int id, PrevisaoConsumo previsaoConsumo)
        {
            if (id != previsaoConsumo.CdPrevisao)
            {
                return BadRequest();
            }

            _context.Entry(previsaoConsumo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PrevisaoConsumoExists(id))
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

        // POST: api/PrevisaoConsumos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PrevisaoConsumo>> PostPrevisaoConsumo(PrevisaoConsumo previsaoConsumo)
        {
            _context.PrevisaoConsumos.Add(previsaoConsumo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPrevisaoConsumo", new { id = previsaoConsumo.CdPrevisao }, previsaoConsumo);
        }

        // DELETE: api/PrevisaoConsumos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePrevisaoConsumo(int id)
        {
            var previsaoConsumo = await _context.PrevisaoConsumos.FindAsync(id);
            if (previsaoConsumo == null)
            {
                return NotFound();
            }

            _context.PrevisaoConsumos.Remove(previsaoConsumo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PrevisaoConsumoExists(int id)
        {
            return _context.PrevisaoConsumos.Any(e => e.CdPrevisao == id);
        }
    }
}
