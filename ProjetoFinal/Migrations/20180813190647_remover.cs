using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class remover : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "complemento",
                table: "Produtos",
                newName: "Complemento");

            migrationBuilder.CreateTable(
                name: "LogPessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    PessoaId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogPessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogPessoas_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "LogProdutos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ProdutoId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogProdutos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LogProdutos_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LogProdutos_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LogPessoas_PessoaId",
                table: "LogPessoas",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogProdutos_PessoaId",
                table: "LogProdutos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogProdutos_ProdutoId",
                table: "LogProdutos",
                column: "ProdutoId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogPessoas");

            migrationBuilder.DropTable(
                name: "LogProdutos");

            migrationBuilder.RenameColumn(
                name: "Complemento",
                table: "Produtos",
                newName: "complemento");
        }
    }
}
