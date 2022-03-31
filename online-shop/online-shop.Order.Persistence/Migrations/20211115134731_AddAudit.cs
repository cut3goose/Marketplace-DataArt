using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Order.Persistence.Migrations
{
    public partial class AddAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "transaction",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "transaction",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "order_product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "order_product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "order",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "order",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "transaction");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "order_product");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "order_product");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "order");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "order");
        }
    }
}
