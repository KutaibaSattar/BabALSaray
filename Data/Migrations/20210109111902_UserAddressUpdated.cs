using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.data.migrations
{
    public partial class UserAddressUpdated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address_Email",
                table: "dbAccounts");

            migrationBuilder.RenameColumn(
                name: "Address_Line2",
                table: "dbAccounts",
                newName: "Address_LastName");

            migrationBuilder.RenameColumn(
                name: "Address_Line1",
                table: "dbAccounts",
                newName: "Address_FirstName");

            migrationBuilder.RenameColumn(
                name: "Address_Line2",
                table: "AspNetUsers",
                newName: "DisplayName");

            migrationBuilder.RenameColumn(
                name: "Address_Line1",
                table: "AspNetUsers",
                newName: "Address_LastName");

            migrationBuilder.RenameColumn(
                name: "Address_Email",
                table: "AspNetUsers",
                newName: "Address_FirstName");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Address_LastName",
                table: "dbAccounts",
                newName: "Address_Line2");

            migrationBuilder.RenameColumn(
                name: "Address_FirstName",
                table: "dbAccounts",
                newName: "Address_Line1");

            migrationBuilder.RenameColumn(
                name: "DisplayName",
                table: "AspNetUsers",
                newName: "Address_Line2");

            migrationBuilder.RenameColumn(
                name: "Address_LastName",
                table: "AspNetUsers",
                newName: "Address_Line1");

            migrationBuilder.RenameColumn(
                name: "Address_FirstName",
                table: "AspNetUsers",
                newName: "Address_Email");

            migrationBuilder.AddColumn<string>(
                name: "Address_Email",
                table: "dbAccounts",
                type: "TEXT",
                nullable: true);
        }
    }
}
