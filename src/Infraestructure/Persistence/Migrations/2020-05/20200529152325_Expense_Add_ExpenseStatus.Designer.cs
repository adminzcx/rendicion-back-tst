﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Prome.Viaticos.Server.Infraestructure.Persistence;

namespace Prome.Viaticos.Server.Infraestructure.Persistence.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20200529152325_Expense_Add_ExpenseStatus")]
    partial class Expense_Add_ExpenseStatus
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Concept", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Form")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long?>("ReasonId")
                        .IsRequired()
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ReasonId");

                    b.ToTable("Concepts");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Expense", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(200)")
                        .HasMaxLength(200);

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ConceptId")
                        .HasColumnType("bigint");

                    b.Property<string>("DNI")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("Device")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<string>("DocumentAttached")
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExpenseFormId")
                        .HasColumnType("bigint");

                    b.Property<string>("ImageMAP")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<decimal?>("KM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<double?>("Latitude")
                        .HasColumnType("float")
                        .HasMaxLength(50);

                    b.Property<double?>("Longitude")
                        .HasColumnType("float")
                        .HasMaxLength(50);

                    b.Property<decimal?>("MobilityAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("PresentationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal?>("PriceByKM")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("ReasonId")
                        .HasColumnType("bigint");

                    b.Property<string>("RequestNumber")
                        .HasColumnType("nvarchar(50)")
                        .HasMaxLength(50);

                    b.Property<long?>("SegmentId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SourceId")
                        .HasColumnType("bigint");

                    b.Property<double?>("SourceLatitude")
                        .HasColumnType("float")
                        .HasMaxLength(50);

                    b.Property<double?>("SourceLongitude")
                        .HasColumnType("float")
                        .HasMaxLength(50);

                    b.Property<long?>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<long?>("TechnicalVisitId")
                        .HasColumnType("bigint");

                    b.Property<string>("Term")
                        .HasColumnType("nvarchar(30)")
                        .HasMaxLength(30);

                    b.Property<decimal?>("TotalAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("VisitResult")
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.HasKey("Id");

                    b.HasIndex("ConceptId");

                    b.HasIndex("ExpenseFormId");

                    b.HasIndex("ReasonId");

                    b.HasIndex("SegmentId");

                    b.HasIndex("SourceId");

                    b.HasIndex("StatusId");

                    b.HasIndex("TechnicalVisitId");

                    b.HasIndex("UserId");

                    b.ToTable("Expenses");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseForm", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long?>("AdministratorUserId")
                        .HasColumnType("bigint");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(500)")
                        .HasMaxLength(500);

                    b.Property<bool>("EmailSent")
                        .HasColumnType("bit");

                    b.Property<DateTime>("PresentationDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("StatusId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorUserId");

                    b.HasIndex("StatusId");

                    b.HasIndex("UserId");

                    b.ToTable("ExpenseForms");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseFormStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("ExpenseFormStatus");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseStatus", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ExpenseStatus");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseUser", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("ExpenseDate")
                        .HasColumnType("datetime2");

                    b.Property<long?>("ExpenseId")
                        .HasColumnType("bigint");

                    b.Property<long?>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("ExpenseId");

                    b.HasIndex("UserId");

                    b.ToTable("ExpenseUsers");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Reason", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Reasons");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Segment", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Segments");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Source", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.ToTable("Sources");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.TechnicalVisit", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("TechnicalVisits");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Branch", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("SubZoneId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("SubZoneId");

                    b.ToTable("Branches");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Category", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Management", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Managements");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Position", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Positions");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Sector", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<long>("ManagementId")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ManagementId");

                    b.ToTable("Sectors");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.SubZone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long>("ZoneId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.HasIndex("ZoneId");

                    b.ToTable("SubZones");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("BranchFromId")
                        .HasColumnType("bigint");

                    b.Property<long?>("BranchId")
                        .HasColumnType("bigint");

                    b.Property<long?>("CategoryId")
                        .HasColumnType("bigint");

                    b.Property<DateTime>("Created")
                        .HasColumnType("datetime2");

                    b.Property<long>("CreatedBy")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("DisabledDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("EmployeeRecord")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<bool>("IsAdministrator")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("LastModified")
                        .HasColumnType("datetime2");

                    b.Property<long>("LastModifiedBy")
                        .HasColumnType("bigint");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.Property<long?>("ManagementId")
                        .HasColumnType("bigint");

                    b.Property<long>("PositionId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SectorId")
                        .HasColumnType("bigint");

                    b.Property<long?>("SubZoneId")
                        .HasColumnType("bigint");

                    b.Property<long?>("ZoneId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("BranchFromId");

                    b.HasIndex("BranchId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("ManagementId");

                    b.HasIndex("PositionId");

                    b.HasIndex("SectorId");

                    b.HasIndex("SubZoneId");

                    b.HasIndex("ZoneId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Zone", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("nvarchar(10)")
                        .HasMaxLength(10);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(100)")
                        .HasMaxLength(100);

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique();

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Concept", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Reason", "Reason")
                        .WithMany("Concepts")
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Expense", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Concept", "Concept")
                        .WithMany()
                        .HasForeignKey("ConceptId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseForm", "ExpenseForm")
                        .WithMany("Expenses")
                        .HasForeignKey("ExpenseFormId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Reason", "Reason")
                        .WithMany()
                        .HasForeignKey("ReasonId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Segment", "Segment")
                        .WithMany()
                        .HasForeignKey("SegmentId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Source", "Source")
                        .WithMany()
                        .HasForeignKey("SourceId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.TechnicalVisit", "TechnicalVisit")
                        .WithMany()
                        .HasForeignKey("TechnicalVisitId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseForm", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.User", "AdministratorUser")
                        .WithMany()
                        .HasForeignKey("AdministratorUserId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseFormStatus", "Status")
                        .WithMany()
                        .HasForeignKey("StatusId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.ExpenseUser", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.ExpenseAggregate.Expense", "Expense")
                        .WithMany("ExpenseUsers")
                        .HasForeignKey("ExpenseId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Branch", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.SubZone", "SubZone")
                        .WithMany()
                        .HasForeignKey("SubZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Sector", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Management", "Management")
                        .WithMany()
                        .HasForeignKey("ManagementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.SubZone", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Prome.Viaticos.Server.Domain.Entities.UserAggregate.User", b =>
                {
                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Branch", "BranchFrom")
                        .WithMany()
                        .HasForeignKey("BranchFromId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Branch", "Branch")
                        .WithMany()
                        .HasForeignKey("BranchId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Category", "Category")
                        .WithMany()
                        .HasForeignKey("CategoryId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Management", "Management")
                        .WithMany()
                        .HasForeignKey("ManagementId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Position", "Position")
                        .WithMany()
                        .HasForeignKey("PositionId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Sector", "Sector")
                        .WithMany()
                        .HasForeignKey("SectorId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.SubZone", "SubZone")
                        .WithMany()
                        .HasForeignKey("SubZoneId");

                    b.HasOne("Prome.Viaticos.Server.Domain.Entities.UserAggregate.Zone", "Zone")
                        .WithMany()
                        .HasForeignKey("ZoneId");
                });
#pragma warning restore 612, 618
        }
    }
}
