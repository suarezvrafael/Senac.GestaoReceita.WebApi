using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Senac.GestaoReceita.WebApi.Data;
using Senac.GestaoReceita.WebApi.Dto;
using Senac.GestaoReceita.WebApi.Models;

namespace Senac.GestaoReceita.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstadosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EstadosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Estados
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Estado>>> GetEstados()
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            return await _context.Estados.Include( estado => estado.Pais).ToListAsync();
        }

        // GET: api/Estados/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Estado>> GetEstado(int id)
        {
          if (_context.Estados == null)
          {
              return NotFound();
          }
            var estado = await _context.Estados.Include(estado => estado.Pais).FirstOrDefaultAsync( f=> f.Id == id);

            if (estado == null)
            {
                return NotFound();
            }

            return estado;
        }

        // PUT: api/Estados/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEstado(int id, EstadoRequest estado)
        {
            if (id != estado.Id)
            {
                return BadRequest("Id deve ser informado na requisicao.");
            }
            var pais = _context.Paises.FirstOrDefault(x => x.Id == estado.IdPais);

            if (pais == null)
            {
                return Problem("Pais informado não cadastrado.");
            }

            var estadoEntity = _context.Estados.First(x => x.Id == id);
            estadoEntity.descricaoEstado = estado.descricaoEstado;
            estadoEntity.Pais = pais;

            _context.Entry(estado).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EstadoExists(id))
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

        // POST: api/Estados
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Estado>> PostEstado(EstadoRequest estado)
        {
            var novoEstado = new Estado()
            {
                descricaoEstado = estado.descricaoEstado,
                IdPais = estado.IdPais,
            };
          if (_context.Estados == null)
          {
              return Problem("Entity set 'AppDbContext.Estados'  is null.");
          }
            _context.Estados.Add(novoEstado);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEstado", new { id = novoEstado.Id }, estado);
        }

        // DELETE: api/Estados/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEstado(int id)
        {
            if (_context.Estados == null)
            {
                return NotFound();
            }
            var estado = await _context.Estados.FindAsync(id);
            if (estado == null)
            {
                return NotFound();
            }

            _context.Estados.Remove(estado);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EstadoExists(int id)
        {
            return (_context.Estados?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
