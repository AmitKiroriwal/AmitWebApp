using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AmitWebApp.Migrations
{
    /// <inheritdoc />
    public partial class mygal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PhotoPath",
                table: "myGallery",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "categoryId",
                table: "myGallery",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "galleryCategories",
                columns: table => new
                {
                    CategoryId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CategoryName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverImage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MyGalleryId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_galleryCategories", x => x.CategoryId);
                    table.ForeignKey(
                        name: "FK_galleryCategories_myGallery_MyGalleryId",
                        column: x => x.MyGalleryId,
                        principalTable: "myGallery",
                        principalColumn: "Id");
                });

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddOn", "HireDate", "UpdateOn" },
                values: new object[] { new DateTime(2023, 2, 1, 19, 39, 49, 342, DateTimeKind.Local).AddTicks(8142), new DateTime(2023, 2, 1, 19, 39, 49, 342, DateTimeKind.Local).AddTicks(8161), new DateTime(2023, 2, 1, 19, 39, 49, 342, DateTimeKind.Local).AddTicks(8152) });

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddOn", "UpdateOn" },
                values: new object[] { new DateTime(2023, 2, 1, 19, 39, 49, 342, DateTimeKind.Local).AddTicks(8163), new DateTime(2023, 2, 1, 19, 39, 49, 342, DateTimeKind.Local).AddTicks(8163) });

            migrationBuilder.CreateIndex(
                name: "IX_galleryCategories_MyGalleryId",
                table: "galleryCategories",
                column: "MyGalleryId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "galleryCategories");

            migrationBuilder.DropColumn(
                name: "PhotoPath",
                table: "myGallery");

            migrationBuilder.DropColumn(
                name: "categoryId",
                table: "myGallery");

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "AddOn", "HireDate", "UpdateOn" },
                values: new object[] { new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(364), new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(382), new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(376) });

            migrationBuilder.UpdateData(
                table: "employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AddOn", "UpdateOn" },
                values: new object[] { new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(385), new DateTime(2023, 2, 1, 9, 8, 41, 928, DateTimeKind.Local).AddTicks(386) });
        }
    }
}
