using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class semTipoPessoaCliente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_TipoPessoas_TipoPessoaID",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_TipoPessoaID",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "TipoPessoaID",
                table: "Cliente");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Cliente",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "TipoPessoaID",
                table: "Cliente",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_TipoPessoaID",
                table: "Cliente",
                column: "TipoPessoaID");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_TipoPessoas_TipoPessoaID",
                table: "Cliente",
                column: "TipoPessoaID",
                principalTable: "TipoPessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
