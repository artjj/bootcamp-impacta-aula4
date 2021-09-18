using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercicioEF.Migrations
{
    public partial class UpdateTableUser_AddCpf : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "User",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "User");
        }
    }
}
