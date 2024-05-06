using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Infrastructure.Databases.Migrations
{
    /// <inheritdoc />
    public partial class Update_Account : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 45, DateTimeKind.Utc).AddTicks(7745),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 356, DateTimeKind.Utc).AddTicks(2483));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<Guid>(
                name: "SessionId",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(4020),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 352, DateTimeKind.Utc).AddTicks(4488));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(188),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(7921));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 42, DateTimeKind.Utc).AddTicks(6166),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(867));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 37, DateTimeKind.Utc).AddTicks(2694),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 343, DateTimeKind.Utc).AddTicks(318));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SessionId",
                schema: "OnlineStore",
                table: "UserTokens");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 356, DateTimeKind.Utc).AddTicks(2483),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 45, DateTimeKind.Utc).AddTicks(7745));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "UserTokens",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 352, DateTimeKind.Utc).AddTicks(4488),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(4020));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(7921),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 43, DateTimeKind.Utc).AddTicks(188));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Customers",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 351, DateTimeKind.Utc).AddTicks(867),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 42, DateTimeKind.Utc).AddTicks(6166));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Categories",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedDate",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 19, 12, 30, 25, 343, DateTimeKind.Utc).AddTicks(318),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 5, 6, 4, 44, 18, 37, DateTimeKind.Utc).AddTicks(2694));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedDate",
                schema: "OnlineStore",
                table: "Accounts",
                type: "datetime2",
                nullable: true,
                defaultValue: new DateTime(2024, 4, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true,
                oldDefaultValue: new DateTime(2024, 5, 6, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }
    }
}
