using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Pais
    {
        [Key]
        [Required(ErrorMessage = "Id do país deve ser informado;")]
        [StringLength(11), MinLength(1, ErrorMessage = "Pais deve ter no mínimo 1 caracterer como ID.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Descrição do país deve ser informado")]
        [StringLength(140)]
        public string descricaoPais { get; set; }

    }
}
