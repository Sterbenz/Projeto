using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Produto
    {
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public float PrecoPorUnidade { get; set; }        

        public int Quantidade { get; set; }

        public string complemento { get; set; }
    }
}