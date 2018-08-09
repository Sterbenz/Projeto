using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class EnderecosDAO
    {
        public void Adiciona(Endereco endereco)
        {
            using (var context = new LojaContext())
            {
                context.Enderecos.Add(endereco);
                context.SaveChanges();
            }
        }

        public IList<Endereco> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Enderecos.ToList();
            }
        }

        public Endereco BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Enderecos.Find(id);
            }
        }

        public void Atualiza(Endereco endereco)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Enderecos.Update(endereco);
                contexto.SaveChanges();
            }
        }
    }
}