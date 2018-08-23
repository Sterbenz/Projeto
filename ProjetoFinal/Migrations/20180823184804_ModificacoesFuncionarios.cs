using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class ModificacoesFuncionarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionario_TipoPessoas_TipoPessoaID",
                table: "Funcionario");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginFuncionarios_Funcionario_FuncionarioId",
                table: "LoginFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_LogPessoas_Cliente_PessoaId",
                table: "LogPessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProdutos_Cliente_PessoaId",
                table: "LogProdutos");

            migrationBuilder.DropTable(
                name: "TipoPessoas");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente");

            migrationBuilder.RenameTable(
                name: "Funcionario",
                newName: "Funcionarios");

            migrationBuilder.RenameTable(
                name: "Cliente",
                newName: "Clientes");

            migrationBuilder.RenameColumn(
                name: "TipoPessoaID",
                table: "Funcionarios",
                newName: "CargoID");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionario_TipoPessoaID",
                table: "Funcionarios",
                newName: "IX_Funcionarios_CargoID");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(nullable: false),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionarios_Cargos_CargoID",
                table: "Funcionarios",
                column: "CargoID",
                principalTable: "Cargos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginFuncionarios_Funcionarios_FuncionarioId",
                table: "LoginFuncionarios",
                column: "FuncionarioId",
                principalTable: "Funcionarios",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogPessoas_Clientes_PessoaId",
                table: "LogPessoas",
                column: "PessoaId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogProdutos_Clientes_PessoaId",
                table: "LogProdutos",
                column: "PessoaId",
                principalTable: "Clientes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Funcionarios_Cargos_CargoID",
                table: "Funcionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_LoginFuncionarios_Funcionarios_FuncionarioId",
                table: "LoginFuncionarios");

            migrationBuilder.DropForeignKey(
                name: "FK_LogPessoas_Clientes_PessoaId",
                table: "LogPessoas");

            migrationBuilder.DropForeignKey(
                name: "FK_LogProdutos_Clientes_PessoaId",
                table: "LogProdutos");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Funcionarios",
                table: "Funcionarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Clientes",
                table: "Clientes");

            migrationBuilder.RenameTable(
                name: "Funcionarios",
                newName: "Funcionario");

            migrationBuilder.RenameTable(
                name: "Clientes",
                newName: "Cliente");

            migrationBuilder.RenameColumn(
                name: "CargoID",
                table: "Funcionario",
                newName: "TipoPessoaID");

            migrationBuilder.RenameIndex(
                name: "IX_Funcionarios_CargoID",
                table: "Funcionario",
                newName: "IX_Funcionario_TipoPessoaID");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Funcionario",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Funcionario",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Funcionario",
                table: "Funcionario",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cliente",
                table: "Cliente",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TipoPessoas",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true),
                    Nome = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoPessoas", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Funcionario_TipoPessoas_TipoPessoaID",
                table: "Funcionario",
                column: "TipoPessoaID",
                principalTable: "TipoPessoas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoginFuncionarios_Funcionario_FuncionarioId",
                table: "LoginFuncionarios",
                column: "FuncionarioId",
                principalTable: "Funcionario",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogPessoas_Cliente_PessoaId",
                table: "LogPessoas",
                column: "PessoaId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LogProdutos_Cliente_PessoaId",
                table: "LogProdutos",
                column: "PessoaId",
                principalTable: "Cliente",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
