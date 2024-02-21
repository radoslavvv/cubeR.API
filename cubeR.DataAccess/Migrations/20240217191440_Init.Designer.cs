﻿// <auto-generated />
using System;
using cubeR.DataAccess;
using cubeR.DataAccess.DataContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace cubeR.DataAccess
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240217191440_Init")]
    partial class Init
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cubeRAPI.Models.Cube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PiecesCount")
                        .HasColumnType("int");

                    b.Property<int>("SidesCount")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.ToTable("CubeTypes");
                });

            modelBuilder.Entity("cubeRAPI.Models.Solve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("CubeId")
                        .HasColumnType("int");

                    b.Property<DateTime>("LoggedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Scramble")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<TimeSpan>("SolveTime")
                        .HasColumnType("time");

                    b.Property<int>("SolveType")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CubeId");

                    b.ToTable("Solves");
                });

            modelBuilder.Entity("cubeRAPI.Models.Solve", b =>
                {
                    b.HasOne("cubeRAPI.Models.Cube", "Cube")
                        .WithMany()
                        .HasForeignKey("CubeId");

                    b.Navigation("Cube");
                });
#pragma warning restore 612, 618
        }
    }
}
