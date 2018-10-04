using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class LogComprasDAO
    {
        public void Adiciona(LogCompra log)
        {
            using (var context = new LojaContext())
            {
                context.LogCompras.Add(log);
                context.SaveChanges();
            }
        }

        public IList<LogCompra> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogCompras.ToList();
            }
        }

        public LogCompra BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogCompras.Find(id);
            }
        }

        public void Atualiza(LogCompra log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogCompras.Update(log);
                contexto.SaveChanges();
            }
        }

        public void Remover(LogCompra log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogCompras.Remove(log);
                contexto.SaveChanges();
            }
        }
    }
}