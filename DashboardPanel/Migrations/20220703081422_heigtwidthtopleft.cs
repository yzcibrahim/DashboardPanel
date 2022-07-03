using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardPanel.Migrations
{
    public partial class heigtwidthtopleft : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Height",
                table: "DashBoardWidgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Left",
                table: "DashBoardWidgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Top",
                table: "DashBoardWidgets",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Width",
                table: "DashBoardWidgets",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                table: "DashBoardWidgets");

            migrationBuilder.DropColumn(
                name: "Left",
                table: "DashBoardWidgets");

            migrationBuilder.DropColumn(
                name: "Top",
                table: "DashBoardWidgets");

            migrationBuilder.DropColumn(
                name: "Width",
                table: "DashBoardWidgets");
        }
    }
}
