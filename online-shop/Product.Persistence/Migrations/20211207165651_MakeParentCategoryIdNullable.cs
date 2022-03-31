using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Product.Persistence.Migrations
{
    public partial class MakeParentCategoryIdNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "parent_category_id",
                table: "category",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "parent_category_id",
                table: "category",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);
        }
    }
}
