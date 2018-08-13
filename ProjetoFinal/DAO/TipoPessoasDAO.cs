using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class TipoPessoasDAO
    {
        public void Adiciona(TipoPessoa tipoPessoa)
        {
            using (var context = new LojaContext())
            {
                context.TipoPessoas.Add(tipoPessoa);
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

        public void Atualiza(TipoPessoa tipoPessoa)
        {
            using (var contexto = new LojaContext())
            {
                contexto.TipoPessoas.Update(tipoPessoa);
                contexto.SaveChanges();
            }
        }

        public void Remover(TipoPessoa tipoPessoa)
        {
            using (var contexto = new LojaContext())
            {
                contexto.TipoPessoas.Remove(tipoPessoa);
                contexto.SaveChanges();
            }
        }
    }
}