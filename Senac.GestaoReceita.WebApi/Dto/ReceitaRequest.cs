using Senac.GestaoReceita.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class ReceitaRequest
    {
        [Required(ErrorMessage = "Nome da receita deve ser informada.")]
        [StringLength(140), MinLength(4, ErrorMessage = "Nome da receita deve ter no mínimo 4 caracteres")]
        public string nomeReceita { get; set; }

        public decimal ValorTotalReceita { get; set; }

        public List<ReceitaIngredienteRequest> ReceitaIngrediente { get; set; }

    }
}
