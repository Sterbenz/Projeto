﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class LogProduto
    {
        public int Id { get; set; }

        public int ProdutoId { get; set; }

        public String ProdutoNome { get; set; }

        public int PessoaId { get; set; }

        public String PessoaNome { get; set; }

        public String Descricao { get; set; }

        public DateTime DataModificacao { get; set; }
    }
}