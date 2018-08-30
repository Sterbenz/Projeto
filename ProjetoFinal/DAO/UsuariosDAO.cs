using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class UsuariosDAO
    {
        public void Adiciona(Usuario usuarios)
        {
            using (var context = new LojaContext())
            {
                context.Usuarios.Add(usuarios);
                context.SaveChanges();
            }
        }

        public IList<Usuario> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Usuarios.ToList();
            }
        }

        public Usuario BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Usuarios.Find(id);
            }
        }

        public void Atualiza(Usuario usuarios)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Usuarios.Update(usuarios);
                contexto.SaveChanges();
            }
        }

        public void Remover(Usuario usuarios)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Usuarios.Remove(usuarios);
                contexto.SaveChanges();
            }
        }
    }
}