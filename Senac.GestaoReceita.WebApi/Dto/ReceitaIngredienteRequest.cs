using Senac.GestaoReceita.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class ReceitaIngredienteRequest
    {
        public int Id { get; set; }
        public int IdReceita { get; set; }

        [Required(ErrorMessage = "Ingrediente deve ser informado")]
        public int Idingrediente { get; set; }
        [Required(ErrorMessage = "A quantiade de ingredientes deve ser informada")]
        public int quantidadeIngrediente { get; set; }

        public int IdGastoVariado { get; set; }
        public decimal qntGastoVariado { get; set; }
    }
}
