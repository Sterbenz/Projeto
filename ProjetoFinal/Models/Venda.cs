using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Venda
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public int? PedidoId { get; set; }

        public Pedido Pedido { get; set; }

        public int? FuncionarioId { get; set; }

        public Pessoa Funcionario { get; set; }

        public double ValorTotal { get; set; }

        public DateTime DataDaVenda { get; set; }

    }
}