using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class ClientesDAO
    {
        public void Adiciona(Cliente cliente)
        {
            using (var context = new LojaContext())
            {
                context.Clientes.Add(cliente);
                context.SaveChanges();
            }
        }

        public IList<Cliente> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Clientes.ToList();
            }
        }

        public Cliente BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Clientes.Find(id);
            }
        }

        public void Atualiza(Cliente cliente)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Update(cliente);
                contexto.SaveChanges();
            }
        }

        public void Remover(Cliente cliente)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Clientes.Remove(cliente);
                contexto.SaveChanges();
            }
                
        }
    }
}