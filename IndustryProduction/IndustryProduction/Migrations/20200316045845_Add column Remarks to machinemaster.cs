using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Migrations
{
    public partial class AddcolumnRemarkstomachinemaster : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Remarks",
                table: "Machines",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_MachineWorkings_ShiftId",
                table: "MachineWorkings",
                column: "ShiftId");

            migrationBuilder.AddForeignKey(
                name: "FK_MachineWorkings_WorkingShifts_ShiftId",
                table: "MachineWorkings",
                column: "ShiftId",
                principalTable: "WorkingShifts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MachineWorkings_WorkingShifts_ShiftId",
                table: "MachineWorkings");

            migrationBuilder.DropIndex(
                name: "IX_MachineWorkings_ShiftId",
                table: "MachineWorkings");

            migrationBuilder.DropColumn(
                name: "Remarks",
                table: "Machines");
        }
    }
}
