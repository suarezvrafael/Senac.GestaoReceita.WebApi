using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class IngredienteResponse
    {
        public string NomeIngrediente { get; set; }

        public decimal PrecoIngrediente { get; set; }

        public float QuantidadeUnidade { get; set; }

        public int EmpresaId { get; set; }

        public int UnidadeMedidaId { get; set; }
    }
}
