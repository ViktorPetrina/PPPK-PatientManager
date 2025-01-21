using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ExaminationTypeConstants : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Perescriptions",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Perescriptions", x => x.id);
                });

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
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Perescriptions");

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
        }
    }
}
