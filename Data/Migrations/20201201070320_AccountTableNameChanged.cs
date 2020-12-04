using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.Data.Migrations
{
    public partial class AccountTableNameChanged : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Accounts_ParentId",
                table: "Accounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts");

            migrationBuilder.RenameTable(
                name: "Accounts",
                newName: "dbAccounts");

            migrationBuilder.RenameIndex(
                name: "IX_Accounts_ParentId",
                table: "dbAccounts",
                newName: "IX_dbAccounts_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_dbAccounts",
                table: "dbAccounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_dbAccounts_dbAccounts_ParentId",
                table: "dbAccounts",
                column: "ParentId",
                principalTable: "dbAccounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_dbAccounts_dbAccounts_ParentId",
                table: "dbAccounts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_dbAccounts",
                table: "dbAccounts");

            migrationBuilder.RenameTable(
                name: "dbAccounts",
                newName: "Accounts");

            migrationBuilder.RenameIndex(
                name: "IX_dbAccounts_ParentId",
                table: "Accounts",
                newName: "IX_Accounts_ParentId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Accounts",
                table: "Accounts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Accounts_ParentId",
                table: "Accounts",
                column: "ParentId",
                principalTable: "Accounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
