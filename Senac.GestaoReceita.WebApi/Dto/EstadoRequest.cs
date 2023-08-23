using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class EstadoRequest
    {
        [StringLength(100)]
        public string descricaoEstado { get; set; }

        [Required(ErrorMessage = "Código do pais deve ser informado")]
        public int IdPais { get; set; }
    }
}
