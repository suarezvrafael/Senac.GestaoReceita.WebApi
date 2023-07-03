using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Estado
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Nome do estado deve ser informado")]
        [StringLength(200), MinLength(4, ErrorMessage = "Estado deve ter no mínimo 4 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Sigla do estado deve ser informado")]
        [StringLength(2), MinLength(2, ErrorMessage = "Sigla deve ter no mínimo 2 caracteres")]
        public string Sigla { get; set; }

        public List<Cidade> cidades { get; set; }
    }
}
