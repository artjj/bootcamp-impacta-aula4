using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercicioEF.Migrations
{
    public partial class AddTable_User_Cargo_Constraint : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER_CARGO",
                columns: table => new
                {
                    ID_USER_CARGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ID_CARGO = table.Column<int>(type: "int", nullable: false),
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER_CARGO", x => x.ID_USER_CARGO);
                    table.ForeignKey(
                        name: "FK_TB_USER_CARGO_TB_CARGO_ID_CARGO",
                        column: x => x.ID_CARGO,
                        principalTable: "TB_CARGO",
                        principalColumn: "ID_CARGO",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TB_USER_CARGO_TB_USER_ID_USER",
                        column: x => x.ID_USER,
                        principalTable: "TB_USER",
                        principalColumn: "ID_USER",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_CARGO_ID_CARGO",
                table: "TB_USER_CARGO",
                column: "ID_CARGO");

            migrationBuilder.CreateIndex(
                name: "IX_TB_USER_CARGO_ID_USER",
                table: "TB_USER_CARGO",
                column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER_CARGO");
        }
    }
}
