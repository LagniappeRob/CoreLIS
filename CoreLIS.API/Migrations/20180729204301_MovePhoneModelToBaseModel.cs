using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreLIS.API.Migrations
{
    public partial class MovePhoneModelToBaseModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatedBy",
                table: "Phone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedOn",
                table: "Phone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "LastModifiedBy",
                table: "Phone",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedOn",
                table: "Phone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedBy",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "CreatedOn",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "LastModifiedBy",
                table: "Phone");

            migrationBuilder.DropColumn(
                name: "LastModifiedOn",
                table: "Phone");
        }
    }
}
