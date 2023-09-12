using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace NLayer.Repository.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Stock = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(20,2)", nullable: false),
                    CategoryId = table.Column<int>(type: "INTEGER", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Products_Categories_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Categories",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProductFeatures",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Color = table.Column<string>(type: "TEXT", nullable: false),
                    Height = table.Column<int>(type: "INTEGER", nullable: false),
                    Width = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductFeatures", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductFeatures_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 1, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kitap", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 2, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Kozmetik", null });

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "Id", "CreatedDate", "Name", "UpdatedDate" },
                values: new object[] { 3, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ayakkabı", null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 1, 1, new DateTime(2023, 9, 12, 19, 30, 8, 716, DateTimeKind.Local).AddTicks(7836), "Yüzüklerin Efendisi Yüzük Kardeşliği", 60m, 100, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 2, 1, new DateTime(2023, 9, 12, 19, 30, 8, 716, DateTimeKind.Local).AddTicks(7843), "Yüzüklerin Efendisi İki Kule", 50m, 150, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 3, 1, new DateTime(2023, 9, 12, 19, 30, 8, 716, DateTimeKind.Local).AddTicks(7845), "Yüzüklerin Efendisi Kralın Dönüşü", 80m, 200, null });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "CategoryId", "CreatedDate", "Name", "Price", "Stock", "UpdatedDate" },
                values: new object[] { 4, 2, new DateTime(2023, 9, 12, 19, 30, 8, 716, DateTimeKind.Local).AddTicks(7845), "Kırmızı Ruj", 10m, 300, null });

            migrationBuilder.CreateIndex(
                name: "IX_Categories_Name",
                table: "Categories",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ProductFeatures_ProductId",
                table: "ProductFeatures",
                column: "ProductId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Products_CategoryId",
                table: "Products",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Name",
                table: "Products",
                column: "Name",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ProductFeatures");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Categories");
        }
    }
}
