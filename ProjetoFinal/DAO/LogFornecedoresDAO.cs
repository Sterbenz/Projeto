using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class LogFornecedoresDAO
    {
        public void Adiciona(LogFornecedor log)
        {
            using (var context = new LojaContext())
            {
                context.LogFornecedores.Add(log);
                context.SaveChanges();
            }
        }

        public IList<LogFornecedor> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogFornecedores.ToList();
            }
        }

        public LogFornecedor BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogFornecedores.Find(id);
            }
        }

        public void Atualiza(LogFornecedor log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogFornecedores.Update(log);
                contexto.SaveChanges();
            }
        }

        public void Remover(LogFornecedor log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogFornecedores.Remove(log);
                contexto.SaveChanges();
            }
        }
    }
}