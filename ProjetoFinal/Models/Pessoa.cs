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

        [Required(ErrorMessage = "Campo obrigatório!")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo obrigatório!")]
        [MinLength(11, ErrorMessage = "Cpf inválido!")]
        [Column(TypeName = "VARCHAR(11)")]
        public string Cpf { get; set; }

        [Required(ErrorMessage ="Campo obrigatório!")]
        public DateTime DataDeNascimento { get; set; }

        public string Email { get; set; }
        
        public string Telefone { get; set; }

        public int TipoPessoaId { get; set; }

        public TipoPessoa TipoPessoa { get; set; }

    }
}