using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class VendasDAO
    {
        public void Adiciona(Venda vendas)
        {
            using (var context = new LojaContext())
            {
                context.Vendas.Add(vendas);
                context.SaveChanges();
            }
        }

        public IList<Venda> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Vendas.ToList();
            }
        }

        public Venda BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Vendas.Find(id);
            }
        }

        public void Atualiza(Venda vendas)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Vendas.Update(vendas);
                contexto.SaveChanges();
            }
        }

        public void Remover(Venda vendas)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Vendas.Remove(vendas);
                contexto.SaveChanges();
            }

        }

        public IList<Venda> ListaMaisVendidos()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Vendas
                    .Where(v => v.DataDaVenda.Month == DateTime.Now.Month)
                    .ToList();
            }
        }
    }
}