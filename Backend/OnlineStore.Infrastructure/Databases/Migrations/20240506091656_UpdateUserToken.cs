using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Infrastructure.Databases.Migrations
{
    /// <inheritdoc />
    public partial class UpdateUserToken : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 819, DateTimeKind.Utc).AddTicks(6722),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 45, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpire",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 812, DateTimeKind.Utc).AddTicks(7769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 811, DateTimeKind.Utc).AddTicks(8838),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 811, DateTimeKind.Utc).AddTicks(860),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 42, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 800, DateTimeKind.Utc).AddTicks(6990),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 37, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.CreateIndex(
                name: "IX_UserTokens_RefreshToken",
                schema: "OnlineStore",
                table: "UserTokens",
                column: "RefreshToken");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_UserTokens_RefreshToken",
                schema: "OnlineStore",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                schema: "OnlineStore",
                table: "UserTokens");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpire",
                schema: "OnlineStore",
                table: "UserTokens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 45, DateTimeKind.Utc).AddTicks(7745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 819, DateTimeKind.Utc).AddTicks(6722));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(4020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 812, DateTimeKind.Utc).AddTicks(7769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 811, DateTimeKind.Utc).AddTicks(8838));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 42, DateTimeKind.Utc).AddTicks(6166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 811, DateTimeKind.Utc).AddTicks(860));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 37, DateTimeKind.Utc).AddTicks(2694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 9, 16, 55, 800, DateTimeKind.Utc).AddTicks(6990));
        }
    }
}
