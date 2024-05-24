using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HippoRecipeApi.Migrations
{
    /// <inheritdoc />
    public partial class AmountIngredient : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "IngredientRecipe",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Amount",
                table: "IngredientRecipe");
        }
    }
}
