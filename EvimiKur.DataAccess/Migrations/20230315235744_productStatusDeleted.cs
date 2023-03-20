using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvimiKur.DataAccess.Migrations
{
    public partial class productStatusDeleted : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStatus_ProductStatusId",
                table: "Products");

            migrationBuilder.DropTable(
                name: "ProductStatus");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 16, 2, 57, 44, 24, DateTimeKind.Local).AddTicks(3100));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 16, 2, 57, 44, 25, DateTimeKind.Local).AddTicks(650));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ProductStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeleteDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Status = table.Column<bool>(type: "bit", nullable: false),
                    UpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductStatus", x => x.Id);
                });

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 15, 20, 14, 20, 665, DateTimeKind.Local).AddTicks(2324));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 15, 20, 14, 20, 666, DateTimeKind.Local).AddTicks(235));

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStatusId",
                table: "Products",
                column: "ProductStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStatus_ProductStatusId",
                table: "Products",
                column: "ProductStatusId",
                principalTable: "ProductStatus",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
