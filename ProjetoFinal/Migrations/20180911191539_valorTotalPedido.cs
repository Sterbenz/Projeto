using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class valorTotalPedido : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContadoDoResponsavel",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "FuncaoDoResponsavel",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "InscriçãoEstadual",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "Observacoes",
                table: "Fornecedores");

            migrationBuilder.DropColumn(
                name: "RamoDeAtividade",
                table: "Fornecedores");

            migrationBuilder.AddColumn<int>(
                name: "ValorTotal",
                table: "Pedidos",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ValorTotal",
                table: "Pedidos");

            migrationBuilder.AddColumn<string>(
                name: "ContadoDoResponsavel",
                table: "Fornecedores",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FuncaoDoResponsavel",
                table: "Fornecedores",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "InscriçãoEstadual",
                table: "Fornecedores",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Observacoes",
                table: "Fornecedores",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RamoDeAtividade",
                table: "Fornecedores",
                nullable: false,
                defaultValue: "");
        }
    }
}
