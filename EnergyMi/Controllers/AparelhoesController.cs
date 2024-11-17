using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using EnergyMi.Data;
using EnergyMi.Models;
using Microsoft.AspNetCore.Authorization;

namespace EnergyMi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AparelhoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AparelhoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Aparelhoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aparelho>>> GetAparelhos()
        {
            return await _context.Aparelhos.ToListAsync();
        }

        // GET: api/Aparelhoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aparelho>> GetAparelho(int id)
        {
            var aparelho = await _context.Aparelhos.FindAsync(id);

            if (aparelho == null)
            {
                return NotFound();
            }

            return aparelho;
        }

        // PUT: api/Aparelhoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAparelho(int id, Aparelho aparelho)
        {
            if (id != aparelho.CdAparelho)
            {
                return BadRequest();
            }

            _context.Entry(aparelho).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AparelhoExists(id))
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

        // POST: api/Aparelhoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aparelho>> PostAparelho(Aparelho aparelho)
        {
            _context.Aparelhos.Add(aparelho);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAparelho", new { id = aparelho.CdAparelho }, aparelho);
        }

        // DELETE: api/Aparelhoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAparelho(int id)
        {
            var aparelho = await _context.Aparelhos.FindAsync(id);
            if (aparelho == null)
            {
                return NotFound();
            }

            _context.Aparelhos.Remove(aparelho);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AparelhoExists(int id)
        {
            return _context.Aparelhos.Any(e => e.CdAparelho == id);
        }
    }
}
