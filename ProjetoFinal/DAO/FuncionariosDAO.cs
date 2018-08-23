using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class FuncionariosDAO
    {
        public void Adiciona(Funcionario funcionario)
        {
            using (var context = new LojaContext())
            {
                context.Funcionarios.Add(funcionario);
                context.SaveChanges();
            }
        }

        public IList<Funcionario> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Funcionarios.ToList();
            }
        }

        public Funcionario BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Funcionarios.Find(id);
            }
        }

        public void Atualiza(Funcionario funcionario)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Funcionarios.Update(funcionario);
                contexto.SaveChanges();
            }
        }

        public void Remover(Funcionario funcionario)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Funcionarios.Remove(funcionario);
                contexto.SaveChanges();
            }
        }
    }
}