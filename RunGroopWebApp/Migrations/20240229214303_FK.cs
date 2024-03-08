using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroopWebApp.Migrations
{
    public partial class FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_ArtilesImage_ArtilesId",
                table: "ArtilesImage",
                column: "ArtilesId");

            migrationBuilder.AddForeignKey(
                name: "FK_ArtilesImage_Artiles_ArtilesId",
                table: "ArtilesImage",
                column: "ArtilesId",
                principalTable: "Artiles",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ArtilesImage_Artiles_ArtilesId",
                table: "ArtilesImage");

            migrationBuilder.DropIndex(
                name: "IX_ArtilesImage_ArtilesId",
                table: "ArtilesImage");
        }
    }
}
