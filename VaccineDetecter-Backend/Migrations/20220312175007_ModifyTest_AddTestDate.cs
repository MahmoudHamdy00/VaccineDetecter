using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VaccineDetecter_Backend.Migrations
{
    public partial class ModifyTest_AddTestDate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "TestDate",
                table: "Tests",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TestDate",
                table: "Tests");
        }
    }
}
