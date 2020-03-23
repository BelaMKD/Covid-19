using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class Add_IsPositive : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsPositive",
                table: "Diagnoses",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsPositive",
                table: "Diagnoses");
        }
    }
}
