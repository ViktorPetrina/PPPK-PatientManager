using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class DiagnosisPatientIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_patient_id",
                table: "Diagnoses");

            migrationBuilder.RenameColumn(
                name: "patient_id",
                table: "Diagnoses",
                newName: "PatientId");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_patient_id",
                table: "Diagnoses",
                newName: "IX_Diagnoses_PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses",
                column: "PatientId",
                principalTable: "Patients",
                principalColumn: "id_patient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.RenameColumn(
                name: "PatientId",
                table: "Diagnoses",
                newName: "patient_id");

            migrationBuilder.RenameIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                newName: "IX_Diagnoses_patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Diagnoses_Patients_patient_id",
                table: "Diagnoses",
                column: "patient_id",
                principalTable: "Patients",
                principalColumn: "id_patient",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
