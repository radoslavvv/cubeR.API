﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using cubeR.DataAccess.DataContext;

#nullable disable

namespace cubeR.DataAccess.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("cubeR.DataAccess.Models.Cube", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("DifficultyLevel")
                        .HasColumnType("int");

                    b.Property<string>("Material")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<int>("PiecesCount")
                        .HasColumnType("int");

                    b.Property<int>("ReleaseYear")
                        .HasColumnType("int");

                    b.Property<int>("SidesCount")
                        .HasColumnType("int");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Cubes");
                });

            modelBuilder.Entity("cubeR.DataAccess.Models.Solve", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CubeId")
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

            modelBuilder.Entity("cubeR.DataAccess.Models.Solve", b =>
                {
                    b.HasOne("cubeR.DataAccess.Models.Cube", "Cube")
                        .WithMany("Solves")
                        .HasForeignKey("CubeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cube");
                });

            modelBuilder.Entity("cubeR.DataAccess.Models.Cube", b =>
                {
                    b.Navigation("Solves");
                });
#pragma warning restore 612, 618
        }
    }
}
