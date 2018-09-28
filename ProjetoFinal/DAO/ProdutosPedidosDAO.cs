using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class ProdutosPedidosDAO
    {
        public void Adiciona(PedidoProdutos pp)
        {
            using (var context = new LojaContext())
            {
                context.PedidosProdutos.Add(pp);
                context.SaveChanges();
            }
        }

        public IList<PedidoProdutos> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.PedidosProdutos.ToList();
            }
        }

        public void Atualiza(PedidoProdutos pp)
        {
            using (var contexto = new LojaContext())
            {
                contexto.PedidosProdutos.Update(pp);
                contexto.SaveChanges();
            }
        }

        public void Remover(PedidoProdutos pp)
        {
            using (var contexto = new LojaContext())
            {
                contexto.PedidosProdutos.Remove(pp);
                contexto.SaveChanges();
            }
        }

        public IList<PedidoProdutos> ListaProdutosDoPedido(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.PedidosProdutos
                    .Where(p => p.PedidoId == id)
                    .ToList();
            }
        }
    }
}