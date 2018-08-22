using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Funcionario
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Telefone { get; set; }

        public int TipoPessoaID { get; set; }

        public TipoPessoa tipoPessoa { get; set; }

        public LoginFuncionarios Login { get; set; }

    }
}