﻿// <auto-generated />
using System;
using AmitWebApp.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace AmitWebApp.Migrations
{
    [DbContext(typeof(EmployeeDbContext))]
    [Migration("20230201033842_initials")]
    partial class initials
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("AmitWebApp.Models.Cities", b =>
                {
                    b.Property<int>("CityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CityId"));

                    b.Property<string>("CityName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("CityId");

                    b.ToTable("cities");
                });

            modelBuilder.Entity("AmitWebApp.Models.Districts", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StateId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("districts");
                });

            modelBuilder.Entity("AmitWebApp.Models.MyGallery", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("GalName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("myGallery");
                });

            modelBuilder.Entity("AmitWebApp.Models.States", b =>
                {
                    b.Property<int>("StateId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StateId"));

                    b.Property<string>("StateName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StateId");

                    b.ToTable("states");
                });

            modelBuilder.Entity("MyWebApp.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnOrder(1);

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("AddOn")
                        .HasColumnType("date")
                        .HasColumnOrder(8);

                    b.Property<int>("Department")
                        .HasColumnType("int")
                        .HasColumnOrder(7);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnOrder(3);

                    b.Property<DateTime>("HireDate")
                        .HasColumnType("date")
                        .HasColumnOrder(4);

                    b.Property<string>("Job")
                        .IsRequired()
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(5);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)")
                        .HasColumnOrder(2);

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RecStatus")
                        .HasColumnType("int")
                        .HasColumnOrder(10);

                    b.Property<decimal>("Salary")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnOrder(6);

                    b.Property<DateTime>("UpdateOn")
                        .HasColumnType("date")
                        .HasColumnOrder(9);

                    b.HasKey("Id");

                    b.ToTable("employees");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            AddOn = new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(364),
                            Department = 4,
                            Email = "amit@sircltech.com",
                            HireDate = new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(382),
                            Job = "Software",
                            Name = "Amit",
                            PhotoPath = "user.png",
                            RecStatus = 1,
                            Salary = 50000m,
                            UpdateOn = new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(376)
                        },
                        new
                        {
                            Id = 2,
                            AddOn = new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(385),
                            Department = 3,
                            Email = "Sunil@sircltech.com",
                            HireDate = new DateTime(2022, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                            Job = "Hardware",
                            Name = "Sunil",
                            PhotoPath = "user.png",
                            RecStatus = 1,
                            Salary = 40000m,
                            UpdateOn = new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(386)
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
