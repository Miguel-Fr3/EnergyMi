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
    public class RecomendacoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RecomendacoesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Recomendacoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Recomendacao>>> GetRecomendacao()
        {
            return await _context.Recomendacao.ToListAsync();
        }

        // GET: api/Recomendacoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Recomendacao>> GetRecomendacao(int id)
        {
            var recomendacao = await _context.Recomendacao.FindAsync(id);

            if (recomendacao == null)
            {
                return NotFound();
            }

            return recomendacao;
        }

        // PUT: api/Recomendacoes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRecomendacao(int id, Recomendacao recomendacao)
        {
            if (id != recomendacao.CdRecomendacao)
            {
                return BadRequest();
            }

            _context.Entry(recomendacao).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RecomendacaoExists(id))
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

        // POST: api/Recomendacoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Recomendacao>> PostRecomendacao(Recomendacao recomendacao)
        {
            _context.Recomendacao.Add(recomendacao);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRecomendacao", new { id = recomendacao.CdRecomendacao }, recomendacao);
        }

        // DELETE: api/Recomendacoes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRecomendacao(int id)
        {
            var recomendacao = await _context.Recomendacao.FindAsync(id);
            if (recomendacao == null)
            {
                return NotFound();
            }

            _context.Recomendacao.Remove(recomendacao);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RecomendacaoExists(int id)
        {
            return _context.Recomendacao.Any(e => e.CdRecomendacao == id);
        }
    }
}
