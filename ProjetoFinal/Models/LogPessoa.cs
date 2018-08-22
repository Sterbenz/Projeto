using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class LogPessoa
    {
        public int Id { get; set; }
        
        public int PessoaId { get; set; }

        public Cliente Pessoa { get; set; }

        public String Descricao { get; set; }
    }
}