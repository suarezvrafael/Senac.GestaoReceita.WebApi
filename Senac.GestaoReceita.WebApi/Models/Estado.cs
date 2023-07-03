using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Estado
    {
        [Key]
        [StringLength(11)]
        public int Id { get; set; }

        [StringLength(100)]
        public string descricaoEstado { get; set; }

        [Required(ErrorMessage = "Código do pais deve ser informado")]
        public int IdPais { get; set; }
        public Pais Pais { get; set; }
    }
}
