using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EntityFrameworkDemo.Migrations
{
    public partial class LatinNameMigration1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FrukternasFärger",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrukternasFärger", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "FrukternasKategorier",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FrukternasKategorier", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Frukterna",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    ColorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false),
                    Price = table.Column<decimal>(nullable: true),
                    LatinName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Frukterna", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Frukterna_FrukternasKategorier_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "FrukternasKategorier",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Frukterna_FrukternasFärger_ColorId",
                        column: x => x.ColorId,
                        principalTable: "FrukternasFärger",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Frukterna_CategoryId",
                table: "Frukterna",
                column: "CategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_Frukterna_ColorId",
                table: "Frukterna",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Frukterna");

            migrationBuilder.DropTable(
                name: "FrukternasKategorier");

            migrationBuilder.DropTable(
                name: "FrukternasFärger");
        }
    }
}
