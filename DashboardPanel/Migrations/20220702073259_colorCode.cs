using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardPanel.Migrations
{
    public partial class colorCode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ColorCode",
                table: "GrafikDatas",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ColorCode",
                table: "GrafikDatas");
        }
    }
}
