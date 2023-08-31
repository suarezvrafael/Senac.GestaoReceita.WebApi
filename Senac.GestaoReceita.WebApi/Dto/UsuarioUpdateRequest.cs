using Senac.GestaoReceita.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class UsuarioUpdateRequest
    {
        public int Id { get; set; } = 0;
        [StringLength(200)]
        public string Nome { get; set; }
        public string Username { get; set; }
        [StringLength(200)]
        public string Senha { get; set; }

        public int EmpresaId { get; set; }

        [EnumDataType(typeof(Ativo))]
        public Ativo Ativo { get; set; } = Ativo.Ativo;
    }
}
