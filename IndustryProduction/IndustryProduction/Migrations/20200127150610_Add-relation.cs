using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Migrations
{
    public partial class Addrelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobEntityId",
                table: "JobTasks",
                column: "JobEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_JobTasks_JobEntities_JobEntityId",
                table: "JobTasks",
                column: "JobEntityId",
                principalTable: "JobEntities",
                principalColumn: "JobEntityId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JobTasks_JobEntities_JobEntityId",
                table: "JobTasks");

            migrationBuilder.DropIndex(
                name: "IX_JobTasks_JobEntityId",
                table: "JobTasks");
        }
    }
}
