﻿// <auto-generated />
using System;
using IndustryProduction.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace IndustryProduction.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200428075943_Add alarm table")]
    partial class Addalarmtable
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("IndustryProduction.Data.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<int>("ApproverId")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("LegacyUserId")
                        .HasColumnType("int");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SignatureImg")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("IndustryProduction.Models.AlarmHistory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("bit");

                    b.Property<string>("AlarmDesc")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AlarmNo")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("AxisName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.ToTable("AlarmHistories");
                });

            modelBuilder.Entity("IndustryProduction.Models.CameraSettingModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CameraCode")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("CameraUrl")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Port")
                        .HasColumnType("int");

                    b.Property<string>("Username")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("CameraSetting");
                });

            modelBuilder.Entity("IndustryProduction.Models.JobEntityModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CancelFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("CompletedFlag")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntityType")
                        .HasColumnType("int");

                    b.Property<DateTime>("JobEntiryDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("JobEntityName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<bool>("OpenStatus")
                        .HasColumnType("bit");

                    b.Property<int>("OrganizationId")
                        .HasColumnType("int");

                    b.Property<int>("PoHeaderId")
                        .HasColumnType("int");

                    b.Property<int>("PoLineId")
                        .HasColumnType("int");

                    b.Property<string>("PrimaryItemCode")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("PrimaryItemId")
                        .HasColumnType("int");

                    b.Property<string>("PrimaryItemModel")
                        .HasColumnType("nvarchar(250)");

                    b.Property<decimal>("PrimaryQuantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<bool>("ProcessFlag")
                        .HasColumnType("bit");

                    b.Property<string>("Segment1")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Segment2")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Segment3")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Segment4")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Segment5")
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("JobEntities");
                });

            modelBuilder.Entity("IndustryProduction.Models.JobEntityTaskModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("CancelFlag")
                        .HasColumnType("bit");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(250)");

                    b.Property<DateTime>("DueDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("ErrorText")
                        .HasColumnType("nvarchar(500)");

                    b.Property<int>("JobEntityId")
                        .HasColumnType("int");

                    b.Property<string>("JobNumber")
                        .HasColumnType("nvarchar(25)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<string>("MachineNo")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MachineNoReady")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Manager")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("MaterialCode")
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("McFinishFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("McLoadFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("McPickFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("McProcessFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("McPushFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("McUnloadFlag")
                        .HasColumnType("bit");

                    b.Property<string>("NcFile")
                        .HasColumnType("nvarchar(500)");

                    b.Property<bool>("OnShelfFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("OutboundFinishFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("OutboundFlag")
                        .HasColumnType("bit");

                    b.Property<string>("PrimaryItemCode")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PrimaryItemModel")
                        .HasColumnType("nvarchar(50)");

                    b.Property<decimal>("PrimaryQuantity")
                        .HasColumnType("decimal(18, 2)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<string>("QCStatus")
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("ReadyFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("ReleaseFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("ReserveShelfFlag")
                        .HasColumnType("bit");

                    b.Property<string>("ShelfNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Source")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StandardTime")
                        .HasColumnType("int");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<bool>("StartFlag")
                        .HasColumnType("bit");

                    b.Property<string>("TableNumber")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("TaskNumber")
                        .HasColumnType("nvarchar(25)");

                    b.Property<int>("TaskSeq")
                        .HasColumnType("int");

                    b.Property<string>("TransferMessage")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TransferNCFileToMachineFlag")
                        .HasColumnType("bit");

                    b.Property<bool>("UploadNcfileFlag")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("JobEntityId");

                    b.HasIndex("MachineId");

                    b.ToTable("JobTasks");
                });

            modelBuilder.Entity("IndustryProduction.Models.LocationModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Attribute1")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Attribute2")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Attribute3")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Attribute4")
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Attribute5")
                        .HasColumnType("nvarchar(250)");

                    b.Property<bool>("AvailableFlag")
                        .HasColumnType("bit");

                    b.Property<int>("ColumnNo")
                        .HasColumnType("int");

                    b.Property<string>("CombindLocation")
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<bool>("FillFlag")
                        .HasColumnType("bit");

                    b.Property<int>("ItemId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("LevelNo")
                        .HasColumnType("int");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<bool>("ReserveFlag")
                        .HasColumnType("bit");

                    b.Property<int?>("TaskEntityId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TaskEntityId");

                    b.ToTable("ShelfLocations");
                });

            modelBuilder.Entity("IndustryProduction.Models.Machine", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("ActiveFlag")
                        .HasColumnType("bit");

                    b.Property<int>("CalendarId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<bool>("EnableFlag")
                        .HasColumnType("bit");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<string>("MacGroup")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MacType")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MachineCode")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MachineModel")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("PlantId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PortNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProductionLine")
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("MachinesMaster");
                });

            modelBuilder.Entity("IndustryProduction.Models.MachineModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActiveFlag")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("CalendarId")
                        .HasColumnType("int");

                    b.Property<int>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("ETimeLunchHr")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("EnableFlag")
                        .IsRequired()
                        .HasColumnType("char(1)");

                    b.Property<int>("Fri")
                        .HasColumnType("int");

                    b.Property<string>("IpAddress")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("LastUpdateDate")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("LastUpdatedBy")
                        .HasColumnType("int");

                    b.Property<int>("LunchHr")
                        .HasColumnType("int");

                    b.Property<DateTime>("MacEndTime")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("MacGroup")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MacModel")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("MacStartTime")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("MacType")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("MachineCode")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("MaintenaneTime")
                        .HasColumnType("int");

                    b.Property<int>("Mon")
                        .HasColumnType("int");

                    b.Property<string>("PlantId")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("PortNumber")
                        .HasColumnType("int");

                    b.Property<string>("ProductionLine")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Remarks")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("STimeLunchHr")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sat")
                        .HasColumnType("int");

                    b.Property<string>("Shift1")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Shift2")
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("ShiftOT")
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("Sun")
                        .HasColumnType("int");

                    b.Property<int>("Thu")
                        .HasColumnType("int");

                    b.Property<int>("Tue")
                        .HasColumnType("int");

                    b.Property<int>("Wed")
                        .HasColumnType("int");

                    b.Property<int>("WorkingHr")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Machines");
                });

            modelBuilder.Entity("IndustryProduction.Models.MachineWorking", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MachineId")
                        .HasColumnType("int");

                    b.Property<int>("ShiftId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("MachineId");

                    b.HasIndex("ShiftId");

                    b.ToTable("MachineWorkings");
                });

            modelBuilder.Entity("IndustryProduction.Models.TaskLogsModel", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ActionName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("ActionTimeStamp")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("JobEntityId")
                        .HasColumnType("int");

                    b.Property<string>("LogMessages")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("TaskEntityId")
                        .HasColumnType("int");

                    b.Property<int>("TaskId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("JobEntityId");

                    b.HasIndex("TaskEntityId");

                    b.ToTable("TaskTransactionLogs");
                });

            modelBuilder.Entity("IndustryProduction.Models.WorkingShift", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("EndTime")
                        .HasColumnType("datetime2(7)");

                    b.Property<string>("ShiftName")
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime>("StartTime")
                        .HasColumnType("datetime2(7)");

                    b.Property<int>("WorkingHr")
                        .HasColumnType("int");

                    b.Property<int>("WorkingMin")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("WorkingShifts");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(256)")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(128)")
                        .HasMaxLength(128);

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("IndustryProduction.Models.AlarmHistory", b =>
                {
                    b.HasOne("IndustryProduction.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IndustryProduction.Models.JobEntityTaskModel", b =>
                {
                    b.HasOne("IndustryProduction.Models.JobEntityModel", "JobEntity")
                        .WithMany("JobTasks")
                        .HasForeignKey("JobEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndustryProduction.Models.Machine", "Machine")
                        .WithMany()
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IndustryProduction.Models.LocationModel", b =>
                {
                    b.HasOne("IndustryProduction.Models.JobEntityTaskModel", "TaskEntity")
                        .WithMany()
                        .HasForeignKey("TaskEntityId");
                });

            modelBuilder.Entity("IndustryProduction.Models.MachineWorking", b =>
                {
                    b.HasOne("IndustryProduction.Models.Machine", "Machine")
                        .WithMany("WorkingTime")
                        .HasForeignKey("MachineId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndustryProduction.Models.WorkingShift", "Shift")
                        .WithMany()
                        .HasForeignKey("ShiftId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("IndustryProduction.Models.TaskLogsModel", b =>
                {
                    b.HasOne("IndustryProduction.Models.JobEntityModel", "JobEntity")
                        .WithMany()
                        .HasForeignKey("JobEntityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndustryProduction.Models.JobEntityTaskModel", "TaskEntity")
                        .WithMany("TaskLogs")
                        .HasForeignKey("TaskEntityId");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("IndustryProduction.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("IndustryProduction.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("IndustryProduction.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("IndustryProduction.Data.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}