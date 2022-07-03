using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardPanel.Migrations
{
    public partial class dashboard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DashBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashBoards", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DashBoardWidgets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DashId = table.Column<int>(type: "int", nullable: false),
                    GrafikId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DashBoardWidgets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DashBoardWidgets_DashBoards_DashId",
                        column: x => x.DashId,
                        principalTable: "DashBoards",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_DashBoardWidgets_Grafiks_GrafikId",
                        column: x => x.GrafikId,
                        principalTable: "Grafiks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DashBoardWidgets_DashId",
                table: "DashBoardWidgets",
                column: "DashId");

            migrationBuilder.CreateIndex(
                name: "IX_DashBoardWidgets_GrafikId",
                table: "DashBoardWidgets",
                column: "GrafikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DashBoardWidgets");

            migrationBuilder.DropTable(
                name: "DashBoards");
        }
    }
}
