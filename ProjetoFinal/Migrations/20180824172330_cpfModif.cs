using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class cpfModif : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Funcionarios",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "CPF",
                table: "Clientes",
                newName: "Cpf");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Funcionarios",
                type: "VARCHAR(11)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "Clientes",
                type: "VARCHAR(11)",
                nullable: false,
                oldClrType: typeof(string));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Funcionarios",
                newName: "CPF");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "Clientes",
                newName: "CPF");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)");
        }
    }
}
