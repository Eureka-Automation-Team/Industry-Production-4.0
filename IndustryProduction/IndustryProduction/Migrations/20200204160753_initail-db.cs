using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace IndustryProduction.Migrations
{
    public partial class initaildb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    ApproverId = table.Column<int>(nullable: false),
                    LegacyUserId = table.Column<int>(nullable: false),
                    SignatureImg = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JobEntities",
                columns: table => new
                {
                    JobEntityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrganizationId = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    JobEntityName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    JobEntiryDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    EntityType = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(nullable: true),
                    PrimaryItemId = table.Column<int>(type: "int", nullable: false),
                    PrimaryItemCode = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PrimaryItemModel = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    PrimaryQuantity = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    Segment1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Segment2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Segment3 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Segment4 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Segment5 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    OpenStatus = table.Column<bool>(type: "bit", nullable: false),
                    ProcessFlag = table.Column<bool>(type: "bit", nullable: false),
                    CompletedFlag = table.Column<bool>(type: "bit", nullable: false),
                    CancelFlag = table.Column<bool>(type: "bit", nullable: false),
                    PoLineId = table.Column<int>(type: "int", nullable: false),
                    PoHeaderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobEntities", x => x.JobEntityId);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    MachineId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MachineCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    IpAddress = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PortNumber = table.Column<int>(type: "int", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    EnableFlag = table.Column<string>(type: "char(1)", nullable: false),
                    ActiveFlag = table.Column<string>(type: "char(1)", nullable: false),
                    MacType = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MacGroup = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ProductionLine = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PlantId = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MacModel = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Shift1 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Shift2 = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ShiftOT = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    CalendarId = table.Column<int>(type: "int", nullable: false),
                    MacStartTime = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    MacEndTime = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    WorkingHr = table.Column<int>(type: "int", nullable: false),
                    Mon = table.Column<int>(type: "int", nullable: false),
                    Tue = table.Column<int>(type: "int", nullable: false),
                    Wed = table.Column<int>(type: "int", nullable: false),
                    Thu = table.Column<int>(type: "int", nullable: false),
                    Fri = table.Column<int>(type: "int", nullable: false),
                    Sat = table.Column<int>(type: "int", nullable: false),
                    Sun = table.Column<int>(type: "int", nullable: false),
                    LunchHr = table.Column<int>(type: "int", nullable: false),
                    STimeLunchHr = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ETimeLunchHr = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaintenaneTime = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.MachineId);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "JobTasks",
                columns: table => new
                {
                    TaskId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TaskSeq = table.Column<int>(type: "int", nullable: false),
                    TaskNumber = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    JobNumber = table.Column<string>(type: "nvarchar(25)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Manager = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CancelFlag = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ErrorText = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    ReadyFlag = table.Column<bool>(type: "bit", nullable: false),
                    ReleaseFlag = table.Column<bool>(type: "bit", nullable: false),
                    UploadNcfileFlag = table.Column<bool>(type: "bit", nullable: false),
                    TransferNCFileToMachineFlag = table.Column<bool>(type: "bit", nullable: false),
                    TransferMessage = table.Column<string>(nullable: true),
                    Source = table.Column<string>(nullable: true),
                    ShelfNumber = table.Column<string>(nullable: true),
                    ReserveShelfFlag = table.Column<bool>(type: "bit", nullable: false),
                    OnShelfFlag = table.Column<bool>(type: "bit", nullable: false),
                    McProcessFlag = table.Column<bool>(type: "bit", nullable: false),
                    McPickFlag = table.Column<bool>(type: "bit", nullable: false),
                    McLoadFlag = table.Column<bool>(type: "bit", nullable: false),
                    McFinishFlag = table.Column<bool>(type: "bit", nullable: false),
                    McUnloadFlag = table.Column<bool>(type: "bit", nullable: false),
                    McPushFlag = table.Column<bool>(type: "bit", nullable: false),
                    OutboundFlag = table.Column<bool>(type: "bit", nullable: false),
                    OutboundFinishFlag = table.Column<bool>(type: "bit", nullable: false),
                    QCStatus = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MaterialCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    TableNumber = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    NcFile = table.Column<string>(type: "nvarchar(500)", nullable: true),
                    DueDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    MachineNo = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    MachineNoReady = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    StandardTime = table.Column<int>(type: "int", nullable: false),
                    PrimaryItemCode = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PrimaryItemModel = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PrimaryQuantity = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    StartFlag = table.Column<bool>(type: "bit", nullable: false),
                    JobEntityId = table.Column<int>(type: "int", nullable: false),
                    MachineId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JobTasks", x => x.TaskId);
                    table.ForeignKey(
                        name: "FK_JobTasks_JobEntities_JobEntityId",
                        column: x => x.JobEntityId,
                        principalTable: "JobEntities",
                        principalColumn: "JobEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_JobTasks_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "MachineId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ShelfLocations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LevelNo = table.Column<int>(type: "int", nullable: false),
                    ColumnNo = table.Column<int>(type: "int", nullable: false),
                    CombindLocation = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    ItemId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ReserveFlag = table.Column<bool>(type: "bit", nullable: false),
                    FillFlag = table.Column<bool>(type: "bit", nullable: false),
                    AvailableFlag = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    LastUpdatedBy = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    Attribute1 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Attribute2 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Attribute3 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Attribute4 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Attribute5 = table.Column<string>(type: "nvarchar(250)", nullable: true),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    TaskEntityTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShelfLocations", x => x.LocationId);
                    table.ForeignKey(
                        name: "FK_ShelfLocations_JobTasks_TaskEntityTaskId",
                        column: x => x.TaskEntityTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TaskTransactionLogs",
                columns: table => new
                {
                    LogId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    JobEntityId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    ActionName = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    ActionTimeStamp = table.Column<DateTime>(type: "datetime2(7)", nullable: false),
                    LogMessages = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TaskEntityTaskId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TaskTransactionLogs", x => x.LogId);
                    table.ForeignKey(
                        name: "FK_TaskTransactionLogs_JobEntities_JobEntityId",
                        column: x => x.JobEntityId,
                        principalTable: "JobEntities",
                        principalColumn: "JobEntityId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TaskTransactionLogs_JobTasks_TaskEntityTaskId",
                        column: x => x.TaskEntityTaskId,
                        principalTable: "JobTasks",
                        principalColumn: "TaskId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_JobEntityId",
                table: "JobTasks",
                column: "JobEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_JobTasks_MachineId",
                table: "JobTasks",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_ShelfLocations_TaskEntityTaskId",
                table: "ShelfLocations",
                column: "TaskEntityTaskId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTransactionLogs_JobEntityId",
                table: "TaskTransactionLogs",
                column: "JobEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_TaskTransactionLogs_TaskEntityTaskId",
                table: "TaskTransactionLogs",
                column: "TaskEntityTaskId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "ShelfLocations");

            migrationBuilder.DropTable(
                name: "TaskTransactionLogs");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "JobTasks");

            migrationBuilder.DropTable(
                name: "JobEntities");

            migrationBuilder.DropTable(
                name: "Machines");
        }
    }
}
