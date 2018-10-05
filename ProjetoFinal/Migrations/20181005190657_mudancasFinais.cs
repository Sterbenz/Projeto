using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class mudancasFinais : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataDaVenda",
                table: "LogCompras",
                newName: "DataDaCompra");

            migrationBuilder.AddColumn<double>(
                name: "ValorVenda",
                table: "LogVendas",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "ValorCompra",
                table: "LogCompras",
                nullable: false,
                defaultValue: 0.0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorVenda",
                table: "LogVendas");

            migrationBuilder.DropColumn(
                name: "ValorCompra",
                table: "LogCompras");

            migrationBuilder.RenameColumn(
                name: "DataDaCompra",
                table: "LogCompras",
                newName: "DataDaVenda");
        }
    }
}
