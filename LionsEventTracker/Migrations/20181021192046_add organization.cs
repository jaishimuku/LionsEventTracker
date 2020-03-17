using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LionsEventTracker.Migrations
{
    public partial class addorganization : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Date",
                table: "Events",
                nullable: false,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Organization",
                table: "Events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Organization",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                oldClrType: typeof(string));
        }
    }
}
