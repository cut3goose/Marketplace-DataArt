using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Order.Persistence.Migrations
{
    public partial class AddOrderDomainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "order",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_id = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    ship_date = table.Column<DateTime>(nullable: false),
                    cancel_date = table.Column<DateTime>(nullable: true),
                    cancel_reason = table.Column<int>(nullable: true),
                    status = table.Column<int>(nullable: false),
                    shipping_type = table.Column<int>(nullable: false),
                    shipping_price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    address = table.Column<string>(nullable: false),
                    payment_type = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order", x => x.order_id);
                });

            migrationBuilder.CreateTable(
                name: "order_product",
                columns: table => new
                {
                    order_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<float>(nullable: true),
                    quantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_order_product", x => new { x.order_id, x.product_id });
                    table.ForeignKey(
                        name: "FK_order_product_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "transaction",
                columns: table => new
                {
                    transaction_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    order_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: false),
                    status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_transaction", x => x.transaction_id);
                    table.ForeignKey(
                        name: "FK_transaction_order_order_id",
                        column: x => x.order_id,
                        principalTable: "order",
                        principalColumn: "order_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_transaction_order_id",
                table: "transaction",
                column: "order_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "order_product");

            migrationBuilder.DropTable(
                name: "transaction");

            migrationBuilder.DropTable(
                name: "order");
        }
    }
}
