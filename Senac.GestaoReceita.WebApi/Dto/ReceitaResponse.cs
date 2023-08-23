using Senac.GestaoReceita.WebApi.Models;
using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class ReceitaResponse
    {
        public int Id { get; set; }
        public string nomeReceita { get; set; }

        public decimal ValorTotalReceita { get; set; }

        public List<ReceitaIngredienteResponse> ReceitaIngrediente { get; set; }

    }
}
