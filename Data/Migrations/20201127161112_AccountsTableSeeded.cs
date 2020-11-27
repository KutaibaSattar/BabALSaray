using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.Data.Migrations
{
    public partial class AccountsTableSeeded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('All Accounts','All Accounts',NULL,0)");//1
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Balance Sheet','Balance Sheet',1,1)");//2
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Assets','Assets',2,2)");//3
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Fixed Assets','Fixed Assets',3,3)");//4
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Current Assets','Current Assets',3,3)");//5
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Stores','Stores',5,3)");//6
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Cashs','Cashs',5,3)");//7
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Banks','Banks',5,3)");//8
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Clients','Clients',5,3)");//9
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Liabilities','Liabilities',2,2)");//10
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Fixed Liabilities','Fixed Liabilities',10,3)");//11
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Capital','Capital',11,4)");//12
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Current Liabilities','Current Liabilities',10,3)");//13
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Suppliers','Suppliers',13,4)");//14
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Accumulated Profit','Accumulated Profit',13,4)");//15
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Profit And Loss','Profit And Loss',1,1)"); //16
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Expenses','Expenses',16,2)"); //17
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Trading Expenses','Trading Expenses',17,3)");//18
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Selling Cost','Selling Cost',18,4)");//19
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Goods Sold','Goods Sold',18,4)");//20
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Other Expenses','Other Expenses',17,3)"); //21
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Incomes','Incomes',16,2)"); //22
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Trading Incomes','Trading Incomes',22,3)"); //23
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Revenue','Revenue',23,4)"); //24
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Sales Revenue','Sales Revenue',23,4)"); //25
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Service revenue','Service revenue',23,4)"); //26
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Discount Given','Discount Given',23,4)"); //27
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Other Income','Other Income',22,3)"); //28
            migrationBuilder.Sql("Insert Into Accounts (Name,Key,ParentId,lvl) values ('Miscellaneous revenues','Miscellaneous revenues',28,4)"); //29


        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
