using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace HippoRecipeApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Recipes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: false),
                    Description = table.Column<string>(type: "text", nullable: false),
                    Ingredients = table.Column<string>(type: "text", nullable: false),
                    Instructions = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Recipes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    TagName = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RecipeTag",
                columns: table => new
                {
                    RecipesId = table.Column<int>(type: "integer", nullable: false),
                    TagsId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RecipeTag", x => new { x.RecipesId, x.TagsId });
                    table.ForeignKey(
                        name: "FK_RecipeTag_Recipes_RecipesId",
                        column: x => x.RecipesId,
                        principalTable: "Recipes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RecipeTag_Tags_TagsId",
                        column: x => x.TagsId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Recipes",
                columns: new[] { "Id", "Description", "Ingredients", "Instructions", "Name" },
                values: new object[] { 1, "Creamy Garlic Pasta perfect for meal prep", "5 Fedd hvitløk\n    4Tomater\n    2Paprika\n    2tsLøkpulver\n    1ts Oregano\n    1ts Basilikum\n    4ts Paprika krydder\n    180ml Kyllingbuljong\n    240grams Kesam\n    800grams Kjøttdeig\n    500grams Pasta\n    50grams Parmesan\n", "Kutt tomater og paprika i biter. Rasp hvitløk.\n    Ha olje i ei panne og stek tomater og paprika. Tilsett litt salt og pepper. La dette steke i 6 minutter.\n    Kok opp vann til pasta. Tilsett hvitløk til tomatene og paprikaen å la det steke i 4 minutter.\n    Tilsett halvparten av kryddere og stek i 3 minutter\n    Tilsett kyllingbuljong og kok i 10 minutter\n    La sausen kjøle seg ned før den blendes sammen med kesam og blend til den er kremet\n    Kok pasta 1 minutt mindre enn pakken krever\n    Stek kjøttdeig til den er nesten helt gjennomstekt. Tilsett resten av kryddere\n    Tilsett sausen fra blenderen til kjøttdeigen og la det steke i 2 minutter\n    Når pastaen er ferdig hell den over til kjøttdeigen og sausen. Bland og la den koke i 1-2 minutter\n", "Creamy Garlic Pasta" });

            migrationBuilder.CreateIndex(
                name: "IX_RecipeTag_TagsId",
                table: "RecipeTag",
                column: "TagsId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RecipeTag");

            migrationBuilder.DropTable(
                name: "Recipes");

            migrationBuilder.DropTable(
                name: "Tags");
        }
    }
}
