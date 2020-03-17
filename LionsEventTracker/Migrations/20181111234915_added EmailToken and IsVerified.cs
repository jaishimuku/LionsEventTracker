using Microsoft.EntityFrameworkCore.Migrations;

namespace LionsEventTracker.Migrations
{
    public partial class addedEmailTokenandIsVerified : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EmailToken",
                table: "Users",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsVerified",
                table: "Users",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmailToken",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "IsVerified",
                table: "Users");
        }
    }
}
