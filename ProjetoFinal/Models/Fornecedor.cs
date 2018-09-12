using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Fornecedor
    {
        public int Id { get; set; }
                
        public string DenominacaoSocial { get; set; }

        public string Endereco { get; set; }

        public string Bairro { get; set; }

        public string Cidade { get; set; }

        public string UF { get; set; }

        public string Telefone { get; set; }

        public string CEP { get; set; }

        public string Email { get; set; }

        public string CNPJ { get; set; }        

        public int PrazoMedioEntrega { get; set; }

        
    }
}