using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercicioEF.Migrations
{
    public partial class Create_Table_Cargo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_CARGO",
                columns: table => new
                {
                    ID_CARGO = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DESC_CARGO = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_CARGO", x => x.ID_CARGO);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_CARGO");
        }
    }
}
