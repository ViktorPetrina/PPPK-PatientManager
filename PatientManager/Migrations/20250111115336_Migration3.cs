using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PatientManager.Migrations
{
    /// <inheritdoc />
    public partial class Migration3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_patient_patient_PatientId",
                table: "patient");

            migrationBuilder.DropIndex(
                name: "IX_patient_PatientId",
                table: "patient");

            migrationBuilder.DropColumn(
                name: "PatientId",
                table: "patient");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "PatientId",
                table: "patient",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_patient_PatientId",
                table: "patient",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_patient_patient_PatientId",
                table: "patient",
                column: "PatientId",
                principalTable: "patient",
                principalColumn: "id");
        }
    }
}
