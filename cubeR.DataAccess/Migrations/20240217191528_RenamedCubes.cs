using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cubeR.DataAccess
{
    /// <inheritdoc />
    public partial class RenamedCubes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solves_CubeTypes_CubeId",
                table: "Solves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CubeTypes",
                table: "CubeTypes");

            migrationBuilder.RenameTable(
                name: "CubeTypes",
                newName: "Cubes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Cubes",
                table: "Cubes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solves_Cubes_CubeId",
                table: "Solves",
                column: "CubeId",
                principalTable: "Cubes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Solves_Cubes_CubeId",
                table: "Solves");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Cubes",
                table: "Cubes");

            migrationBuilder.RenameTable(
                name: "Cubes",
                newName: "CubeTypes");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CubeTypes",
                table: "CubeTypes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Solves_CubeTypes_CubeId",
                table: "Solves",
                column: "CubeId",
                principalTable: "CubeTypes",
                principalColumn: "Id");
        }
    }
}
