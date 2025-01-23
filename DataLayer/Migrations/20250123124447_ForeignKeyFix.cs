using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_PatientId",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_type_id",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Gender_SexId",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "SexId",
                table: "Patients",
                newName: "sex_id");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_SexId",
                table: "Patients",
                newName: "IX_Patients_sex_id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Examinations",
                newName: "ExaminationType");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_type_id",
                table: "Examinations",
                newName: "IX_Examinations_ExaminationType");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_ExaminationType",
                table: "Examinations",
                column: "ExaminationType",
                principalTable: "ExaminationTypes",
                principalColumn: "id_examination_type");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Gender_sex_id",
                table: "Patients",
                column: "sex_id",
                principalTable: "Gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Diagnoses_Patients_patient_id",
                table: "Diagnoses");

            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_ExaminationType",
                table: "Examinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Gender_sex_id",
                table: "Patients");

            migrationBuilder.RenameColumn(
                name: "sex_id",
                table: "Patients",
                newName: "SexId");

            migrationBuilder.RenameIndex(
                name: "IX_Patients_sex_id",
                table: "Patients",
                newName: "IX_Patients_SexId");

            migrationBuilder.RenameColumn(
                name: "ExaminationType",
                table: "Examinations",
                newName: "type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_ExaminationType",
                table: "Examinations",
                newName: "IX_Examinations_type_id");

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

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_type_id",
                table: "Examinations",
                column: "type_id",
                principalTable: "ExaminationTypes",
                principalColumn: "id_examination_type");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Gender_SexId",
                table: "Patients",
                column: "SexId",
                principalTable: "Gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
