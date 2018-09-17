using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class Logs : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LogPessoas_Pessoas_PessoaId",
                table: "LogPessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProdutos_Pessoas_PessoaId",
                table: "LogProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProdutos_Produtos_ProdutoId",
                table: "LogProdutos");

            migrationBuilder.DropIndex(
                name: "IX_LogProdutos_PessoaId",
                table: "LogProdutos");

            migrationBuilder.DropIndex(
                name: "IX_LogProdutos_ProdutoId",
                table: "LogProdutos");

            migrationBuilder.DropIndex(
                name: "IX_LogPessoas_PessoaId",
                table: "LogPessoas");

            migrationBuilder.AddColumn<string>(
                name: "PessoaNome",
                table: "LogProdutos",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProdutoNome",
                table: "LogProdutos",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PessoaModificadaId",
                table: "LogPessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "PessoaModificadaNome",
                table: "LogPessoas",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PessoaNome",
                table: "LogPessoas",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "LogFamilias",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FamiliaId = table.Column<int>(nullable: false),
                    FamiliaNome = table.Column<string>(nullable: true),
                    PessoaId = table.Column<int>(nullable: false),
                    PessoaNome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFamilias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LogFornecedores",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FornecedorNome = table.Column<string>(nullable: true),
                    FornecedorId = table.Column<int>(nullable: false),
                    PessoaId = table.Column<int>(nullable: false),
                    PessoaNome = table.Column<string>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LogFornecedores", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LogFamilias");

            migrationBuilder.DropTable(
                name: "LogFornecedores");

            migrationBuilder.DropColumn(
                name: "PessoaNome",
                table: "LogProdutos");

            migrationBuilder.DropColumn(
                name: "ProdutoNome",
                table: "LogProdutos");

            migrationBuilder.DropColumn(
                name: "PessoaModificadaId",
                table: "LogPessoas");

            migrationBuilder.DropColumn(
                name: "PessoaModificadaNome",
                table: "LogPessoas");

            migrationBuilder.DropColumn(
                name: "PessoaNome",
                table: "LogPessoas");

            migrationBuilder.CreateIndex(
                name: "IX_LogProdutos_PessoaId",
                table: "LogProdutos",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_LogProdutos_ProdutoId",
                table: "LogProdutos",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_LogPessoas_PessoaId",
                table: "LogPessoas",
                column: "PessoaId");

            migrationBuilder.AddForeignKey(
                name: "FK_LogPessoas_Pessoas_PessoaId",
                table: "LogPessoas",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogProdutos_Pessoas_PessoaId",
                table: "LogProdutos",
                column: "PessoaId",
                principalTable: "Pessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogProdutos_Produtos_ProdutoId",
                table: "LogProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
