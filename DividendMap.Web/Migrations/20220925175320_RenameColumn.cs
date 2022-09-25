using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DividendMap.Web.Migrations
{
    public partial class RenameColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ExDate",
                table: "Dividends",
                newName: "InDate");

            migrationBuilder.RenameColumn(
                name: "StockName",
                table: "Companies",
                newName: "Ticker");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PayDate",
                table: "Dividends",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "InDate",
                table: "Dividends",
                newName: "ExDate");

            migrationBuilder.RenameColumn(
                name: "Ticker",
                table: "Companies",
                newName: "StockName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "PayDate",
                table: "Dividends",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);
        }
    }
}
