using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class ProdutosDAO
    {
        public void Adiciona(Produto produto)
        {
            using (var context = new LojaContext())
            {
                context.Produtos.Add(produto);
                context.SaveChanges();
            }
        }

        public IList<Produto> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Produtos.ToList();
            }
        }

        public Produto BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Produtos.Include("Categoria")
                    .Where(p => p.Id == id)
                    .FirstOrDefault();
            }
        }

        public void Atualiza(Produto produto)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Update(produto);
                contexto.SaveChanges();
            }
        }

        public void Remover(Produto produto)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Produtos.Remove(produto);
                contexto.SaveChanges();
            }
        }
    }
}