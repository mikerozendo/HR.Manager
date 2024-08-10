﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Sales.Backoffice.WebApi.Repositories;

#nullable disable

namespace Sales.Backoffice.WebApi.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.7")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Adress", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("AdressCategory")
                        .HasColumnType("int");

                    b.Property<int>("AdressType")
                        .HasColumnType("int");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Neighborhood")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ZipCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Adresses");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Agent", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("PersonType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Agents");

                    b.UseTptMappingStrategy();
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Contact", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ContactType")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Value")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("DepartmentType")
                        .HasColumnType("int");

                    b.Property<decimal>("EmployeeBaseSalary")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("MaxAcceptableEmployees")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Document", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("AgentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreatedAt")
                        .HasColumnType("datetime2");

                    b.Property<int>("DocumentType")
                        .HasColumnType("int");

                    b.Property<bool>("IsValid")
                        .HasColumnType("bit");

                    b.Property<DateTime>("ModifiedAt")
                        .HasColumnType("datetime2");

                    b.Property<string>("Number")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Validated")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("AgentId");

                    b.ToTable("Documents");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.IndividualPerson", b =>
                {
                    b.HasBaseType("Sales.Backoffice.WebApi.Models.Agent");

                    b.Property<DateTime>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Sex")
                        .HasColumnType("int");

                    b.ToTable("IndividualPersons");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Employee", b =>
                {
                    b.HasBaseType("Sales.Backoffice.WebApi.Models.IndividualPerson");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("RegistrationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Manager", b =>
                {
                    b.HasBaseType("Sales.Backoffice.WebApi.Models.Employee");

                    b.Property<Guid?>("DepartmentId1")
                        .HasColumnType("uniqueidentifier");

                    b.HasIndex("DepartmentId1")
                        .IsUnique()
                        .HasFilter("[DepartmentId1] IS NOT NULL");

                    b.ToTable("Manager");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Adress", b =>
                {
                    b.HasOne("Sales.Backoffice.WebApi.Models.Agent", "Agent")
                        .WithMany("Adresses")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Contact", b =>
                {
                    b.HasOne("Sales.Backoffice.WebApi.Models.Agent", "Agent")
                        .WithMany("Contacts")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Document", b =>
                {
                    b.HasOne("Sales.Backoffice.WebApi.Models.Agent", "Agent")
                        .WithMany("Documents")
                        .HasForeignKey("AgentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Agent");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.IndividualPerson", b =>
                {
                    b.HasOne("Sales.Backoffice.WebApi.Models.Agent", null)
                        .WithOne()
                        .HasForeignKey("Sales.Backoffice.WebApi.Models.IndividualPerson", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Employee", b =>
                {
                    b.HasOne("Sales.Backoffice.WebApi.Models.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Sales.Backoffice.WebApi.Models.IndividualPerson", null)
                        .WithOne()
                        .HasForeignKey("Sales.Backoffice.WebApi.Models.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Manager", b =>
                {
                    b.HasOne("Sales.Backoffice.WebApi.Models.Department", null)
                        .WithOne("Manager")
                        .HasForeignKey("Sales.Backoffice.WebApi.Models.Manager", "DepartmentId1");

                    b.HasOne("Sales.Backoffice.WebApi.Models.Employee", null)
                        .WithOne()
                        .HasForeignKey("Sales.Backoffice.WebApi.Models.Manager", "Id")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Agent", b =>
                {
                    b.Navigation("Adresses");

                    b.Navigation("Contacts");

                    b.Navigation("Documents");
                });

            modelBuilder.Entity("Sales.Backoffice.WebApi.Models.Department", b =>
                {
                    b.Navigation("Employees");

                    b.Navigation("Manager")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
