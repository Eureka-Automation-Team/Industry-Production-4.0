using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Migrations
{
    public partial class AddCameraSettingtable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_Machines_MachineId",
                table: "JobTasks");

            migrationBuilder.CreateTable(
                name: "CameraSetting",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CameraCode = table.Column<int>(nullable: false),
                    CameraUrl = table.Column<string>(nullable: true),
                    Port = table.Column<int>(nullable: false),
                    Username = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CameraSetting", x => x.Id);
                });

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_MachinesMaster_MachineId",
                table: "JobTasks",
                column: "MachineId",
                principalTable: "MachinesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_MachinesMaster_MachineId",
                table: "JobTasks");

            migrationBuilder.DropTable(
                name: "CameraSetting");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_Machines_MachineId",
                table: "JobTasks",
                column: "MachineId",
                principalTable: "MachinesMaster",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
