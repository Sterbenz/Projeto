using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class AcompanhamentoFornecedores
    {
        public int Id { get; set; }

        [Required]
        public DateTime DataEmissao { get; set; }

        [Required]
        public DateTime DataEntrega { get; set; }

        [Required]
        public double ValorTotal { get; set; }

        public int PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        public int FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }
    }
}