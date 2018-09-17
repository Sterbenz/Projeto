using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class LogsUpgrade : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "LogProdutos",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "LogPessoas",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "LogFornecedores",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "DataModificacao",
                table: "LogFamilias",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "LogProdutos");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "LogPessoas");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "LogFornecedores");

            migrationBuilder.DropColumn(
                name: "DataModificacao",
                table: "LogFamilias");
        }
    }
}
