using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class HailMarry : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ExaminationTypes",
                columns: table => new
                {
                    id_examination_type = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ExaminationTypes", x => x.id_examination_type);
                });

            migrationBuilder.CreateTable(
                name: "Gender",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    sex = table.Column<char>(type: "character(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gender", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "Patients",
                columns: table => new
                {
                    id_patient = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    first_name = table.Column<string>(type: "text", nullable: true),
                    last_name = table.Column<string>(type: "text", nullable: true),
                    sex_id = table.Column<long>(type: "bigint", nullable: true),
                    date_of_birth = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    oib = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Patients", x => x.id_patient);
                    table.ForeignKey(
                        name: "FK_Patients_Gender_sex_id",
                        column: x => x.sex_id,
                        principalTable: "Gender",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    id_diagnosis = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    start = table.Column<DateOnly>(type: "date", nullable: false),
                    end = table.Column<DateOnly>(type: "date", nullable: true),
                    PatientId = table.Column<long>(type: "bigint", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.id_diagnosis);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "id_patient",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Examinations",
                columns: table => new
                {
                    id_examination = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<long>(type: "bigint", nullable: true),
                    date = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    type_id = table.Column<long>(type: "bigint", nullable: true),
                    Image = table.Column<byte[]>(type: "bytea", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Examinations", x => x.id_examination);
                    table.ForeignKey(
                        name: "FK_Examinations_ExaminationTypes_type_id",
                        column: x => x.type_id,
                        principalTable: "ExaminationTypes",
                        principalColumn: "id_examination_type");
                    table.ForeignKey(
                        name: "FK_Examinations_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "id_patient");
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

            migrationBuilder.InsertData(
                table: "Gender",
                columns: new[] { "id", "sex" },
                values: new object[,]
                {
                    { 1L, 'M' },
                    { 2L, 'F' }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_PatientId",
                table: "Diagnoses",
                column: "PatientId");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_patient_id",
                table: "Examinations",
                column: "patient_id");

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_type_id",
                table: "Examinations",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "IX_Patients_sex_id",
                table: "Patients",
                column: "sex_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropTable(
                name: "Examinations");

            migrationBuilder.DropTable(
                name: "Perescriptions");

            migrationBuilder.DropTable(
                name: "ExaminationTypes");

            migrationBuilder.DropTable(
                name: "Patients");

            migrationBuilder.DropTable(
                name: "Gender");
        }
    }
}
