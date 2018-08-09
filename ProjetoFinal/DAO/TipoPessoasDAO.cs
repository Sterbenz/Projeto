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
            using (var context = new EstoqueContext())
            {
                context.TipoPessoas.Add(tipoPessoa);
                context.SaveChanges();
            }
        }

        public IList<TipoPessoa> Lista()
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.TipoPessoas.ToList();
            }
        }

        public TipoPessoa BuscaPorId(int id)
        {
            using (var contexto = new EstoqueContext())
            {
                return contexto.TipoPessoas.Find(id);
            }
        }

        public void Atualiza(TipoPessoa tipoPessoa)
        {
            using (var contexto = new EstoqueContext())
            {
                contexto.Entry(tipoPessoa).State = System.Data.Entity.EntityState.Modified;
                contexto.SaveChanges();
            }
        }
    }
}