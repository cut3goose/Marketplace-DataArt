using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.User.Persistence.Migrations
{
    public partial class ChangeUserIdMaxLengthTo64 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                table: "user_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_asp_net_users_user_id",
                table: "user_login");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_users_user_id",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_asp_net_users_user_id",
                table: "user_token");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_tokens",
                table: "user_token");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                table: "user_role");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_token",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_role",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_login",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_claim",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "user",
                maxLength: 64,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_tokens",
                table: "user_token",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "user_role",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                table: "user_claim",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_asp_net_users_user_id",
                table: "user_login",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_asp_net_users_user_id",
                table: "user_role",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_asp_net_users_user_id",
                table: "user_token",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                table: "user_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_asp_net_users_user_id",
                table: "user_login");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_users_user_id",
                table: "user_role");

            migrationBuilder.DropForeignKey(
                name: "fk_user_tokens_asp_net_users_user_id",
                table: "user_token");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_tokens",
                table: "user_token");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_roles",
                table: "user_role");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "user");

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_token",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_role",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_login",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "user_id",
                table: "user_claim",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "id",
                table: "user",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldMaxLength: 64);

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_tokens",
                table: "user_token",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "user_role",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "user",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                table: "user_claim",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_logins_asp_net_users_user_id",
                table: "user_login",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_roles_asp_net_users_user_id",
                table: "user_role",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_user_tokens_asp_net_users_user_id",
                table: "user_token",
                column: "user_id",
                principalTable: "user",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
