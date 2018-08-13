using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class LogPessoasDAO
    {
        public void Adiciona(LogPessoa log)
        {
            using (var context = new LojaContext())
            {
                context.LogPessoas.Add(log);
                context.SaveChanges();
            }
        }

        public IList<LogPessoa> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogPessoas.ToList();
            }
        }

        public LogPessoa BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.LogPessoas.Find(id);
            }
        }

        public void Atualiza(LogPessoa log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogPessoas.Update(log);
                contexto.SaveChanges();
            }
        }

        public void Remover(LogPessoa log)
        {
            using (var contexto = new LojaContext())
            {
                contexto.LogPessoas.Remove(log);
                contexto.SaveChanges();
            }
        }
    }
}