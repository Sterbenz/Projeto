﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProjetoFinal.DAO;

namespace ProjetoFinal.Migrations
{
    [DbContext(typeof(LojaContext))]
    [Migration("20180912200736_PedidosUpgrade")]
    partial class PedidosUpgrade
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoFinal.Models.AcompanhamentoFornecedores", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEmissao");

                    b.Property<DateTime>("DataEntrega");

                    b.Property<int>("FornecedorId");

                    b.Property<int>("PedidoId");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.HasIndex("FornecedorId");

                    b.HasIndex("PedidoId");

                    b.ToTable("Acompanhamentos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Endereco", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP");

                    b.Property<string>("Cidade");

                    b.Property<int>("Numero");

                    b.Property<string>("Rua");

                    b.HasKey("Id");

                    b.ToTable("Enderecos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.FamiliaProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.HasKey("Id");

                    b.ToTable("Categorias");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Fornecedor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Bairro");

                    b.Property<string>("CEP");

                    b.Property<string>("CNPJ");

                    b.Property<string>("Cidade");

                    b.Property<string>("DenominacaoSocial");

                    b.Property<string>("Email");

                    b.Property<string>("Endereco");

                    b.Property<string>("PrazoMedioEntrega");

                    b.Property<string>("Telefone");

                    b.Property<string>("UF");

                    b.HasKey("Id");

                    b.ToTable("Fornecedores");
                });

            modelBuilder.Entity("ProjetoFinal.Models.LogPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int>("PessoaId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("LogPessoas");
                });

            modelBuilder.Entity("ProjetoFinal.Models.LogProduto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<int>("PessoaId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("LogProdutos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Pedido", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DataEntrega");

                    b.Property<bool>("Entregue");

                    b.Property<double>("ValorTotal");

                    b.HasKey("Id");

                    b.ToTable("Pedidos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.PedidoProdutos", b =>
                {
                    b.Property<int>("PedidoId");

                    b.Property<int>("ProdutoId");

                    b.HasKey("PedidoId", "ProdutoId");

                    b.HasIndex("ProdutoId");

                    b.ToTable("PedidoProdutos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Pessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Cpf")
                        .IsRequired()
                        .HasColumnType("VARCHAR(11)");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Email");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoPessoaId");

                    b.HasKey("Id");

                    b.HasIndex("TipoPessoaId");

                    b.ToTable("Pessoas");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Produto", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Complemento");

                    b.Property<int>("FamiliaProdutoId");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(50);

                    b.Property<double>("PrecoPorUnidade");

                    b.Property<int>("Quantidade");

                    b.HasKey("Id");

                    b.HasIndex("FamiliaProdutoId");

                    b.ToTable("Produtos");
                });

            modelBuilder.Entity("ProjetoFinal.Models.TipoPessoa", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Descricao");

                    b.Property<string>("Nome")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("TipoPessoas");
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("PessoaId");

                    b.Property<string>("Senha");

                    b.Property<string>("User");

                    b.HasKey("Id");

                    b.HasIndex("PessoaId");

                    b.ToTable("Usuarios");
                });

            modelBuilder.Entity("ProjetoFinal.Models.AcompanhamentoFornecedores", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Fornecedor", "Fornecedor")
                        .WithMany()
                        .HasForeignKey("FornecedorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoFinal.Models.Pedido", "Pedido")
                        .WithMany()
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.LogPessoa", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.LogProduto", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoFinal.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.PedidoProdutos", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Pedido", "Pedido")
                        .WithMany("Produtos")
                        .HasForeignKey("PedidoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoFinal.Models.Produto", "Produto")
                        .WithMany("Pedidos")
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.Pessoa", b =>
                {
                    b.HasOne("ProjetoFinal.Models.TipoPessoa", "TipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.Produto", b =>
                {
                    b.HasOne("ProjetoFinal.Models.FamiliaProduto", "Familia")
                        .WithMany()
                        .HasForeignKey("FamiliaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.Usuario", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Pessoa", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}