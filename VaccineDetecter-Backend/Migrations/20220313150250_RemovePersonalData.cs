using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccineDetecter_Backend.Migrations
{
    public partial class RemovePersonalData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Persons_PersonId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "NationalId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "MobileNumber",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Persons_PersonId",
                table: "Tests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "Email",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Tests_Persons_PersonId",
                table: "Tests");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Persons",
                table: "Persons");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "NationalId",
                table: "Persons",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "MobileNumber",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Persons",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Persons",
                table: "Persons",
                column: "NationalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Tests_Persons_PersonId",
                table: "Tests",
                column: "PersonId",
                principalTable: "Persons",
                principalColumn: "NationalId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
