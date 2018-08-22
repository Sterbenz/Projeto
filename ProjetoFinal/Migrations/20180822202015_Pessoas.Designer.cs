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
    [Migration("20180822202015_Pessoas")]
    partial class Pessoas
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.1-rtm-30846")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjetoFinal.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoPessoaID");

                    b.HasKey("Id");

                    b.HasIndex("TipoPessoaID");

                    b.ToTable("Cliente");
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

            modelBuilder.Entity("ProjetoFinal.Models.Funcionario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF");

                    b.Property<DateTime>("DataDeNascimento");

                    b.Property<string>("Nome");

                    b.Property<string>("Telefone");

                    b.Property<int>("TipoPessoaID");

                    b.HasKey("Id");

                    b.HasIndex("TipoPessoaID");

                    b.ToTable("Funcionario");
                });

            modelBuilder.Entity("ProjetoFinal.Models.LoginFuncionarios", b =>
                {
                    b.Property<int>("FuncionarioId");

                    b.Property<string>("Senha");

                    b.Property<string>("Usuario");

                    b.HasKey("FuncionarioId");

                    b.ToTable("LoginFuncionarios");
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

                    b.Property<float>("PrecoPorUnidade");

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

            modelBuilder.Entity("ProjetoFinal.Models.Cliente", b =>
                {
                    b.HasOne("ProjetoFinal.Models.TipoPessoa", "tipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.Funcionario", b =>
                {
                    b.HasOne("ProjetoFinal.Models.TipoPessoa", "tipoPessoa")
                        .WithMany()
                        .HasForeignKey("TipoPessoaID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.LoginFuncionarios", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Funcionario", "Funcionario")
                        .WithOne("Login")
                        .HasForeignKey("ProjetoFinal.Models.LoginFuncionarios", "FuncionarioId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.LogPessoa", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Cliente", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.LogProduto", b =>
                {
                    b.HasOne("ProjetoFinal.Models.Cliente", "Pessoa")
                        .WithMany()
                        .HasForeignKey("PessoaId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjetoFinal.Models.Produto", "Produto")
                        .WithMany()
                        .HasForeignKey("ProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjetoFinal.Models.Produto", b =>
                {
                    b.HasOne("ProjetoFinal.Models.FamiliaProduto", "Familia")
                        .WithMany()
                        .HasForeignKey("FamiliaProdutoId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
