using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class CidadeRequest
    {
        public int Id { get; set; }

        [StringLength(100)]
        public string descricaoCidade { get; set; }

        [Required(ErrorMessage = "Código do estado deve ser informado")]
        public int IdEstado { get; set; }
    }
}
