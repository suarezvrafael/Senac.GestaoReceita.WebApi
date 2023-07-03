using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Ingrediente
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome do ingrediente deve ser informado")]
        //[StringLength(200), MinLength(4, ErrorMessage = "Nome do ingrediente deve ter no mínimo 4 caracteres")]
        public string nomeIngrediente { get; set; }

        public decimal precoIngrediente { get; set; }

        public int unidadeMedidaId { get; set; }

        public float quantidadeUnidade { get; set; }

        [Required(ErrorMessage = "Código do estado deve ser informado")]
        public int EmpresaId { get; set; }
        public Empresa Empresa { get; set; }
    }
}
