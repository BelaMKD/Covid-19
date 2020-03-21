using Microsoft.EntityFrameworkCore.Migrations;

namespace Data.Migrations
{
    public partial class ManytoManyDiagnosisViruses : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Viruses_Diagnoses_DiagnosisId",
                table: "Viruses");

            migrationBuilder.DropIndex(
                name: "IX_Viruses_DiagnosisId",
                table: "Viruses");

            migrationBuilder.DropColumn(
                name: "DiagnosisId",
                table: "Viruses");

            migrationBuilder.CreateTable(
                name: "DiagnosisVirus",
                columns: table => new
                {
                    DiagnosisId = table.Column<int>(nullable: false),
                    VirusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DiagnosisVirus", x => new { x.DiagnosisId, x.VirusId });
                    table.ForeignKey(
                        name: "FK_DiagnosisVirus_Diagnoses_DiagnosisId",
                        column: x => x.DiagnosisId,
                        principalTable: "Diagnoses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DiagnosisVirus_Viruses_VirusId",
                        column: x => x.VirusId,
                        principalTable: "Viruses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DiagnosisVirus_VirusId",
                table: "DiagnosisVirus",
                column: "VirusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DiagnosisVirus");

            migrationBuilder.AddColumn<int>(
                name: "DiagnosisId",
                table: "Viruses",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Viruses_DiagnosisId",
                table: "Viruses",
                column: "DiagnosisId");

            migrationBuilder.AddForeignKey(
                name: "FK_Viruses_Diagnoses_DiagnosisId",
                table: "Viruses",
                column: "DiagnosisId",
                principalTable: "Diagnoses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
