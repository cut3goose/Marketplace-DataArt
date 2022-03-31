using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Cart.Persistence.Migrations
{
    public partial class AddCartDomainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cart",
                columns: table => new
                {
                    cart_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart", x => x.cart_id);
                });

            migrationBuilder.CreateTable(
                name: "cart_product",
                columns: table => new
                {
                    cart_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cart_product", x => new { x.cart_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_cart_product_cart_cart_id",
                        column: x => x.cart_id,
                        principalTable: "cart",
                        principalColumn: "cart_id",
                        onDelete: ReferentialAction.Cascade);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "cart_product");

            migrationBuilder.DropTable(
                name: "cart");
        }
    }
}
