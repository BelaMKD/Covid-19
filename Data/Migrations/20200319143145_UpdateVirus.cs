using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class UpdateVirus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viruses_Diagnoses_DiagnosisId",
                table: "Viruses");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "Viruses",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Viruses_Diagnoses_DiagnosisId",
                table: "Viruses",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viruses_Diagnoses_DiagnosisId",
                table: "Viruses");

            migrationBuilder.AlterColumn<int>(
                name: "DiagnosisId",
                table: "Viruses",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Viruses_Diagnoses_DiagnosisId",
                table: "Viruses",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
