using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class IngredienteRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do ingrediente deve ser informado")]
        [StringLength(200), MinLength(2, ErrorMessage = "Nome do ingrediente deve ter no mínimo 2 caracteres")]
        public string NomeIngrediente { get; set; }

        public decimal PrecoIngrediente { get; set; }

        public float QuantidadeUnidade { get; set; }

        public int EmpresaId { get; set; }

        public int UnidadeMedidaId { get; set; }
    }
}
