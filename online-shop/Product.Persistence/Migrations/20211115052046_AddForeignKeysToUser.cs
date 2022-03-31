using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Product.Persistence.Migrations
{
    public partial class AddForeignKeysToUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_favorite_user_user_id",
                table: "favorite",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_user_user_id",
                table: "review",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_review_rating_user_user_id",
                table: "review_rating",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_favorite_user_user_id",
                table: "favorite");

            migrationBuilder.DropForeignKey(
                name: "FK_review_user_user_id",
                table: "review");

            migrationBuilder.DropForeignKey(
                name: "FK_review_rating_user_user_id",
                table: "review_rating");
        }
    }
}
