using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Data.Migrations
{
    public partial class StartWeb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FndRoleClaims_FndRoles_RoleId",
                table: "FndRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_FndUserClaims_FndUsers_UserId",
                table: "FndUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_FndUserLogins_FndUsers_UserId",
                table: "FndUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_FndUserRoles_FndRoles_RoleId",
                table: "FndUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_FndUserRoles_FndUsers_UserId",
                table: "FndUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_FndUserTokens_FndUsers_UserId",
                table: "FndUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndUserTokens",
                table: "FndUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndUsers",
                table: "FndUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndUserRoles",
                table: "FndUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndUserLogins",
                table: "FndUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndUserClaims",
                table: "FndUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndRoles",
                table: "FndRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FndRoleClaims",
                table: "FndRoleClaims");

            migrationBuilder.RenameTable(
                name: "FndUserTokens",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "FndUsers",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "FndUserRoles",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "FndUserLogins",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "FndUserClaims",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "FndRoles",
                newName: "AspNetRoles");

            migrationBuilder.RenameTable(
                name: "FndRoleClaims",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_FndUserRoles_RoleId",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_FndUserLogins_UserId",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FndUserClaims_UserId",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_FndRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "FndUserTokens");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "FndUsers");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "FndUserRoles");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "FndUserLogins");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "FndUserClaims");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "FndRoles");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "FndRoleClaims");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "FndUserRoles",
                newName: "IX_FndUserRoles_RoleId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "FndUserLogins",
                newName: "IX_FndUserLogins_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "FndUserClaims",
                newName: "IX_FndUserClaims_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "FndRoleClaims",
                newName: "IX_FndRoleClaims_RoleId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndUserTokens",
                table: "FndUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndUsers",
                table: "FndUsers",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndUserRoles",
                table: "FndUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndUserLogins",
                table: "FndUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndUserClaims",
                table: "FndUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndRoles",
                table: "FndRoles",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FndRoleClaims",
                table: "FndRoleClaims",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FndRoleClaims_FndRoles_RoleId",
                table: "FndRoleClaims",
                column: "RoleId",
                principalTable: "FndRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FndUserClaims_FndUsers_UserId",
                table: "FndUserClaims",
                column: "UserId",
                principalTable: "FndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FndUserLogins_FndUsers_UserId",
                table: "FndUserLogins",
                column: "UserId",
                principalTable: "FndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FndUserRoles_FndRoles_RoleId",
                table: "FndUserRoles",
                column: "RoleId",
                principalTable: "FndRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FndUserRoles_FndUsers_UserId",
                table: "FndUserRoles",
                column: "UserId",
                principalTable: "FndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FndUserTokens_FndUsers_UserId",
                table: "FndUserTokens",
                column: "UserId",
                principalTable: "FndUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
