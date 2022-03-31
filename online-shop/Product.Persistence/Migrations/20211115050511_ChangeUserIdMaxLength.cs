using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Product.Persistence.Migrations
{
    public partial class ChangeUserIdMaxLength : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_favorite",
                table: "favorite");

            migrationBuilder.DropPrimaryKey(
                name: "pk_review_rating",
                table: "review_rating");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "favorite",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "review",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "review_rating",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddPrimaryKey(
                name: "pk_favorite",
                table: "favorite",
                columns: new[] { "product_id", "user_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_review_rating",
                table: "review_rating",
                columns: new[] { "review_id", "user_id" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "pk_favorite",
                table: "favorite");

            migrationBuilder.DropPrimaryKey(
                name: "pk_review_rating",
                table: "review_rating");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "favorite",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "review",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "review_rating",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "pk_favorite",
                table: "favorite",
                columns: new[] { "product_id", "user_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_review_rating",
                table: "review_rating",
                columns: new[] { "review_id", "user_id" });
        }
    }
}
