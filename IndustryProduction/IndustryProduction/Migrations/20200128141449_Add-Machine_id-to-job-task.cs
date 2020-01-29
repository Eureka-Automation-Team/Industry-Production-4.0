using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Migrations
{
    public partial class AddMachine_idtojobtask : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MachineId",
                table: "JobTasks",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_MachineId",
                table: "JobTasks",
                column: "MachineId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Machines_MachineId",
                table: "JobTasks",
                column: "MachineId",
                principalTable: "Machines",
                principalColumn: "MachineId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Machines_MachineId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_MachineId",
                table: "JobTasks");

            migrationBuilder.DropColumn(
                name: "MachineId",
                table: "JobTasks");
        }
    }
}
