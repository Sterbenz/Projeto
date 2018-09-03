using Microsoft.EntityFrameworkCore;
using ProjetoFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ProjetoFinal.DAO
{
    public class LojaContext : DbContext
    {
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<FamiliaProduto> Categorias { get; set; }

        public DbSet<Pessoa> Pessoas { get; set; }        

        public DbSet<TipoPessoa> TipoPessoas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<LogProduto> LogProdutos { get; set; }

        public DbSet<LogPessoa> LogPessoas { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<AcompanhamentoFornecedores> Acompanhamentos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
    }
}
