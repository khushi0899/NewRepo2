using Microsoft.EntityFrameworkCore.Migrations;

namespace FoodServices.Migrations
{
    public partial class AddProfilePhoto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MainItems");

            migrationBuilder.DropTable(
                name: "mainCategories");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Customer",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Customer");

            migrationBuilder.CreateTable(
                name: "mainCategories",
                columns: table => new
                {
                    MainCategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryName = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_mainCategories", x => x.MainCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "MainItems",
                columns: table => new
                {
                    MainItemsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MainCategoryId = table.Column<int>(type: "int", nullable: true),
                    MainItemsName = table.Column<int>(type: "int", nullable: false)
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
    }
}
