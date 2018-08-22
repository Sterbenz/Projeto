using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.Models
{
    public class LoginFuncionarios
    {
        public string Usuario { get; set; }

        public string Senha { get; set; }

        public Funcionario Funcionario { get; set; }

    }
}