using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Project.Migrations.TimeTableDb
{
    /// <inheritdoc />
    public partial class ff : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_TimeTables_TimeTableId",
                table: "TimeSlots");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_TimeTables_TimeTableId",
                table: "TimeSlots",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_TimeTables_TimeTableId",
                table: "TimeSlots");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_TimeTables_TimeTableId",
                table: "TimeSlots",
                column: "TimeTableId",
                principalTable: "TimeTables",
                principalColumn: "Id");
        }
    }
}
