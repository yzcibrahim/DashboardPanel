using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardPanel.Migrations
{
    public partial class widgetType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "WidgetTip",
                table: "Grafiks",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WidgetTip",
                table: "Grafiks");
        }
    }
}
