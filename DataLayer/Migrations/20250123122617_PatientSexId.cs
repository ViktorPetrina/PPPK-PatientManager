using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class PatientSexId : Migration
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
