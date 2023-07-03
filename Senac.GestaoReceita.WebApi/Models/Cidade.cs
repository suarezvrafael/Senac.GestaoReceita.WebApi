using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Cidade
    {
        [Key]
        [StringLength(11)]
        public int Id { get; set; }

        [StringLength(100)]
        public string descricaoCidade { get; set; }

        [Required(ErrorMessage = "Código do estado deve ser informado")]
        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
    }
}
