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
        
        public Double ValorTotal { get; set; }

        public string Tipo { get; set; }

        public Pedido()
        {
            this.Produtos = new List<PedidoProdutos>();
        }

        public void IncluiProduto(Produto produto)
        {
            this.Produtos.Add
                (
                    new PedidoProdutos() {
                        ProdutoId = produto.Id,
                        Quantidade = produto.Quantidade,
                        DiaDoPedido = DateTime.Now
                    }
                );
        }
    }
}