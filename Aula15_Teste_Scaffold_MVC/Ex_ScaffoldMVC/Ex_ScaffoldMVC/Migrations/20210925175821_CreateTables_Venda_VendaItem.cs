using Microsoft.EntityFrameworkCore.Migrations;

namespace Ex_ScaffoldMVC.Migrations
{
    public partial class CreateTables_Venda_VendaItem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_VENDA",
                columns: table => new
                {
                    ID_VENDA = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false),
                    VLR_TOTAL = table.Column<decimal>(type: "decimal(10,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA", x => x.ID_VENDA);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_TB_USUARIO_ID_USUARIO",
                        column: x => x.ID_USUARIO,
                        principalTable: "TB_USUARIO",
                        principalColumn: "ID_USUARIO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TB_VENDA_ITEM",
                columns: table => new
                {
                    ID_VENDA_ITEM = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_VENDA = table.Column<int>(type: "int", nullable: false),
                    ID_PRODUTO = table.Column<int>(type: "int", nullable: false),
                    QTD_ITEM = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_VENDA_ITEM", x => x.ID_VENDA_ITEM);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_ITEM_TB_PRODUTO_ID_PRODUTO",
                        column: x => x.ID_PRODUTO,
                        principalTable: "TB_PRODUTO",
                        principalColumn: "ID_PRODUTO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_VENDA_ITEM_TB_VENDA_ID_VENDA",
                        column: x => x.ID_VENDA,
                        principalTable: "TB_VENDA",
                        principalColumn: "ID_VENDA",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_ID_USUARIO",
                table: "TB_VENDA",
                column: "ID_USUARIO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_ITEM_ID_PRODUTO",
                table: "TB_VENDA_ITEM",
                column: "ID_PRODUTO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_VENDA_ITEM_ID_VENDA",
                table: "TB_VENDA_ITEM",
                column: "ID_VENDA");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_VENDA_ITEM");

            migrationBuilder.DropTable(
                name: "TB_VENDA");
        }
    }
}
