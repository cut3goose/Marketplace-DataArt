using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.Product.Persistence.Migrations
{
    public partial class AddProductDomainEntities : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "photo",
                columns: table => new
                {
                    photo_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    size = table.Column<int>(nullable: false),
                    file = table.Column<byte[]>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photo", x => x.photo_id);
                });

            migrationBuilder.CreateTable(
                name: "tag",
                columns: table => new
                {
                    tag_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tag", x => x.tag_id);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    category_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    parent_category_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 20, nullable: false),
                    photo_id = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_category", x => x.category_id);
                    table.ForeignKey(
                        name: "FK_category_category_parent_category_id",
                        column: x => x.parent_category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_category_photo_photo_id",
                        column: x => x.photo_id,
                        principalTable: "photo",
                        principalColumn: "photo_id");
                });

            migrationBuilder.CreateTable(
                name: "product",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    category_id = table.Column<int>(nullable: false),
                    name = table.Column<string>(maxLength: 50, nullable: false),
                    price = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    discount = table.Column<float>(nullable: true),
                    description = table.Column<string>(maxLength: 255, nullable: true),
                    quantity = table.Column<int>(nullable: false),
                    sku = table.Column<string>(nullable: true),
                    published_at = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product", x => x.product_id);
                    table.ForeignKey(
                        name: "FK_product_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "favorite",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_favorite", x => new { x.product_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_favorite_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meta",
                columns: table => new
                {
                    meta_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    type = table.Column<string>(maxLength: 50, nullable: false),
                    key = table.Column<string>(maxLength: 50, nullable: false),
                    value = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meta", x => x.meta_id);
                    table.ForeignKey(
                        name: "FK_meta_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_category",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false),
                    category_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_category", x => new { x.product_id, x.category_id });
                    table.ForeignKey(
                        name: "FK_product_category_category_category_id",
                        column: x => x.category_id,
                        principalTable: "category",
                        principalColumn: "category_id",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_product_category_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_photo",
                columns: table => new
                {
                    photo_id = table.Column<int>(nullable: false),
                    product_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_photo", x => x.photo_id);
                    table.ForeignKey(
                        name: "FK_product_photo_photo_photo_id",
                        column: x => x.photo_id,
                        principalTable: "photo",
                        principalColumn: "photo_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_photo_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "product_tag",
                columns: table => new
                {
                    product_id = table.Column<int>(nullable: false),
                    tag_id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_tag", x => new { x.product_id, x.tag_id });
                    table.ForeignKey(
                        name: "FK_product_tag_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_product_tag_tag_tag_id",
                        column: x => x.tag_id,
                        principalTable: "tag",
                        principalColumn: "tag_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "review",
                columns: table => new
                {
                    review_id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    product_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: false),
                    date = table.Column<DateTime>(nullable: false),
                    grade = table.Column<int>(nullable: false),
                    pros = table.Column<string>(maxLength: 255, nullable: false),
                    cons = table.Column<string>(maxLength: 255, nullable: false),
                    comment = table.Column<string>(maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review", x => x.review_id);
                    table.ForeignKey(
                        name: "FK_review_product_product_id",
                        column: x => x.product_id,
                        principalTable: "product",
                        principalColumn: "product_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "review_rating",
                columns: table => new
                {
                    review_id = table.Column<int>(nullable: false),
                    user_id = table.Column<string>(nullable: false),
                    opinion = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_review_rating", x => new { x.review_id, x.user_id });
                    table.ForeignKey(
                        name: "FK_review_rating_review_review_id",
                        column: x => x.review_id,
                        principalTable: "review",
                        principalColumn: "review_id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_category_parent_category_id",
                table: "category",
                column: "parent_category_id");

            migrationBuilder.CreateIndex(
                name: "IX_category_photo_id",
                table: "category",
                column: "photo_id",
                unique: true,
                filter: "[photo_id] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_meta_product_id",
                table: "meta",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_id",
                table: "product",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_category_category_id",
                table: "product_category",
                column: "category_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_photo_product_id",
                table: "product_photo",
                column: "product_id");

            migrationBuilder.CreateIndex(
                name: "IX_product_tag_tag_id",
                table: "product_tag",
                column: "tag_id");

            migrationBuilder.CreateIndex(
                name: "IX_review_product_id",
                table: "review",
                column: "product_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "favorite");

            migrationBuilder.DropTable(
                name: "meta");

            migrationBuilder.DropTable(
                name: "product_category");

            migrationBuilder.DropTable(
                name: "product_photo");

            migrationBuilder.DropTable(
                name: "product_tag");

            migrationBuilder.DropTable(
                name: "review_rating");

            migrationBuilder.DropTable(
                name: "tag");

            migrationBuilder.DropTable(
                name: "review");

            migrationBuilder.DropTable(
                name: "product");

            migrationBuilder.DropTable(
                name: "category");

            migrationBuilder.DropTable(
                name: "photo");
        }
    }
}
