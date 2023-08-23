using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senac.GestaoReceita.WebApi.Data;
using Senac.GestaoReceita.WebApi.Models;

namespace Senac.GestaoReceita.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnidadeMedidasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UnidadeMedidasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/UnidadeMedidas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<UnidadeMedida>>> GetUnidadeMedida()
        {
          if (_context.UnidadeMedida == null)
          {
              return NotFound();
          }
            return await _context.UnidadeMedida.ToListAsync();
        }

        // GET: api/UnidadeMedidas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UnidadeMedida>> GetUnidadeMedida(int id)
        {
          if (_context.UnidadeMedida == null)
          {
              return NotFound();
          }
            var unidadeMedida = await _context.UnidadeMedida.FindAsync(id);

            if (unidadeMedida == null)
            {
                return NotFound();
            }

            return unidadeMedida;
        }

        // PUT: api/UnidadeMedidas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUnidadeMedida(int id, UnidadeMedida unidadeMedida)
        {
            if (id != unidadeMedida.Id)
            {
                return BadRequest();
            }

            _context.Entry(unidadeMedida).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UnidadeMedidaExists(id))
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

        // POST: api/UnidadeMedidas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<UnidadeMedida>> PostUnidadeMedida(UnidadeMedida unidadeMedida)
        {
          if (_context.UnidadeMedida == null)
          {
              return Problem("Entity set 'AppDbContext.UnidadeMedida'  is null.");
          }
            _context.UnidadeMedida.Add(unidadeMedida);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUnidadeMedida", new { id = unidadeMedida.Id }, unidadeMedida);
        }

        // DELETE: api/UnidadeMedidas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUnidadeMedida(int id)
        {
            if (_context.UnidadeMedida == null)
            {
                return NotFound();
            }
            var unidadeMedida = await _context.UnidadeMedida.FindAsync(id);
            if (unidadeMedida == null)
            {
                return NotFound();
            }

            _context.UnidadeMedida.Remove(unidadeMedida);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UnidadeMedidaExists(int id)
        {
            return (_context.UnidadeMedida?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
