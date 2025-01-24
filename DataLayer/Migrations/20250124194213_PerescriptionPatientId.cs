using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class PerescriptionPatientId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "patient_id",
                table: "Perescriptions",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<DateOnly>(
                name: "start",
                table: "Perescriptions",
                type: "date",
                nullable: false,
                defaultValue: new DateOnly(1, 1, 1));

            migrationBuilder.CreateIndex(
                name: "IX_Perescriptions_patient_id",
                table: "Perescriptions",
                column: "patient_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Perescriptions_Patients_patient_id",
                table: "Perescriptions",
                column: "patient_id",
                principalTable: "Patients",
                principalColumn: "id_patient",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Perescriptions_Patients_patient_id",
                table: "Perescriptions");

            migrationBuilder.DropIndex(
                name: "IX_Perescriptions_patient_id",
                table: "Perescriptions");

            migrationBuilder.DropColumn(
                name: "patient_id",
                table: "Perescriptions");

            migrationBuilder.DropColumn(
                name: "start",
                table: "Perescriptions");
        }
    }
}
