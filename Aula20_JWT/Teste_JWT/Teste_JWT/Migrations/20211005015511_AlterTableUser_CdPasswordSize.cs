using Microsoft.EntityFrameworkCore.Migrations;

namespace Teste_JWT.Migrations
{
    public partial class AlterTableUser_CdPasswordSize : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CD_PASSWORD",
                table: "TB_USER",
                type: "varchar(60)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "CD_PASSWORD",
                table: "TB_USER",
                type: "varchar(20)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(60)",
                oldNullable: true);
        }
    }
}
