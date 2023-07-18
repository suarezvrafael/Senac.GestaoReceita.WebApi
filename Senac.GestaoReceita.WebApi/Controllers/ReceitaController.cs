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
    public class ReceitaController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReceitaController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Receita
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReceitaRequest>>> GetReceitas()
        {
            if (_context.Receitas == null)
            {
                return NotFound();
            }
            return await _context.Receitas.ToListAsync();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceitaRequest>> GetReceita(int id)
        {
            if (_context.Receitas == null)
            {
                return NotFound();
            }
            var receita = await _context.Receitas.FindAsync(id);

            if (receita == null)
            {
                return NotFound();
            }

            return receita;
        }

        // PUT: api/Receita/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReceita(int id, ReceitaRequest receita)
        {
            if (id != receita.Id)
            {
                return BadRequest();
            }

            _context.Entry(receita).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReceitaExists(id))
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

        // POST: api/Receita
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Receita>> PostReceita(ReceitaRequest receita)
        {
            if (_context.Receitas == null)
            {
                return Problem("Entity set 'AppDbContext.Receitas'  is null.");
            }

            var receitaIngrediente = new List<ReceitaIngrediente>();

            foreach (var ri in receita.ReceitaIngrediente)
            {
                receitaIngrediente.Add(new ReceitaIngrediente() { 
                    Idingrediente = ri.Idingrediente,
                    IdReceita = ri.IdReceita,
                    quantidadeIngrediente = ri.quantidadeIngrediente,
                    IdGastoVariado = ri.IdGastoVariado,
                    qntGastoVariado = ri.qntGastoVariado
                });
            }

            var novaReceita = new Receita()
            {
                nomeReceita = receita.nomeReceita,
                ValorTotalReceita = receita.ValorTotalReceita,
                ReceitaIngrediente = receitaIngrediente
            };
            _context.Receitas.Add(novaReceita);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReceita", new { id = novaReceita.Id }, receita);
        }

        // DELETE: api/Receita/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReceita(int id)
        {
            if (_context.Receitas == null)
            {
                return NotFound();
            }
            var receita = await _context.Receitas.FindAsync(id);
            if (receita == null)
            {
                return NotFound();
            }

            _context.Receitas.Remove(receita);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReceitaExists(int id)
        {
            return (_context.Receitas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
