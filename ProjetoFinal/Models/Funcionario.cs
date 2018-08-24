using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Digite o nome do funcionario!")]
        public string Nome { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        [MinLength(11, ErrorMessage ="Cpf inválido!")]
        [Column(TypeName = "VARCHAR(11)")]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        public DateTime DataDeNascimento { get; set; }

        public string Telefone { get; set; }


        public int CargoId { get; set; }

        public Cargo Cargo { get; set; }

        public LoginFuncionarios Login { get; set; }

    }
}