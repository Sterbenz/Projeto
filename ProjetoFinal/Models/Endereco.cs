using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Endereco
    {

        public int Id { get; set; }

        public string Cidade{ get; set; }

        public string Bairro { get; set; }

        public string Rua { get; set; }

        public string CEP { get; set; }

        public int Numero { get; set; }
    }
}