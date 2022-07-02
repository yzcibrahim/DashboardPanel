using Microsoft.EntityFrameworkCore.Migrations;

namespace DashboardPanel.Migrations
{
    public partial class initialGrafik : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Grafiks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Isim = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Tip = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grafiks", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "GrafikDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Anahtar = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Value = table.Column<double>(type: "float", nullable: false),
                    GrafikId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GrafikDatas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_GrafikDatas_Grafiks_GrafikId",
                        column: x => x.GrafikId,
                        principalTable: "Grafiks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_GrafikDatas_GrafikId",
                table: "GrafikDatas",
                column: "GrafikId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "GrafikDatas");

            migrationBuilder.DropTable(
                name: "Grafiks");
        }
    }
}
