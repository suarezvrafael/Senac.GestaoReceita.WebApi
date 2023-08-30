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
                .ThenInclude(ing => ing.UnidadeMedida)
                .Select(receita => new ReceitaResponse
                {
                    Id = receita.Id,
                    nomeReceita = receita.nomeReceita,
                    ModoPreparo = receita.ModoPreparo,
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
                            UnidadeMedidaId = ri.Ingrediente.UnidadeMedidaId,
                            UnidadeMedida = new UnidadeMedidaResponse
                            {
                                descUnidMedIngrediente = ri.Ingrediente.UnidadeMedida.descUnidMedIngrediente,
                                sigla = ri.Ingrediente.UnidadeMedida.sigla
                            }

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
                .ThenInclude(ing => ing.UnidadeMedida)
                .Select(receita => new ReceitaResponse
                {
                    Id = receita.Id,
                    nomeReceita = receita.nomeReceita,
                    ModoPreparo = receita.ModoPreparo,
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
                            UnidadeMedidaId = ri.Ingrediente.UnidadeMedidaId,
                            UnidadeMedida = new UnidadeMedidaResponse
                            {
                                descUnidMedIngrediente = ri.Ingrediente.UnidadeMedida.descUnidMedIngrediente,
                                sigla = ri.Ingrediente.UnidadeMedida.sigla
                            }

                        }
                    }).ToList()
                }).FirstAsync(f => f.Id == id);

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
            //var empresa = _context.Empresas.FirstOrDefault(x => x.Id == ingrediente.EmpresaId);

            //if (empresa == null)
            //{
            //    return Problem("empresa informada não cadastrada.");
            //}

            //var unidadeMedida = _context.UnidadeMedida.FirstOrDefault(x => x.Id == ingrediente.UnidadeMedidaId);

            //if (unidadeMedida == null)
            //{
            //    return Problem("unidadeMedida informada não cadastrada.");
            //}

            var valorTotalReceita = 0.00M;

            var receitaEntity = _context.Receitas
                .Include(ing => ing.ReceitaIngrediente)
                .ThenInclude(ri => ri.Ingrediente).First(x => x.Id == id);

            receitaEntity.nomeReceita = receita.nomeReceita;
            receitaEntity.ModoPreparo = receita.ModoPreparo;

            // Remover ReceitaIngrediente que não estão mais presentes na requisição
            var ingredientesToRemove = receitaEntity.ReceitaIngrediente
                .Where(ri => !receita.ReceitaIngrediente.Any(riReq => riReq.Id == ri.Id))
                .ToList();

            foreach (var ingredienteToRemove in ingredientesToRemove)
            {
                _context.ReceitaIngredientes.Remove(ingredienteToRemove);
            }

            // Adicionar ou atualizar os ReceitaIngrediente da requisição
            foreach (var receitaIngredienteReq in receita.ReceitaIngrediente)
            {
                var ingrediente = _context.Ingredientes.FirstOrDefault(x => x.Id == receitaIngredienteReq.Idingrediente);

                if (ingrediente == null)
                {
                    return Problem(@$"ingrediente informada ({receitaIngredienteReq.Idingrediente}) não cadastrada.");
                }
                var valorIngrediente = ingrediente.PrecoIngrediente;

                valorTotalReceita += valorIngrediente * receitaIngredienteReq.quantidadeIngrediente;

                var receitaIngredienteEntity = receitaEntity.ReceitaIngrediente.FirstOrDefault(ri => ri.Id == receitaIngredienteReq.Id);

                if (receitaIngredienteEntity == null)
                {
                    // Adicionar novo ReceitaIngrediente
                    var novoReceitaIngrediente = new ReceitaIngrediente
                    {
                        // Preencha as propriedades aqui
                        Idingrediente = receitaIngredienteReq.Idingrediente,
                        Ingrediente = ingrediente,
                        quantidadeIngrediente = receitaIngredienteReq.quantidadeIngrediente,
                        IdGastoVariado = receitaIngredienteReq.IdGastoVariado,
                        qntGastoVariado = receitaIngredienteReq.qntGastoVariado,
                    };
                    receitaEntity.ReceitaIngrediente.Add(novoReceitaIngrediente);
                }
                else
                {
                    // Atualizar propriedades do ReceitaIngrediente existente
                    receitaIngredienteEntity.Idingrediente = receitaIngredienteReq.Idingrediente;
                    receitaIngredienteEntity.Ingrediente = ingrediente;
                    receitaIngredienteEntity.quantidadeIngrediente = receitaIngredienteReq.quantidadeIngrediente;
                    // ...
                }
            }

            receitaEntity.ValorTotalReceita = valorTotalReceita;

            _context.Entry(receitaEntity).State = EntityState.Modified;

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

            var valorTotalReceita = 0.00M;

            var novaReceita = new Receita()
            {
                nomeReceita = receita.nomeReceita,
                ModoPreparo = receita.ModoPreparo,
                ValorTotalReceita = receita.ValorTotalReceita,
                ReceitaIngrediente = receitaIngrediente
            };

            foreach (var ri in receita.ReceitaIngrediente)
            {
                var ingrediente = _context.Ingredientes.FirstOrDefault(x => x.Id == ri.Idingrediente);

                if (ingrediente == null)
                {
                    return Problem(@$"ingrediente informada ({ri.Idingrediente}) não cadastrada.");
                }

                var valorIngrediente = ingrediente.PrecoIngrediente;

                valorTotalReceita += valorIngrediente * ri.quantidadeIngrediente;

                receitaIngrediente.Add(new ReceitaIngrediente()
                {
                    Idingrediente = ri.Idingrediente,
                    quantidadeIngrediente = ri.quantidadeIngrediente,
                    IdGastoVariado = ri.IdGastoVariado,
                    qntGastoVariado = ri.qntGastoVariado,
                    Receita = novaReceita
                }) ;
            }
            novaReceita.ReceitaIngrediente = receitaIngrediente;
            novaReceita.ValorTotalReceita = valorTotalReceita;


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
