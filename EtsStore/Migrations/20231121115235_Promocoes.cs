using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EtsStore.Migrations
{
    /// <inheritdoc />
    public partial class Promocoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "PromocaoId",
                table: "Produtos");

            migrationBuilder.CreateTable(
                name: "ProdutoPromocao",
                columns: table => new
                {
                    ProdutosId = table.Column<int>(type: "int", nullable: false),
                    PromocoesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProdutoPromocao", x => new { x.ProdutosId, x.PromocoesId });
                    table.ForeignKey(
                        name: "FK_ProdutoPromocao_Produtos_ProdutosId",
                        column: x => x.ProdutosId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProdutoPromocao_Promocoes_PromocoesId",
                        column: x => x.PromocoesId,
                        principalTable: "Promocoes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ProdutoPromocao_PromocoesId",
                table: "ProdutoPromocao",
                column: "PromocoesId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProdutoPromocao");

            migrationBuilder.AddColumn<int>(
                name: "PromocaoId",
                table: "Produtos",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_PromocaoId",
                table: "Produtos",
                column: "PromocaoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Promocoes_PromocaoId",
                table: "Produtos",
                column: "PromocaoId",
                principalTable: "Promocoes",
                principalColumn: "Id");
        }
    }
}
