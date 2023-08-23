using System;
using System.Collections.Generic;
using System.Data;
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
    public class EmpresasController : ControllerBase
    {
        private readonly AppDbContext _context;

        public EmpresasController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Empresas
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresas()
        {
          if (_context.Empresas == null)
          {
              return NotFound();
          }
            return await _context.Empresas
                .Include(empresa=>empresa.cidade)
                .ThenInclude(cidade=>cidade.Estado)
                .ThenInclude(estado=>estado.Pais).ToListAsync();
        }

        // GET: api/Empresas/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresa(int id)
        {
          if (_context.Empresas == null)
          {
              return NotFound();
          }
            var empresa = await _context.Empresas
                .Include(empresa => empresa.cidade)
                .ThenInclude(cidade => cidade.Estado)
                .ThenInclude(estado => estado.Pais).FirstOrDefaultAsync(f=>f.Id == id);

            if (empresa == null)
            {
                return NotFound();
            }

            return empresa;
        }

        // PUT: api/Empresas/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmpresa(int id, EmpresaUpdateRequest empresa)
        {
            if (id != empresa.Id)
            {
                return BadRequest();
            }

            var cidade = _context.Cidades.FirstOrDefault(x => x.Id == empresa.idcidade);

            if (cidade == null)
            {
                return Problem("Cidade informada não cadastrada.");
            }

            var empresaEntity = _context.Empresas.Include(empresa=> empresa.cidade).First(x => x.Id == id);

            empresaEntity.cidade = cidade;
            empresaEntity.telefone = empresa.telefone;
            empresaEntity.email = empresa.email;
            empresaEntity.updateEmpresa = DateTime.Now;
            empresaEntity.bairro = empresa.bairro;
            empresaEntity.CNPJ = empresa.CNPJ;
            empresaEntity.complemento = empresa.complemento;
            empresaEntity.nomeFantasia = empresa.nomeFantasia;
            empresaEntity.numeroEndereco = empresa.numeroEndereco;
            empresaEntity.razaoSosial = empresa.razaoSosial;
            empresaEntity.rua = empresa.rua;
            empresaEntity.telefone = empresa.telefone;
            

            _context.Entry(empresaEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmpresaExists(id))
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

        // POST: api/Empresas
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Empresa>> PostEmpresa(EmpresaRequest empresa)
        {
          if (_context.Empresas == null)
          {
              return Problem("Entity set 'AppDbContext.Empresas'  is null.");
          }

            var cidade = _context.Cidades.FirstOrDefault(x =>  x.Id == empresa.idcidade);

            if (cidade == null)
            {
                return Problem("Cidade informada não cadastrada.");
            }

            var newEmpresa = new Empresa() { 
                cidade = cidade,
                email = empresa.email,
                bairro = empresa.bairro,
                CNPJ = empresa.CNPJ,    
                complemento = empresa.complemento,
                createEmpresa = DateTime.Now,
                nomeFantasia = empresa.nomeFantasia,
                numeroEndereco = empresa.numeroEndereco,
                razaoSosial = empresa.razaoSosial,
                rua = empresa.rua,
                telefone = empresa.telefone,
                idUsername = empresa.idUsername
            };
            _context.Empresas.Add(newEmpresa);

            await _context.SaveChangesAsync();

            return CreatedAtAction("GetEmpresa", new { id = empresa.Id }, empresa);
        }

        // DELETE: api/Empresas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmpresa(int id)
        {
            if (_context.Empresas == null)
            {
                return NotFound();
            }
            var empresa = await _context.Empresas.FindAsync(id);
            if (empresa == null)
            {
                return NotFound();
            }

            _context.Empresas.Remove(empresa);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmpresaExists(int id)
        {
            return (_context.Empresas?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
