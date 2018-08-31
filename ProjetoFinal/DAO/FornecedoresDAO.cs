using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class FornecedoresDAO
    {
        public void Adiciona(Fornecedor fornecedor)
        {
            using (var context = new LojaContext())
            {
                context.Fornecedores.Add(fornecedor);
                context.SaveChanges();
            }
        }

        public IList<Fornecedor> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Fornecedores.ToList();
            }
        }

        public Fornecedor BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Fornecedores.Find(id);
            }
        }

        public void Atualiza(Fornecedor fornecedor)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Fornecedores.Update(fornecedor);
                contexto.SaveChanges();
            }
        }

        public void Remover(Fornecedor fornecedor)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Fornecedores.Remove(fornecedor);
                contexto.SaveChanges();
            }

        }
    }
}