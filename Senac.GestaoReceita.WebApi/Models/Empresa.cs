using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Security.Principal;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Empresa
    {
        [Key]
        public int id { get; set; }

        [StringLength(18)]//
        public string CNPJ { get; set; }

        [StringLength(150)]
        public string razaoSosial{ get; set; }

        [StringLength(150)]
        public string rua { get; set; }

        [StringLength(150)]
        public string bairro{ get; set; }

        [StringLength(11)]//
        public int numeroEndereco { get; set; }

        [StringLength(200)]
        public string complemento{ get; set; }

        [StringLength(90)]
        public string email{ get; set; }

        [StringLength(15)]
        public string telefone { get; set; }

        [StringLength(150)]
        public string nomeFantasia { get; set; }

        [StringLength(11)]//
        public int idcidade { get; set; }
        public Cidade cidade { get; set; }

        public DateTime createEmpresa { get; set; }

        public DateTime updateEmpresa { get; set; }

        [StringLength(11)]
        public int idUsername { get; set; }
        //public Cidade cidade { get; set; }
    }
}