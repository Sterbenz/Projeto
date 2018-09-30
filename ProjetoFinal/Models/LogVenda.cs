using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class LogVenda
    {
        public int Id { get; set; }

        public int VendaId { get; set; }

        public int ClienteId { get; set; }

        public String ClienteNome { get; set; }

        public int PessoaId { get; set; }

        public String PessoaNome { get; set; }

        public String Descricao { get; set; }

        public DateTime DataDaVenda { get; set; }
    }
}