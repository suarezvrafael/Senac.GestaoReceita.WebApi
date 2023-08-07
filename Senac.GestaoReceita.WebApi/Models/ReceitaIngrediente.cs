using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class ReceitaIngrediente
    {
        [Key]
        public int Id { get; set; }
        
        public int IdReceita { get; set; }
        
        public int Idingrediente { get; set; }

        public Ingrediente Ingrediente { get; set; }
        public Receita Receita { get; set; }
        
        [Required(ErrorMessage = "A quantiade de ingredientes deve ser informada")]
        public int quantidadeIngrediente { get; set; }

        public int IdGastoVariado { get; set; }
        public decimal qntGastoVariado { get; set; }
    }
}
