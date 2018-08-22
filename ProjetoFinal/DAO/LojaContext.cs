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

        public DbSet<Cliente> Clientes { get; set; }

        public DbSet<Cliente> Funcionarios { get; set; }

        public DbSet<TipoPessoa> TipoPessoas { get; set; }

        public DbSet<Endereco> Enderecos { get; set; }

        public DbSet<LogProduto> LogProdutos { get; set; }

        public DbSet<LogPessoa> LogPessoas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=LojaDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        
        protected override void OnModelCreating(ModelBuilder model)
        {

            model
                .Entity<LoginFuncionarios>()
                .Property<int>("FuncionarioId");

            model
                .Entity<LoginFuncionarios>()
                .HasKey("FuncionarioId");


        }
    }
}
