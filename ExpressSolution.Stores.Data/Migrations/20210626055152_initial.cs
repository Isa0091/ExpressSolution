using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExpressSolution.Stores.Data.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    Logo_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Logo_MimeType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Logo_UrlMultimedia = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Logo_MultimediaType = table.Column<int>(type: "int", nullable: true),
                    Description_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description_ExtendedDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categories_DynamicData",
                columns: table => new
                {
                    DataName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CategoryId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DataValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories_DynamicData", x => new { x.DataName, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_Categories_DynamicData_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    Description_Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Description_ExtendedDescription = table.Column<string>(type: "nvarchar(1500)", maxLength: 1500, nullable: true),
                    Active = table.Column<bool>(type: "bit", nullable: false),
                    IdCategory = table.Column<string>(type: "nvarchar(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stores_Categories_IdCategory",
                        column: x => x.IdCategory,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MultimediaStore",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    MultimediaRelevance = table.Column<int>(type: "int", nullable: false),
                    DataMultimedia_Name = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataMultimedia_MimeType = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DataMultimedia_UrlMultimedia = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    DataMultimedia_MultimediaType = table.Column<int>(type: "int", nullable: true),
                    StoreId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MultimediaStore", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MultimediaStore_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StoreContact",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DateCreated = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    ContactData_Name = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: true),
                    ContactData_LandLineNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    ContactData_Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ContactData_MobileNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    StoreId = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StoreContact", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StoreContact_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stores_DynamicData",
                columns: table => new
                {
                    DataName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StoreId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    DataValue = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stores_DynamicData", x => new { x.DataName, x.StoreId });
                    table.ForeignKey(
                        name: "FK_Stores_DynamicData_Stores_StoreId",
                        column: x => x.StoreId,
                        principalTable: "Stores",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_DynamicData_CategoryId",
                table: "Categories_DynamicData",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_MultimediaStore_StoreId",
                table: "MultimediaStore",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_StoreContact_StoreId",
                table: "StoreContact",
                column: "StoreId");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_IdCategory",
                table: "Stores",
                column: "IdCategory");

            migrationBuilder.CreateIndex(
                name: "IX_Stores_DynamicData_StoreId",
                table: "Stores_DynamicData",
                column: "StoreId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Categories_DynamicData");

            migrationBuilder.DropTable(
                name: "MultimediaStore");

            migrationBuilder.DropTable(
                name: "StoreContact");

            migrationBuilder.DropTable(
                name: "Stores_DynamicData");

            migrationBuilder.DropTable(
                name: "Stores");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
