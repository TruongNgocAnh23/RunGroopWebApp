using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RunGroopWebApp.Migrations
{
    public partial class DeleteFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Artiles_Users_UserId",
                table: "Artiles");

            migrationBuilder.DropIndex(
                name: "IX_Artiles_UserId",
                table: "Artiles");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Artiles");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Artiles",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Artiles_UserId",
                table: "Artiles",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Artiles_Users_UserId",
                table: "Artiles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
