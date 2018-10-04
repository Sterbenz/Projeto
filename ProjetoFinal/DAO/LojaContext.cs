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

        public DbSet<LogFornecedor> LogFornecedores { get; set; }

        public DbSet<LogCompra> LogCompras { get; set; }

        public DbSet<LogFamilia> LogFamilias { get; set; }

        public DbSet<Usuario> Usuarios { get; set; }

        public DbSet<Fornecedor> Fornecedores { get; set; }

        public DbSet<Pedido> Pedidos { get; set; }

        public DbSet<AcompanhamentoFornecedores> Acompanhamentos { get; set; }

        public DbSet<Venda> Vendas { get; set; }

        public DbSet<PedidoProdutos> PedidosProdutos { get; set; }

        public DbSet<LogVenda> LogVendas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<PedidoProdutos>()
                .HasKey(pp => new { pp.PedidoId, pp.ProdutoId });
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
        }
        //Casa Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        //Benner Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False
        //IFSC   Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=ProjetoDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False

    }
}
