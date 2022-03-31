using Microsoft.EntityFrameworkCore.Migrations;

namespace OnlineShop.User.Persistence.Migrations
{
    public partial class ApplySnakeCase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "AspNetUsers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "AspNetUserTokens",
                newName: "user_token");

            migrationBuilder.RenameTable(
                name: "AspNetUsers",
                newName: "user");

            migrationBuilder.RenameTable(
                name: "AspNetUserRoles",
                newName: "user_role");

            migrationBuilder.RenameTable(
                name: "AspNetUserLogins",
                newName: "user_login");

            migrationBuilder.RenameTable(
                name: "AspNetUserClaims",
                newName: "user_claim");

            migrationBuilder.RenameTable(
                name: "AspNetRoles",
                newName: "role");

            migrationBuilder.RenameTable(
                name: "AspNetRoleClaims",
                newName: "role_claim");

            migrationBuilder.RenameColumn(
                name: "Value",
                table: "user_token",
                newName: "value");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "user_token",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "user_token",
                newName: "login_provider");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_token",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "username",
                table: "user",
                newName: "user_name");

            migrationBuilder.RenameColumn(
                name: "normalized_username",
                table: "user",
                newName: "normalized_user_name");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "user",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "user_role",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_role",
                newName: "user_id");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "user_role",
                newName: "ix_user_roles_role_id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_login",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ProviderDisplayName",
                table: "user_login",
                newName: "provider_display_name");

            migrationBuilder.RenameColumn(
                name: "ProviderKey",
                table: "user_login",
                newName: "provider_key");

            migrationBuilder.RenameColumn(
                name: "LoginProvider",
                table: "user_login",
                newName: "login_provider");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "user_login",
                newName: "ix_user_logins_user_id");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "user_claim",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "user_claim",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "user_claim",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "user_claim",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "user_claim",
                newName: "ix_user_claims_user_id");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "role",
                newName: "name");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "role",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "NormalizedName",
                table: "role",
                newName: "normalized_name");

            migrationBuilder.RenameColumn(
                name: "ConcurrencyStamp",
                table: "role",
                newName: "concurrency_stamp");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "role_claim",
                newName: "id");

            migrationBuilder.RenameColumn(
                name: "RoleId",
                table: "role_claim",
                newName: "role_id");

            migrationBuilder.RenameColumn(
                name: "ClaimValue",
                table: "role_claim",
                newName: "claim_value");

            migrationBuilder.RenameColumn(
                name: "ClaimType",
                table: "role_claim",
                newName: "claim_type");

            migrationBuilder.RenameIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "role_claim",
                newName: "ix_role_claims_role_id");

            migrationBuilder.AlterColumn<string>(
                name: "normalized_email",
                table: "user",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "user",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(256)",
                oldMaxLength: 256,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_tokens",
                table: "user_token",
                columns: new[] { "user_id", "login_provider", "name" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_users",
                table: "user",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_roles",
                table: "user_role",
                columns: new[] { "user_id", "role_id" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_logins",
                table: "user_login",
                columns: new[] { "login_provider", "provider_key" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_user_claims",
                table: "user_claim",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_roles",
                table: "role",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_role_claims",
                table: "role_claim",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "user",
                column: "normalized_user_name",
                unique: true,
                filter: "[normalized_user_name] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "role",
                column: "normalized_name",
                unique: true,
                filter: "[normalized_name] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "fk_role_claims_asp_net_roles_identity_role_id",
                table: "role_claim",
                column: "role_id",
                principalTable: "role",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
                name: "fk_user_roles_asp_net_roles_identity_role_id",
                table: "user_role",
                column: "role_id",
                principalTable: "role",
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
                name: "fk_role_claims_asp_net_roles_identity_role_id",
                table: "role_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_user_claims_asp_net_users_user_id",
                table: "user_claim");

            migrationBuilder.DropForeignKey(
                name: "fk_user_logins_asp_net_users_user_id",
                table: "user_login");

            migrationBuilder.DropForeignKey(
                name: "fk_user_roles_asp_net_roles_identity_role_id",
                table: "user_role");

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
                name: "pk_user_logins",
                table: "user_login");

            migrationBuilder.DropPrimaryKey(
                name: "pk_user_claims",
                table: "user_claim");

            migrationBuilder.DropPrimaryKey(
                name: "pk_users",
                table: "user");

            migrationBuilder.DropIndex(
                name: "UserNameIndex",
                table: "user");

            migrationBuilder.DropPrimaryKey(
                name: "pk_role_claims",
                table: "role_claim");

            migrationBuilder.DropPrimaryKey(
                name: "pk_roles",
                table: "role");

            migrationBuilder.DropIndex(
                name: "RoleNameIndex",
                table: "role");

            migrationBuilder.RenameTable(
                name: "user_token",
                newName: "AspNetUserTokens");

            migrationBuilder.RenameTable(
                name: "user_role",
                newName: "AspNetUserRoles");

            migrationBuilder.RenameTable(
                name: "user_login",
                newName: "AspNetUserLogins");

            migrationBuilder.RenameTable(
                name: "user_claim",
                newName: "AspNetUserClaims");

            migrationBuilder.RenameTable(
                name: "user",
                newName: "AspNetUsers");

            migrationBuilder.RenameTable(
                name: "role_claim",
                newName: "AspNetRoleClaims");

            migrationBuilder.RenameTable(
                name: "role",
                newName: "AspNetRoles");

            migrationBuilder.RenameColumn(
                name: "value",
                table: "AspNetUserTokens",
                newName: "Value");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetUserTokens",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserTokens",
                newName: "LoginProvider");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserTokens",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "AspNetUserRoles",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserRoles",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "ix_user_roles_role_id",
                table: "AspNetUserRoles",
                newName: "IX_AspNetUserRoles_RoleId");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserLogins",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "provider_display_name",
                table: "AspNetUserLogins",
                newName: "ProviderDisplayName");

            migrationBuilder.RenameColumn(
                name: "provider_key",
                table: "AspNetUserLogins",
                newName: "ProviderKey");

            migrationBuilder.RenameColumn(
                name: "login_provider",
                table: "AspNetUserLogins",
                newName: "LoginProvider");

            migrationBuilder.RenameIndex(
                name: "ix_user_logins_user_id",
                table: "AspNetUserLogins",
                newName: "IX_AspNetUserLogins_UserId");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUserClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "user_id",
                table: "AspNetUserClaims",
                newName: "UserId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetUserClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetUserClaims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "ix_user_claims_user_id",
                table: "AspNetUserClaims",
                newName: "IX_AspNetUserClaims_UserId");

            migrationBuilder.RenameColumn(
                name: "user_name",
                table: "AspNetUsers",
                newName: "username");

            migrationBuilder.RenameColumn(
                name: "normalized_user_name",
                table: "AspNetUsers",
                newName: "normalized_username");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetUsers",
                newName: "user_id");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoleClaims",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "role_id",
                table: "AspNetRoleClaims",
                newName: "RoleId");

            migrationBuilder.RenameColumn(
                name: "claim_value",
                table: "AspNetRoleClaims",
                newName: "ClaimValue");

            migrationBuilder.RenameColumn(
                name: "claim_type",
                table: "AspNetRoleClaims",
                newName: "ClaimType");

            migrationBuilder.RenameIndex(
                name: "ix_role_claims_role_id",
                table: "AspNetRoleClaims",
                newName: "IX_AspNetRoleClaims_RoleId");

            migrationBuilder.RenameColumn(
                name: "name",
                table: "AspNetRoles",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "id",
                table: "AspNetRoles",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "normalized_name",
                table: "AspNetRoles",
                newName: "NormalizedName");

            migrationBuilder.RenameColumn(
                name: "concurrency_stamp",
                table: "AspNetRoles",
                newName: "ConcurrencyStamp");

            migrationBuilder.AlterColumn<string>(
                name: "normalized_email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "AspNetUsers",
                type: "nvarchar(256)",
                maxLength: 256,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserTokens",
                table: "AspNetUserTokens",
                columns: new[] { "UserId", "LoginProvider", "Name" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserRoles",
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserLogins",
                table: "AspNetUserLogins",
                columns: new[] { "LoginProvider", "ProviderKey" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUserClaims",
                table: "AspNetUserClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetUsers",
                table: "AspNetUsers",
                column: "user_id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoleClaims",
                table: "AspNetRoleClaims",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AspNetRoles",
                table: "AspNetRoles",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "normalized_username",
                unique: true,
                filter: "[normalized_username] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                table: "AspNetUserClaims",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                table: "AspNetUserLogins",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId",
                principalTable: "AspNetRoles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                table: "AspNetUserRoles",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                table: "AspNetUserTokens",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "user_id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
