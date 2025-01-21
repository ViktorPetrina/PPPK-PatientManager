using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class FirstDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_type",
                table: "Examinations");

            migrationBuilder.DropTable(
                name: "Ilnesses");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Patients",
                newName: "id_patient");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "ExaminationTypes",
                newName: "id_examination_type");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "Examinations",
                newName: "id_examination");

            migrationBuilder.RenameColumn(
                name: "type",
                table: "Examinations",
                newName: "type_id");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_type",
                table: "Examinations",
                newName: "IX_Examinations_type_id");

            migrationBuilder.AddColumn<byte[]>(
                name: "Image",
                table: "Examinations",
                type: "bytea",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Diagnoses",
                columns: table => new
                {
                    id_diagnosis = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: true),
                    start = table.Column<DateOnly>(type: "date", nullable: false),
                    end = table.Column<DateOnly>(type: "date", nullable: false),
                    patient_id = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diagnoses", x => x.id_diagnosis);
                    table.ForeignKey(
                        name: "FK_Diagnoses_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "id_patient");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Diagnoses_patient_id",
                table: "Diagnoses",
                column: "patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_type_id",
                table: "Examinations",
                column: "type_id",
                principalTable: "ExaminationTypes",
                principalColumn: "id_examination_type");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_type_id",
                table: "Examinations");

            migrationBuilder.DropTable(
                name: "Diagnoses");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Examinations");

            migrationBuilder.RenameColumn(
                name: "id_patient",
                table: "Patients",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "id_examination_type",
                table: "ExaminationTypes",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "id_examination",
                table: "Examinations",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "type_id",
                table: "Examinations",
                newName: "type");

            migrationBuilder.RenameIndex(
                name: "IX_Examinations_type_id",
                table: "Examinations",
                newName: "IX_Examinations_type");

            migrationBuilder.CreateTable(
                name: "Ilnesses",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    patient_id = table.Column<long>(type: "bigint", nullable: true),
                    diagnosis_end = table.Column<DateOnly>(type: "date", nullable: false),
                    diganosis_start = table.Column<DateOnly>(type: "date", nullable: false),
                    name = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ilnesses", x => x.id);
                    table.ForeignKey(
                        name: "FK_Ilnesses_Patients_patient_id",
                        column: x => x.patient_id,
                        principalTable: "Patients",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Ilnesses_patient_id",
                table: "Ilnesses",
                column: "patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_type",
                table: "Examinations",
                column: "type",
                principalTable: "ExaminationTypes",
                principalColumn: "id");
        }
    }
}
