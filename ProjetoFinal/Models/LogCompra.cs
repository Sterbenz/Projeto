using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class LogCompra
    {
        public int Id { get; set; }

        public int CompraId { get; set; }

        public int FornecedorId { get; set; }

        public String FornecedorNome { get; set; }

        public int PessoaId { get; set; }

        public String PessoaNome { get; set; }

        public double ValorCompra { get; set; }

        public String Descricao { get; set; }

        public DateTime DataDaCompra { get; set; }
    }
}