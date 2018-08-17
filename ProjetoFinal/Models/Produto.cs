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

        [Required]
        [StringLength(50)]
        public string Nome { get; set; }

        [Required]
        [Range(1,999.99)]
        public float PrecoPorUnidade { get; set; }

        [Required]
        [Range(1, 999.99)]
        public int Quantidade { get; set; }

        public string Complemento { get; set; }

        [Required]
        public int FamiliaProdutoId { get; set; }

        [Required]
        public FamiliaProduto Familia { get; set; }
    }
}