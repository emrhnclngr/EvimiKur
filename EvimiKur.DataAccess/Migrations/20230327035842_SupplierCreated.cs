using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvimiKur.DataAccess.Migrations
{
    public partial class SupplierCreated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Dealers_DealerId",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_DealerId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "DealerId",
                table: "Orders");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 6, 58, 42, 518, DateTimeKind.Local).AddTicks(1857));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 6, 58, 42, 519, DateTimeKind.Local).AddTicks(4636));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "DealerId",
                table: "Orders",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 6, 45, 41, 925, DateTimeKind.Local).AddTicks(7861));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 27, 6, 45, 41, 926, DateTimeKind.Local).AddTicks(7514));

            migrationBuilder.CreateIndex(
                name: "IX_Orders_DealerId",
                table: "Orders",
                column: "DealerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Dealers_DealerId",
                table: "Orders",
                column: "DealerId",
                principalTable: "Dealers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
