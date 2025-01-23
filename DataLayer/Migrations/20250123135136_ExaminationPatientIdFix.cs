using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ExaminationPatientIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Patients_patient_id",
                table: "Examinations");

            migrationBuilder.AlterColumn<long>(
                name: "patient_id",
                table: "Examinations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L,
                oldClrType: typeof(long),
                oldType: "bigint",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Patients_patient_id",
                table: "Examinations",
                column: "patient_id",
                principalTable: "Patients",
                principalColumn: "id_patient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_Patients_patient_id",
                table: "Examinations");

            migrationBuilder.AlterColumn<long>(
                name: "patient_id",
                table: "Examinations",
                type: "bigint",
                nullable: true,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_Patients_patient_id",
                table: "Examinations",
                column: "patient_id",
                principalTable: "Patients",
                principalColumn: "id_patient");
        }
    }
}
