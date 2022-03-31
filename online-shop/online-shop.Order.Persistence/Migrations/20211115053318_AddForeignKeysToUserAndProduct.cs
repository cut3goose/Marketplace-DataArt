using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Order.Persistence.Migrations
{
    public partial class AddForeignKeysToUserAndProduct : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_order_user_user_id",
                table: "order",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_transaction_user_user_id",
                table: "transaction",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_order_product_product_product_id",
                table: "order_product",
                column: "product_id",
                principalTable: "product",
                principalColumn: "product_id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_order_user_user_id",
                table: "order");

            migrationBuilder.DropForeignKey(
                name: "FK_transaction_user_user_id",
                table: "transaction");

            migrationBuilder.DropForeignKey(
                name: "FK_order_product_product_product_id",
                table: "order_product");
        }
    }
}
