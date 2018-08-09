using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class Ligacoes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "FamiliaProdutoId",
                table: "Produtos",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoaID",
                table: "Pessoas",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FamiliaProdutoId",
                table: "Produtos",
                column: "FamiliaProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_TipoPessoaID",
                table: "Pessoas",
                column: "TipoPessoaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_TipoPessoas_TipoPessoaID",
                table: "Pessoas",
                column: "TipoPessoaID",
                principalTable: "TipoPessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Categorias_FamiliaProdutoId",
                table: "Produtos",
                column: "FamiliaProdutoId",
                principalTable: "Categorias",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_TipoPessoas_TipoPessoaID",
                table: "Pessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Categorias_FamiliaProdutoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FamiliaProdutoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_TipoPessoaID",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "FamiliaProdutoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "TipoPessoaID",
                table: "Pessoas");
        }
    }
}
