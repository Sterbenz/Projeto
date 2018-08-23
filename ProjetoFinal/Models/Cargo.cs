using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class Cargo
    {

        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        public string Descricao { get; set; }
    }
}