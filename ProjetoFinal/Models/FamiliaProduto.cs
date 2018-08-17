using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class FamiliaProduto
    {

        [Required]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public String Nome { get; set; }

        public String Descricao { get; set; }
    }
}