using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_JWT.Migrations
{
    public partial class InitialDatabase_TableUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TB_USER",
                columns: table => new
                {
                    ID_USER = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NM_USER = table.Column<string>(type: "varchar(100)", nullable: true),
                    CD_EMAIL = table.Column<string>(type: "varchar(60)", nullable: true),
                    CD_PASSWORD = table.Column<string>(type: "varchar(20)", nullable: true),
                    CD_PROFILE = table.Column<string>(type: "varchar(20)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TB_USER", x => x.ID_USER);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TB_USER");
        }
    }
}
