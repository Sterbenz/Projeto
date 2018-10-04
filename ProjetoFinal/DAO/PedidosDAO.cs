using System.Collections.Generic;
using System.Linq;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class PedidosDAO
    {
        public void Adiciona(Pedido pedido)
        {
            using (var context = new LojaContext())
            {
                context.Pedidos.Add(pedido);
                context.SaveChanges();
            }
        }

        public IList<Pedido> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pedidos.ToList();
            }
        }

        public Pedido BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pedidos.Find(id);
            }
        }

        public void Atualiza(Pedido pedido)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Pedidos.Update(pedido);
                contexto.SaveChanges();
            }
        }

        public void Remover(Pedido pedido)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Pedidos.Remove(pedido);
                contexto.SaveChanges();
            }
        }

        public IList<Pedido> ListaVendasDoPedido(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pedidos
                    .Where(p => p.Id == id)
                    .ToList();
            }
        }

        public IList<Pedido> ListaProdutosDosPedidos(IList<Venda> vendas)
        {
            using (var contexto = new LojaContext())
            {
                IList<Pedido> vendasPP = new List<Pedido>();

                foreach (Venda venda in vendas)
                {
                    int pedidoId = (int)venda.PedidoId;
                    IList<Pedido> produtosPP = ListaVendasDoPedido(pedidoId);

                    foreach (var prodPP in produtosPP)
                    {
                        vendasPP.Add(prodPP);
                    }
                }

                return vendasPP;
            }
        }
    }
}