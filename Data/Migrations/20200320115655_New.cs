using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class New : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisVirus_Diagnoses_DiagnosisId",
                table: "DiagnosisVirus");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisVirus_Viruses_VirusId",
                table: "DiagnosisVirus");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagnosisVirus",
                table: "DiagnosisVirus");

            migrationBuilder.RenameTable(
                name: "DiagnosisVirus",
                newName: "DiagnosisViruses");

            migrationBuilder.RenameIndex(
                name: "IX_DiagnosisVirus_VirusId",
                table: "DiagnosisViruses",
                newName: "IX_DiagnosisViruses_VirusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagnosisViruses",
                table: "DiagnosisViruses",
                columns: new[] { "DiagnosisId", "VirusId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisViruses_Diagnoses_DiagnosisId",
                table: "DiagnosisViruses",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisViruses_Viruses_VirusId",
                table: "DiagnosisViruses",
                column: "VirusId",
                principalTable: "Viruses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisViruses_Diagnoses_DiagnosisId",
                table: "DiagnosisViruses");

            migrationBuilder.DropForeignKey(
                name: "FK_DiagnosisViruses_Viruses_VirusId",
                table: "DiagnosisViruses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_DiagnosisViruses",
                table: "DiagnosisViruses");

            migrationBuilder.RenameTable(
                name: "DiagnosisViruses",
                newName: "DiagnosisVirus");

            migrationBuilder.RenameIndex(
                name: "IX_DiagnosisViruses_VirusId",
                table: "DiagnosisVirus",
                newName: "IX_DiagnosisVirus_VirusId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_DiagnosisVirus",
                table: "DiagnosisVirus",
                columns: new[] { "DiagnosisId", "VirusId" });

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisVirus_Diagnoses_DiagnosisId",
                table: "DiagnosisVirus",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_DiagnosisVirus_Viruses_VirusId",
                table: "DiagnosisVirus",
                column: "VirusId",
                principalTable: "Viruses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
