using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Pedido
    {
        public int Id { get; set; }
                
        public IList<PedidoProdutos> Produtos { get; set; }
        
        [Range(0.1, Double.MaxValue)]
        public Double ValorTotal { get; set; }

        public DateTime DataEntrega { get; set; }

        public bool Entregue { get; set; }

        public int? FornecedorId { get; set; }

        public Fornecedor Fornecedor { get; set; }

        public Pedido()
        {
            this.Produtos = new List<PedidoProdutos>();
        }

        public void IncluiProduto(Produto produto)
        {
            this.Produtos.Add(new PedidoProdutos() { Produto = produto });
        }
    }
}