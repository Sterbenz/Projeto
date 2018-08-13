using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class LogProdutosDAO
    {
        public void Adiciona(LogProduto log)
        {
            using (var context = new LojaContext())
            {
                context.LogProdutos.Add(log);
                context.SaveChanges();
            }
        }

        public IList<LogProduto> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogProdutos.ToList();
            }
        }

        public LogProduto BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogProdutos.Find(id);
            }
        }

        public void Atualiza(LogProduto log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogProdutos.Update(log);
                contexto.SaveChanges();
            }
        }

        public void Remover(LogProduto log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogProdutos.Remove(log);
                contexto.SaveChanges();
            }
        }
    }
}