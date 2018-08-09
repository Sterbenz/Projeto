using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Telefone { get; set; }
    }
}