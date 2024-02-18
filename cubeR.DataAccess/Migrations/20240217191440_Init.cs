using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cubeR.DataAccess
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CubeTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    SidesCount = table.Column<int>(type: "int", nullable: false),
                    PiecesCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CubeTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Solves",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolveType = table.Column<int>(type: "int", nullable: false),
                    CubeId = table.Column<int>(type: "int", nullable: true),
                    Scramble = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LoggedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SolveTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Solves", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Solves_CubeTypes_CubeId",
                        column: x => x.CubeId,
                        principalTable: "CubeTypes",
                        principalColumn: "Id");
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
                name: "CubeTypes");
        }
    }
}
