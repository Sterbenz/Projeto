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

        [Required]
        public string DenominacaoSocial { get; set; }

        [Required]
        public string Endereço { get; set; }

        [Required]
        public string Bairro { get; set; }

        [Required]
        public string Cidade { get; set; }

        [Required]
        public string UF { get; set; }

        [Required]
        public string Telefone { get; set; }

        [Required]
        public string CEP { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string CNPJ { get; set; }

        [Required]
        public string InscriçãoEstadual { get; set; }

        [Required]
        public string RamoDeAtividade { get; set; }

        [Required]
        public string ContadoDoResponsavel { get; set; }

        [Required]
        public string FuncaoDoResponsavel { get; set; }

        [Required]
        public string PrazoMedioEntrega { get; set; }

        public string Observacoes { get; set; }
    }
}