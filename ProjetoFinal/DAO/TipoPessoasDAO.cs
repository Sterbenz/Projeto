using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class TipoPessoasDAO
    {
        public void Adiciona(TipoPessoa tipo)
        {
            using (var context = new LojaContext())
            {
                context.TipoPessoas.Add(tipo);
                context.SaveChanges();
            }
        }

        public IList<TipoPessoa> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.TipoPessoas.ToList();
            }
        }

        public TipoPessoa BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.TipoPessoas.Find(id);
            }
        }

        public void Atualiza(TipoPessoa tipo)
        {
            using (var contexto = new LojaContext())
            {
                contexto.TipoPessoas.Update(tipo);
                contexto.SaveChanges();
            }
        }

        public void Remover(TipoPessoa tipo)
        {
            using (var contexto = new LojaContext())
            {
                contexto.TipoPessoas.Remove(tipo);
                contexto.SaveChanges();
            }
        }
    }
}