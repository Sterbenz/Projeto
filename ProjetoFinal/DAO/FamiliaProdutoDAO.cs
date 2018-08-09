using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class FamiliaProdutoDAO
    {
        public void Adiciona(FamiliaProduto categoria)
        {
            using (var context = new LojaContext())
            {
                context.Categorias.Add(categoria);
                context.SaveChanges();
            }
        }

        public IList<FamiliaProduto> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Categorias.ToList();
            }
        }

        public FamiliaProduto BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Categorias.Find(id);
            }
        }

        public void Atualiza(FamiliaProduto categoria)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Categorias.Update(categoria);
                contexto.SaveChanges();
            }
        }
    }
}