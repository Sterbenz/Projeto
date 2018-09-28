using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
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
    }
}