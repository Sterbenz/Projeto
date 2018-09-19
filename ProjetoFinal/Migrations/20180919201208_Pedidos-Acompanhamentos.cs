using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class PedidosAcompanhamentos : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pedidos_Fornecedores_FornecedorId",
                table: "Pedidos");

            migrationBuilder.DropIndex(
                name: "IX_Pedidos_FornecedorId",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "DataEntrega",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "Entregue",
                table: "Pedidos");

            migrationBuilder.DropColumn(
                name: "FornecedorId",
                table: "Pedidos");

            migrationBuilder.AddColumn<bool>(
                name: "Entregue",
                table: "Acompanhamentos",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Entregue",
                table: "Acompanhamentos");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataEntrega",
                table: "Pedidos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<bool>(
                name: "Entregue",
                table: "Pedidos",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "FornecedorId",
                table: "Pedidos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pedidos_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pedidos_Fornecedores_FornecedorId",
                table: "Pedidos",
                column: "FornecedorId",
                principalTable: "Fornecedores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
