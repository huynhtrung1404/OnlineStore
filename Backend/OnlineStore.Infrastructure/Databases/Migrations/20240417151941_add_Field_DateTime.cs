using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OnlineStore.Infrastructure.Databases.Migrations
{
    /// <inheritdoc />
    public partial class add_Field_DateTime : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 4, 17, 15, 19, 41, 18, DateTimeKind.Utc).AddTicks(9216));

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Category",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "CreatedDateTime",
                schema: "OnlineStore",
                table: "Category");
        }
    }
}
