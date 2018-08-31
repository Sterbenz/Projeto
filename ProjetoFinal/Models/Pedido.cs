using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ProjetoFinal.Models
{
    public class Pedido
    {
        public int Id { get; set; }

        [Required]
        public IList<Produto> Produtos { get; set; }
    }
}