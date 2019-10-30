using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SccCrmCore.Migrations
{
    public partial class AjouteSirets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Sirets",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(maxLength: 14, nullable: false),
                    Nom = table.Column<string>(maxLength: 100, nullable: false),
                    Adresse = table.Column<string>(nullable: false),
                    SirenId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sirets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sirets_Sirens_SirenId",
                        column: x => x.SirenId,
                        principalTable: "Sirens",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Sirets_SirenId",
                table: "Sirets",
                column: "SirenId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Sirets");
        }
    }
}
