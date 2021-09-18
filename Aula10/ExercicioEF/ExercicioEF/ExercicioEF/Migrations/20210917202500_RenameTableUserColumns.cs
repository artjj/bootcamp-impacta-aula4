using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExercicioEF.Migrations
{
    public partial class RenameTableUserColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "TB_USER");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TB_USER",
                newName: "NM_USER");

            migrationBuilder.RenameColumn(
                name: "DataNascimento",
                table: "TB_USER",
                newName: "DT_NASC");

            migrationBuilder.RenameColumn(
                name: "Cpf",
                table: "TB_USER",
                newName: "DS_CPF");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "TB_USER",
                newName: "ID_USER");

            migrationBuilder.AlterColumn<string>(
                name: "NM_USER",
                table: "TB_USER",
                type: "VARCHAR(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DT_NASC",
                table: "TB_USER",
                type: "DATE",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<string>(
                name: "DS_CPF",
                table: "TB_USER",
                type: "VARCHAR(11)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TB_USER",
                table: "TB_USER",
                column: "ID_USER");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_TB_USER",
                table: "TB_USER");

            migrationBuilder.RenameTable(
                name: "TB_USER",
                newName: "User");

            migrationBuilder.RenameColumn(
                name: "NM_USER",
                table: "User",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "DT_NASC",
                table: "User",
                newName: "DataNascimento");

            migrationBuilder.RenameColumn(
                name: "DS_CPF",
                table: "User",
                newName: "Cpf");

            migrationBuilder.RenameColumn(
                name: "ID_USER",
                table: "User",
                newName: "Id");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DataNascimento",
                table: "User",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "DATE");

            migrationBuilder.AlterColumn<string>(
                name: "Cpf",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "VARCHAR(11)",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");
        }
    }
}
