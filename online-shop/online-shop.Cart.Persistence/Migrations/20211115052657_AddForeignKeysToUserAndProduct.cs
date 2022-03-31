using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Cart.Persistence.Migrations
{
    public partial class AddForeignKeysToUserAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_cart_user_user_id",
                table: "cart",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_cart_product_product_product_id",
                table: "cart_product",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_cart_user_user_id",
                table: "cart");

            migrationBuilder.DropForeignKey(
                name: "FK_cart_product_product_product_id",
                table: "cart_product");
        }
    }
}
