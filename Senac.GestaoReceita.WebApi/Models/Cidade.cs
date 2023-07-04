using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Cidade
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Municipio deve ser informado")]
        [StringLength(200), MinLength(4, ErrorMessage = "Município deve ter no mínimo 4 caracteres")]
        public string descricaoCidade { get; set; }

        [Required(ErrorMessage = "Código do estado deve ser informado")]
        public int EstadoId { get; set; }
        public Estado Estado { get; set; }
    }
}
