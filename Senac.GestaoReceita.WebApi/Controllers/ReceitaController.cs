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
        public async Task<ActionResult<IEnumerable<ReceitaResponse>>> GetReceitas()
        {
            if (_context.Receitas == null)
            {
                return NotFound();
            }
            return await _context.Receitas
                .Include(receita => receita.ReceitaIngrediente)
                .ThenInclude(ri => ri.Ingrediente)
                .Select( receita => new ReceitaResponse
                {
                    Id = receita.Id,
                    nomeReceita = receita.nomeReceita,
                    ValorTotalReceita = receita.ValorTotalReceita,
                    ReceitaIngrediente = receita.ReceitaIngrediente.Select(ri => new ReceitaIngredienteResponse
                    {
                        Id = ri.Id,
                        IdReceita = ri.IdReceita,
                        Idingrediente = ri.Idingrediente,
                        quantidadeIngrediente = ri.quantidadeIngrediente,
                        IdGastoVariado = ri.IdGastoVariado,
                        qntGastoVariado = ri.qntGastoVariado,
                        Ingrediente = new IngredienteResponse 
                        { 
                          EmpresaId = ri.Ingrediente.EmpresaId,
                          NomeIngrediente = ri.Ingrediente.NomeIngrediente,
                          PrecoIngrediente = ri.Ingrediente.PrecoIngrediente,
                          QuantidadeUnidade = ri.Ingrediente.QuantidadeUnidade,
                          UnidadeMedidaId = ri.Ingrediente.UnidadeMedidaId
                          
                        }
                    }).ToList()
                })
                .ToListAsync();
        }

        // GET: api/Receita/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReceitaResponse>> GetReceita(int id)
        {
            if (_context.Receitas == null)
            {
                return NotFound();
            }
            var receita = await _context.Receitas
                .Include(receita => receita.ReceitaIngrediente)
                .ThenInclude(ri => ri.Ingrediente)
                .Select(receita => new ReceitaResponse
                {
                    Id = receita.Id,
                    nomeReceita = receita.nomeReceita,
                    ValorTotalReceita = receita.ValorTotalReceita,
                    ReceitaIngrediente = receita.ReceitaIngrediente.Select(ri => new ReceitaIngredienteResponse
                    {
                        Id = ri.Id,
                        IdReceita = ri.IdReceita,
                        Idingrediente = ri.Idingrediente,
                        quantidadeIngrediente = ri.quantidadeIngrediente,
                        IdGastoVariado = ri.IdGastoVariado,
                        qntGastoVariado = ri.qntGastoVariado,
                        Ingrediente = new IngredienteResponse
                        {
                            EmpresaId = ri.Ingrediente.EmpresaId,
                            NomeIngrediente = ri.Ingrediente.NomeIngrediente,
                            PrecoIngrediente = ri.Ingrediente.PrecoIngrediente,
                            QuantidadeUnidade = ri.Ingrediente.QuantidadeUnidade,
                            UnidadeMedidaId = ri.Ingrediente.UnidadeMedidaId

                        }
                    }).ToList()
                }).FirstAsync(f=>f.Id == id);

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

            var novaReceita = new Receita()
            {
                nomeReceita = receita.nomeReceita,
                ValorTotalReceita = receita.ValorTotalReceita,
                ReceitaIngrediente = receitaIngrediente
            };

            foreach (var ri in receita.ReceitaIngrediente)
            {
                receitaIngrediente.Add(new ReceitaIngrediente() { 
                    Idingrediente = ri.Idingrediente,
                    quantidadeIngrediente = ri.quantidadeIngrediente,
                    IdGastoVariado = ri.IdGastoVariado,
                    qntGastoVariado = ri.qntGastoVariado,
                    Receita = novaReceita
                });
            }
            novaReceita.ReceitaIngrediente = receitaIngrediente;


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
