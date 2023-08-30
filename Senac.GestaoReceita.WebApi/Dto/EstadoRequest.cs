using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Dto
{
    public class EstadoRequest
    {

        public int Id { get; set; }

        [StringLength(100)]
        public string descricaoEstado { get; set; }

        [Required(ErrorMessage = "Código do pais deve ser informado")]
        public int IdPais { get; set; }
    }
}
