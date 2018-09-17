using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class LogFamiliasDAO
    {
        public void Adiciona(LogFamilia log)
        {
            using (var context = new LojaContext())
            {
                context.LogFamilias.Add(log);
                context.SaveChanges();
            }
        }

        public IList<LogFamilia> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogFamilias.ToList();
            }
        }

        public LogFamilia BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogFamilias.Find(id);
            }
        }

        public void Atualiza(LogFamilia log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogFamilias.Update(log);
                contexto.SaveChanges();
            }
        }

        public void Remover(LogFamilia log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogFamilias.Remove(log);
                contexto.SaveChanges();
            }
        }
    }
}