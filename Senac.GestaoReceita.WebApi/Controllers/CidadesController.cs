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
    public class CidadesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public CidadesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Cidades
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cidade>>> GetCidades()
        {
          if (_context.Cidades == null)
          {
              return NotFound();
          }
            return await _context.Cidades.Include(cidade => cidade.Estado).ThenInclude(estado => estado.Pais).ToListAsync();
        }

        // GET: api/Cidades/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cidade>> GetCidade(int id)
        {
          if (_context.Cidades == null)
          {
              return NotFound();
          }
            var cidade = await _context.Cidades.Include(cidade=> cidade.Estado).ThenInclude(estado=> estado.Pais).FirstOrDefaultAsync( f => f.Id == id);

            if (cidade == null)
            {
                return NotFound();
            }

            return cidade;
        }

        // PUT: api/Cidades/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCidade(int id, CidadeRequest cidade)
        {
            if (id != cidade.Id)
            {
                return BadRequest();
            }

            var estado = _context.Estados.FirstOrDefault(x => x.Id == cidade.IdEstado);

            if (estado == null)
            {
                return Problem("Estado informada não cadastrado.");
            }

            var cidadeEntity = _context.Cidades.First(x => x.Id == id);
            cidadeEntity.descricaoCidade = cidade.descricaoCidade;
            cidadeEntity.Estado = estado;
            
            _context.Entry(cidadeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CidadeExists(id))
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

        // POST: api/Cidades
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cidade>> PostCidade(CidadeRequest cidade)
        {
            var novaCidade = new Cidade()
            {
                descricaoCidade = cidade.descricaoCidade,
                IdEstado = cidade.IdEstado,

            };
          if (_context.Cidades == null)
          {
              return Problem("Entity set 'AppDbContext.Cidades'  is null.");
          }
            _context.Cidades.Add(novaCidade);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCidade", new { id = novaCidade.Id }, cidade);
        }

        // DELETE: api/Cidades/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCidade(int id)
        {
            if (_context.Cidades == null)
            {
                return NotFound();
            }
            var cidade = await _context.Cidades.FindAsync(id);
            if (cidade == null)
            {
                return NotFound();
            }

            _context.Cidades.Remove(cidade);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CidadeExists(int id)
        {
            return (_context.Cidades?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
