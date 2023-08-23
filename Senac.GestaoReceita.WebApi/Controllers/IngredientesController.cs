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
    public class IngredientesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public IngredientesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Ingredientes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ingrediente>>> GetIngredientes()
        {
          if (_context.Ingredientes == null)
          {
              return NotFound();
          }
            return await _context.Ingredientes
                .Include(ing=>ing.Empresa)
                .ThenInclude(emp=>emp.cidade)
                .ThenInclude(cid=>cid.Estado)
                .ThenInclude(est=> est.Pais)
                .Include(ing=>ing.UnidadeMedida).ToListAsync();
        }

        // GET: api/Ingredientes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Ingrediente>> GetIngrediente(int id)
        {
          if (_context.Ingredientes == null)
          {
              return NotFound();
          }
            var ingrediente = await _context.Ingredientes
                .Include(ing => ing.Empresa)
                .ThenInclude(emp => emp.cidade)
                .ThenInclude(cid => cid.Estado)
                .ThenInclude(est => est.Pais)
                .Include(ing => ing.UnidadeMedida).FirstOrDefaultAsync(f=>f.Id == id);

            if (ingrediente == null)
            {
                return NotFound();
            }

            return ingrediente;
        }

        // PUT: api/Ingredientes/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIngrediente(int id, IngredienteRequest ingrediente)
        {
            if (id != ingrediente.Id)
            {
                return BadRequest();
            }


            var empresa = _context.Empresas.FirstOrDefault(x => x.Id == ingrediente.EmpresaId);

            if (empresa == null)
            {
                return Problem("empresa informada não cadastrada.");
            }

            var unidadeMedida = _context.UnidadeMedida.FirstOrDefault(x => x.Id == ingrediente.UnidadeMedidaId);

            if (unidadeMedida == null)
            {
                return Problem("unidadeMedida informada não cadastrada.");
            }

            var ingredienteEntity = _context.Ingredientes
                .Include(ing => ing.Empresa)
                .Include(ing => ing.UnidadeMedida).First(x => x.Id == id);

            ingredienteEntity.NomeIngrediente = ingrediente.NomeIngrediente;
            ingredienteEntity.PrecoIngrediente = ingrediente.PrecoIngrediente;
            ingredienteEntity.QuantidadeUnidade = ingrediente.QuantidadeUnidade;
            ingredienteEntity.UnidadeMedida = unidadeMedida;
            ingredienteEntity.Empresa = empresa;

            _context.Entry(ingredienteEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngredienteExists(id))
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

        // POST: api/Ingredientes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Ingrediente>> PostIngrediente(IngredienteRequest ingrediente)
        {
          if (_context.Ingredientes == null)
          {
              return Problem("Entity set 'AppDbContext.Ingredientes'  is null.");
          }

            var empresa = _context.Empresas.FirstOrDefault(x => x.Id == ingrediente.EmpresaId);

            if (empresa == null)
            {
                return Problem("empresa informada não cadastrada.");
            }

            var unidadeMedida = _context.UnidadeMedida.FirstOrDefault(x => x.Id == ingrediente.UnidadeMedidaId);

            if (unidadeMedida == null)
            {
                return Problem("unidadeMedida informada não cadastrada.");
            }

            var novoIngrediente = new Ingrediente()
            {
                NomeIngrediente = ingrediente.NomeIngrediente,
                PrecoIngrediente = ingrediente.PrecoIngrediente,
                QuantidadeUnidade = ingrediente.QuantidadeUnidade,
                UnidadeMedida = unidadeMedida,
                Empresa = empresa
            };

            _context.Ingredientes.Add(novoIngrediente);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngrediente", new { id = novoIngrediente.Id }, ingrediente);
        }

        // DELETE: api/Ingredientes/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIngrediente(int id)
        {
            if (_context.Ingredientes == null)
            {
                return NotFound();
            }
            var ingrediente = await _context.Ingredientes.FindAsync(id);
            if (ingrediente == null)
            {
                return NotFound();
            }

            _context.Ingredientes.Remove(ingrediente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool IngredienteExists(int id)
        {
            return (_context.Ingredientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
