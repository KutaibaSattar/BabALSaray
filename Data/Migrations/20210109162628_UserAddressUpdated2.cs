using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.data.migrations
{
    public partial class UserAddressUpdated2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "Address_LastName",
                table: "AspNetUsers",
                newName: "Address_Line2");

            migrationBuilder.RenameColumn(
                name: "Address_FirstName",
                table: "AspNetUsers",
                newName: "Address_Line1");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                newName: "Address_LastName");

            migrationBuilder.RenameColumn(
                name: "Address_Line1",
                table: "AspNetUsers",
                newName: "Address_FirstName");
        }
    }
}
