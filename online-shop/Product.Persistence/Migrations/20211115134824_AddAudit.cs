using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Product.Persistence.Migrations
{
    public partial class AddAudit : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "tag",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "tag",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "review_rating",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "review_rating",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "review",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "review",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "product_tag",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "product_tag",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "product_photo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "product_photo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "product_category",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "product_category",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "product",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "product",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "photo",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "photo",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "meta",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "meta",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "favorite",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "favorite",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "created_at",
                table: "category",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "updated_at",
                table: "category",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "created_at",
                table: "tag");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "tag");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "review_rating");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "review_rating");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "review");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "review");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "product_tag");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "product_tag");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "product_photo");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "product_photo");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "product_category");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "product_category");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "product");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "product");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "photo");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "photo");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "meta");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "meta");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "favorite");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "favorite");

            migrationBuilder.DropColumn(
                name: "created_at",
                table: "category");

            migrationBuilder.DropColumn(
                name: "updated_at",
                table: "category");
        }
    }
}
