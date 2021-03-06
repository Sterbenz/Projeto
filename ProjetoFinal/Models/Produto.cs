﻿using System;
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
        [Range(0.1,Double.MaxValue)]
        public Double PrecoPorUnidade { get; set; }

        [Required]
        [Range(0.1, 999.99)]
        public int Quantidade { get; set; }

        public string Complemento { get; set; }

        
        public int FamiliaProdutoId { get; set; }

        
        public FamiliaProduto Familia { get; set; }

        public IList<PedidoProdutos> Pedidos { get; set; }
    }
}