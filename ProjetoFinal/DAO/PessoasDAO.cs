using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class PessoasDAO
    {
        public void Adiciona(Pessoa pessoa)
        {
            using (var context = new LojaContext())
            {
                context.Pessoas.Add(pessoa);
                context.SaveChanges();
            }
        }

        public IList<Pessoa> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pessoas.ToList();
            }
        }

        public Pessoa BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pessoas.Find(id);
            }
        }

        public Pessoa BuscaPorEmail(string email)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pessoas
                    .Where(p => p.Email == email)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Pessoa pessoa)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Pessoas.Update(pessoa);
                contexto.SaveChanges();
            }
        }

        public IList<Pessoa> ListaClientes()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Pessoas
                    .Where(p => p.TipoPessoaId == 1)
                    .ToList();
            }
        }

        public void Remover(Pessoa pessoa)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Pessoas.Remove(pessoa);
                contexto.SaveChanges();
            }
                
        }
    }
}