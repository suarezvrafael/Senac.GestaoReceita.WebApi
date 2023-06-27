﻿using System.ComponentModel.DataAnnotations;

namespace Senac.GestaoReceita.WebApi.Models
{
    public class Receita
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Nome da receita deve ser informada.")]
        [StringLength(140), MinLength(4, ErrorMessage = "Nome da receita deve ter no mínimo 4 caracteres")]
        public string nomeReceita { get; set; }

        [Required(ErrorMessage = "ID da empresa deve ser informado.")]
        public int IdEmpresa { get; set; }
       
        public decimal ValorTotalReceita { get; set; }
    }
}
