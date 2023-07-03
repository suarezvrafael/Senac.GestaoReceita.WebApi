using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Usuario
    {
        [Key]
        public int Id { get; set; } = 0;



        [StringLength(200)]
        public string Nome { get; set; }



        [Required]
        [StringLength(150)]
        public string Username { get; set; }



        [StringLength(200)]
        public string Senha { get; set; }


        [Required]
        [EnumDataType(typeof(Acesso))]
        public Acesso Acesso { get; set; }



        [Required]

        [EnumDataType(typeof(ManterLogado))]
        public ManterLogado ManterLogado { get; set; }



        public int EmpresaId { get; set; }



        // [ForeignKey("EmpresaId")]
        // public Empresa Empresa { get; set; }



        [EnumDataType(typeof(Ativo))]
        public Ativo Ativo { get; set; } = Ativo.Ativo;

    }



    public enum Acesso

    {

        [Display(Name = "1")]
        Acesso1,

        [Display(Name = "2")]
        Acesso2

    }



    public enum ManterLogado

    {

        [Display(Name = "1")]
        Sim,

        [Display(Name = "2")]
        Nao

    }



    public enum Ativo

    {

        [Display(Name = "1")]
        Ativo,

        [Display(Name = "2")]
        Inativo

    }


}

