using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Cart.Persistence.Migrations
{
    public partial class AddAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "cart_product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "cart_product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "cart",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "cart",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "cart_product");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "cart_product");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "cart");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "cart");
        }
    }
}
