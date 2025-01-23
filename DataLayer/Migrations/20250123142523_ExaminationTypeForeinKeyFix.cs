using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DataLayer.Migrations
{
    /// <inheritdoc />
    public partial class ExaminationTypeForeinKeyFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_ExaminationType",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_ExaminationType",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "ExaminationType",
                table: "Examinations");

            migrationBuilder.AddColumn<long>(
                name: "type_id",
                table: "Examinations",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_type_id",
                table: "Examinations",
                column: "type_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_type_id",
                table: "Examinations",
                column: "type_id",
                principalTable: "ExaminationTypes",
                principalColumn: "id_examination_type",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Examinations_ExaminationTypes_type_id",
                table: "Examinations");

            migrationBuilder.DropIndex(
                name: "IX_Examinations_type_id",
                table: "Examinations");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "Examinations");

            migrationBuilder.AddColumn<long>(
                name: "ExaminationType",
                table: "Examinations",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Examinations_ExaminationType",
                table: "Examinations",
                column: "ExaminationType");

            migrationBuilder.AddForeignKey(
                name: "FK_Examinations_ExaminationTypes_ExaminationType",
                table: "Examinations",
                column: "ExaminationType",
                principalTable: "ExaminationTypes",
                principalColumn: "id_examination_type");
        }
    }
}
