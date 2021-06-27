using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpressSolution.Stores.Data.Migrations
{
    public partial class AddlistOfCategoryToStore : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Stores_Categories_IdCategory",
                table: "Stores");

            migrationBuilder.DropIndex(
                name: "IX_Stores_IdCategory",
                table: "Stores");

            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Stores");

            migrationBuilder.CreateTable(
                name: "StoreCategory",
                columns: table => new
                {
                    CategoryId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreCategory", x => new { x.CategoryId, x.StoreId });
                    table.ForeignKey(
                        name: "FK_StoreCategory_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_StoreCategory_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StoreCategory_StoreId",
                table: "StoreCategory",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StoreCategory");

            migrationBuilder.AddColumn<string>(
                name: "IdCategory",
                table: "Stores",
                type: "nvarchar(50)",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Stores_IdCategory",
                table: "Stores",
                column: "IdCategory");

            migrationBuilder.AddForeignKey(
                name: "FK_Stores_Categories_IdCategory",
                table: "Stores",
                column: "IdCategory",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
