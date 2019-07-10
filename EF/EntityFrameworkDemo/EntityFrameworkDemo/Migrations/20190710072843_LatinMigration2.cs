using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkDemo.Migrations
{
    public partial class LatinMigration2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LatinName",
                table: "Frukterna");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "LatinName",
                table: "Frukterna",
                nullable: true);
        }
    }
}
