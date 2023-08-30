using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class PaisRequest
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Descrição do país deve ser informado")]
        [StringLength(140)]
        public string descricaoPais { get; set; }
    }
}
