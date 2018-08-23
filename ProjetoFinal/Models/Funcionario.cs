using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        [Range(11,11)]
        public string CPF { get; set; }

        [Required]
        public DateTime DataDeNascimento { get; set; }

        public string Telefone { get; set; }


        public int CargoID { get; set; }

        public Cargo Cargo { get; set; }

        public LoginFuncionarios Login { get; set; }

    }
}