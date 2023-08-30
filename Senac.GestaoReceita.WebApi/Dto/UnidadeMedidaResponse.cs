using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class UnidadeMedidaResponse
    {
        [Key]
        public int Id { get; set; }
        [StringLength(200)]
        public string descUnidMedIngrediente { get; set; }
        [StringLength(5), MinLength(2, ErrorMessage = "Descrição deve ter no mínimo 2 caracteres")]
        public string sigla { get; set; }

    }
}