using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Migrations
{
    public partial class altercolumnname : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobId",
                table: "JobTasks",
                newName: "JobEntityId");

            migrationBuilder.AlterColumn<string>(
                name: "Shift2",
                table: "Machines",
                type: "nvarchar(50)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "invarchar(50)nt",
                oldNullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "JobEntityId",
                table: "JobTasks",
                newName: "JobId");

            migrationBuilder.AlterColumn<string>(
                name: "Shift2",
                table: "Machines",
                type: "invarchar(50)nt",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldNullable: true);
        }
    }
}
