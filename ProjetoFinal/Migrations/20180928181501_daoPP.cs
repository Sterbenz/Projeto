using Microsoft.EntityFrameworkCore.Migrations;

namespace ProjetoFinal.Migrations
{
    public partial class daoPP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Pedidos_PedidoId",
                table: "PedidoProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidoProdutos_Produtos_ProdutoId",
                table: "PedidoProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos");

            migrationBuilder.RenameTable(
                name: "PedidoProdutos",
                newName: "PedidosProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_PedidoProdutos_ProdutoId",
                table: "PedidosProdutos",
                newName: "IX_PedidosProdutos_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidosProdutos",
                table: "PedidosProdutos",
                columns: new[] { "PedidoId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosProdutos_Pedidos_PedidoId",
                table: "PedidosProdutos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidosProdutos_Produtos_ProdutoId",
                table: "PedidosProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PedidosProdutos_Pedidos_PedidoId",
                table: "PedidosProdutos");

            migrationBuilder.DropForeignKey(
                name: "FK_PedidosProdutos_Produtos_ProdutoId",
                table: "PedidosProdutos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PedidosProdutos",
                table: "PedidosProdutos");

            migrationBuilder.RenameTable(
                name: "PedidosProdutos",
                newName: "PedidoProdutos");

            migrationBuilder.RenameIndex(
                name: "IX_PedidosProdutos_ProdutoId",
                table: "PedidoProdutos",
                newName: "IX_PedidoProdutos_ProdutoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PedidoProdutos",
                table: "PedidoProdutos",
                columns: new[] { "PedidoId", "ProdutoId" });

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Pedidos_PedidoId",
                table: "PedidoProdutos",
                column: "PedidoId",
                principalTable: "Pedidos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PedidoProdutos_Produtos_ProdutoId",
                table: "PedidoProdutos",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
