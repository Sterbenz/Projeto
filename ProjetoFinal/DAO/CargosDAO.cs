using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class CargosDAO
    {
        public void Adiciona(Cargo cargo)
        {
            using (var context = new LojaContext())
            {
                context.Cargos.Add(cargo);
                context.SaveChanges();
            }
        }

        public IList<Cargo> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Cargos.ToList();
            }
        }

        public Cargo BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Cargos.Find(id);
            }
        }

        public void Atualiza(Cargo cargo)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Cargos.Update(cargo);
                contexto.SaveChanges();
            }
        }

        public void Remover(Cargo cargo)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Cargos.Remove(cargo);
                contexto.SaveChanges();
            }
        }
    }
}