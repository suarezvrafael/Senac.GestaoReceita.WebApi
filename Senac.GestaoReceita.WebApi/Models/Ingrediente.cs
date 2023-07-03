using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do ingrediente deve ser informado")]
        //[StringLength(200), MinLength(4, ErrorMessage = "Nome do ingrediente deve ter no mínimo 4 caracteres")]
        public string NomeIngrediente { get; set; }

        [Required(ErrorMessage = "Preço do ingrediente deve ser informado")]
        public decimal PrecoIngrediente { get; set; }

        [Required(ErrorMessage = "Quantidade do ingrediente deve ser informada")]
        public float QuantidadeUnidade { get; set; }

        [Required(ErrorMessage = "Código da empresa deve ser informado")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }

        [Required(ErrorMessage = "Código da unidade de medida deve ser informado")]
        public int UnidadeMedidaId { get; set; }
        public UnidadeMedida UnidadeMedida { get; set; }
    }
}
