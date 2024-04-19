using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Infrastructure.Databases.Migrations
{
    /// <inheritdoc />
    public partial class Update_Account_link : Migration
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
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 356, DateTimeKind.Utc).AddTicks(2483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 516, DateTimeKind.Utc).AddTicks(9513));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 352, DateTimeKind.Utc).AddTicks(4488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 514, DateTimeKind.Utc).AddTicks(6718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(7921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 514, DateTimeKind.Utc).AddTicks(2866));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 512, DateTimeKind.Utc).AddTicks(6151));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 343, DateTimeKind.Utc).AddTicks(318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 507, DateTimeKind.Utc).AddTicks(8481));

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                schema: "OnlineStore",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                schema: "OnlineStore",
                table: "Accounts",
                column: "CustomerId",
                principalSchema: "OnlineStore",
                principalTable: "Customers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Customers_CustomerId",
                schema: "OnlineStore",
                table: "Accounts");

            migrationBuilder.DropIndex(
                name: "IX_Accounts_CustomerId",
                schema: "OnlineStore",
                table: "Accounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 516, DateTimeKind.Utc).AddTicks(9513),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 356, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 514, DateTimeKind.Utc).AddTicks(6718),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 352, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 514, DateTimeKind.Utc).AddTicks(2866),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 512, DateTimeKind.Utc).AddTicks(6151),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 10, 23, 7, 507, DateTimeKind.Utc).AddTicks(8481),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 343, DateTimeKind.Utc).AddTicks(318));
        }
    }
}
