using Senac.GestaoReceita.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class ReceitaIngredienteResponse
    {
        public int Id { get; set; }
        public int IdReceita { get; set; }

        public int Idingrediente { get; set; }
        public IngredienteResponse Ingrediente { get; set; }
        [Required(ErrorMessage = "A quantiade de ingredientes deve ser informada")]
        public int quantidadeIngrediente { get; set; }

        public int IdGastoVariado { get; set; }
        public decimal qntGastoVariado { get; set; }
    }
}
