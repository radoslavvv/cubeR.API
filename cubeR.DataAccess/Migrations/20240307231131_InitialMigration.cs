using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cubeR.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Cubes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    SidesCount = table.Column<int>(type: "int", nullable: false),
                    PiecesCount = table.Column<int>(type: "int", nullable: false),
                    Weight = table.Column<double>(type: "float", nullable: false),
                    DifficultyLevel = table.Column<int>(type: "int", nullable: false),
                    ReleaseYear = table.Column<int>(type: "int", nullable: false),
                    Material = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cubes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolveType = table.Column<int>(type: "int", nullable: false),
                    CubeId = table.Column<int>(type: "int", nullable: false),
                    Scramble = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolveTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solves_Cubes_CubeId",
                        column: x => x.CubeId,
                        principalTable: "Cubes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Solves_CubeId",
                table: "Solves",
                column: "CubeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Solves");

            migrationBuilder.DropTable(
                name: "Cubes");
        }
    }
}
