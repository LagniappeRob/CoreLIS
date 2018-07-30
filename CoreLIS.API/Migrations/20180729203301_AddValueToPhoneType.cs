using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreLIS.API.Migrations
{
    public partial class AddValueToPhoneType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Value",
                table: "PhoneTypes",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "PhoneTypes");
        }
    }
}
