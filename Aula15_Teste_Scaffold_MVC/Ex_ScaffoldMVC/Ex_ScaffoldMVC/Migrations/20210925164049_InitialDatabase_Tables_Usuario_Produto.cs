using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Ex_ScaffoldMVC.Migrations
{
    public partial class InitialDatabase_Tables_Usuario_Produto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_PRODUTO",
                columns: table => new
                {
                    ID_PRODUTO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_PRODUTO = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    VLR_PRODUTO = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    DT_VALIDADE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_PRODUTO", x => x.ID_PRODUTO);
                });

            migrationBuilder.CreateTable(
                name: "TB_USUARIO",
                columns: table => new
                {
                    ID_USUARIO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_USUARIO = table.Column<string>(type: "VARCHAR(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USUARIO", x => x.ID_USUARIO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_PRODUTO");

            migrationBuilder.DropTable(
                name: "TB_USUARIO");
        }
    }
}
