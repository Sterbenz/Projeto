using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class logCompras : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LogCompras",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CompraId = table.Column<int>(nullable: false),
                    FornecedorId = table.Column<int>(nullable: false),
                    FornecedorNome = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false),
                    PessoaNome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    DataDaVenda = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogCompras", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogCompras");
        }
    }
}
