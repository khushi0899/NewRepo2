using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodServices.Migrations
{
    public partial class AddMainCategoryandItems : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "mainCategories",
                columns: table => new
                {
                    MainCategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryName = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainCategories", x => x.MainCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MainItems",
                columns: table => new
                {
                    MainItemsId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainItemsName = table.Column<int>(nullable: false),
                    MainCategoryId = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MainItems", x => x.MainItemsId);
                    table.ForeignKey(
                        name: "FK_MainItems_mainCategories_MainCategoryId",
                        column: x => x.MainCategoryId,
                        principalTable: "mainCategories",
                        principalColumn: "MainCategoryId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MainItems_MainCategoryId",
                table: "MainItems",
                column: "MainCategoryId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainItems");

            migrationBuilder.DropTable(
                name: "mainCategories");
        }
    }
}
