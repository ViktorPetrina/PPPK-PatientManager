using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class PatientSexIdFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Gender_sex_id",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_sex_id",
                table: "Patients");

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 2L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 7L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 8L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 9L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 10L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 11L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 12L);

            migrationBuilder.DeleteData(
                table: "ExaminationTypes",
                keyColumn: "id_examination_type",
                keyValue: 13L);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Gender",
                keyColumn: "id",
                keyValue: 2L);

            migrationBuilder.DropColumn(
                name: "sex_id",
                table: "Patients");

            migrationBuilder.AddColumn<long>(
                name: "SexId",
                table: "Patients",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Patients_SexId",
                table: "Patients",
                column: "SexId");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Gender_SexId",
                table: "Patients",
                column: "SexId",
                principalTable: "Gender",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Patients_Gender_SexId",
                table: "Patients");

            migrationBuilder.DropIndex(
                name: "IX_Patients_SexId",
                table: "Patients");

            migrationBuilder.DropColumn(
                name: "SexId",
                table: "Patients");

            migrationBuilder.AddColumn<long>(
                name: "sex_id",
                table: "Patients",
                type: "bigint",
                nullable: true);

            migrationBuilder.InsertData(
                table: "ExaminationTypes",
                columns: new[] { "id_examination_type", "code", "name" },
                values: new object[,]
                {
                    { 1L, "GP", "General physical exam" },
                    { 2L, "KRV", "Blood test" },
                    { 3L, "X-RAY", "X-ray scan" },
                    { 4L, "CT", "CT scan" },
                    { 5L, "MR", "MRI scan" },
                    { 6L, "ULTRA", "Ultrasound" },
                    { 7L, "EKG", "Electrocardiogram" },
                    { 8L, "ECHO", "Echocardiogram" },
                    { 9L, "EYE", "Eye exam" },
                    { 10L, "DERM", "Dermatology exam" },
                    { 11L, "DENTA", "Dental exam" },
                    { 12L, "MAMMO", "Mammogram" },
                    { 13L, "NEURO", "Neurology exam" }
                });

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "id", "sex" },
                values: new object[,]
                {
                    { 1L, 'M' },
                    { 2L, 'F' }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Patients_sex_id",
                table: "Patients",
                column: "sex_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Gender_sex_id",
                table: "Patients",
                column: "sex_id",
                principalTable: "Gender",
                principalColumn: "id");
        }
    }
}
