using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class LogVendasDAO
    {
        public void Adiciona(LogVenda log)
        {
            using (var context = new LojaContext())
            {
                context.LogVendas.Add(log);
                context.SaveChanges();
            }
        }

        public IList<LogVenda> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogVendas.ToList();
            }
        }

        public LogVenda BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogVendas.Find(id);
            }
        }

        public void Atualiza(LogVenda log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogVendas.Update(log);
                contexto.SaveChanges();
            }
        }

        public void Remover(LogVenda log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogVendas.Remove(log);
                contexto.SaveChanges();
            }
        }
    }
}
