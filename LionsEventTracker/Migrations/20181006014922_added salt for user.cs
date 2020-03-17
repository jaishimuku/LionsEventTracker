using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LionsEventTracker.Migrations
{
    public partial class addedsaltforuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "salt",
                table: "Users",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "salt",
                table: "Users");
        }
    }
}
