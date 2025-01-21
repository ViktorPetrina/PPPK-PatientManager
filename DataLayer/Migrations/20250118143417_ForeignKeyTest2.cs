using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeyTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Gender_sex_id",
                table: "Patients",
                column: "sex_id",
                principalTable: "Gender",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddForeignKey(
                name: "FK_Patients_Gender_SexId",
                table: "Patients",
                column: "SexId",
                principalTable: "Gender",
                principalColumn: "id");
        }
    }
}
