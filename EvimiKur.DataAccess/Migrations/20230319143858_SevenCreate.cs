using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EvimiKur.DataAccess.Migrations
{
    public partial class SevenCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripion",
                table: "Dealers",
                newName: "Description");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 19, 17, 38, 57, 639, DateTimeKind.Local).AddTicks(269));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 19, 17, 38, 57, 639, DateTimeKind.Local).AddTicks(9572));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Dealers",
                newName: "Descripion");

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 19, 17, 2, 51, 500, DateTimeKind.Local).AddTicks(3067));

            migrationBuilder.UpdateData(
                table: "AppRoles",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 3, 19, 17, 2, 51, 501, DateTimeKind.Local).AddTicks(8498));
        }
    }
}
