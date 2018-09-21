using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Pessoa
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Cpf { get; set; }

        public DateTime DataDeNascimento { get; set; }

        public string Email { get; set; }
        
        public string Telefone { get; set; }

        public int TipoPessoaId { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

    }
}