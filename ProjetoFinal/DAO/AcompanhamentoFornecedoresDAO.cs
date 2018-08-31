using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ProjetoFinal.Models;

namespace ProjetoFinal.DAO
{
    public class AcompanhamentoFornecedoresDAO
    {
        public void Adiciona(AcompanhamentoFornecedores acompanhamento)
        {
            using (var context = new LojaContext())
            {
                context.Acompanhamentos.Add(acompanhamento);
                context.SaveChanges();
            }
        }

        public IList<AcompanhamentoFornecedores> Lista()
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Acompanhamentos.ToList();
            }
        }

        public AcompanhamentoFornecedores BuscaPorId(int id)
        {
            using (var contexto = new LojaContext())
            {
                return contexto.Acompanhamentos.Find(id);
            }
        }

        public void Atualiza(AcompanhamentoFornecedores acompanhamento)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Acompanhamentos.Update(acompanhamento);
                contexto.SaveChanges();
            }
        }

        public void Remover(AcompanhamentoFornecedores acompanhamento)
        {
            using (var contexto = new LojaContext())
            {
                contexto.Acompanhamentos.Remove(acompanhamento);
                contexto.SaveChanges();
            }

        }
    }
}