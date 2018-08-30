using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class LogProduto
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public Produto Produto { get; set; }

        public int PessoaId { get; set; }

        public Pessoa Pessoa { get; set; }

        public String Descricao { get; set; }
    }
}