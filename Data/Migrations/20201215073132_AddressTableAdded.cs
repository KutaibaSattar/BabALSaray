using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.data.migrations
{
    public partial class AddressTableAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Address_City",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Country",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Email",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line1",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Line2",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Address_Region",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_City",
                table: "dbAccounts");

            migrationBuilder.DropColumn(
                name: "Address_Country",
                table: "dbAccounts");

            migrationBuilder.DropColumn(
                name: "Address_Email",
                table: "dbAccounts");

            migrationBuilder.DropColumn(
                name: "Address_Line1",
                table: "dbAccounts");

            migrationBuilder.DropColumn(
                name: "Address_Line2",
                table: "dbAccounts");

            migrationBuilder.DropColumn(
                name: "Address_Region",
                table: "dbAccounts");
        }
    }
}
