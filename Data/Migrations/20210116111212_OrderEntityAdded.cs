﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BabALSaray.data.migrations
{
    public partial class OrderEntityAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "OrderMethods",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ShortName = table.Column<string>(type: "TEXT", nullable: true),
                    OrderTime = table.Column<string>(type: "TEXT", nullable: true),
                    Description = table.Column<int>(type: "INTEGER", nullable: false),
                    Price = table.Column<double>(type: "REAL", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderMethods", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    BuyerEmail = table.Column<string>(type: "TEXT", nullable: true),
                    OrderDate = table.Column<DateTimeOffset>(type: "TEXT", nullable: false),
                    OrderAddress_Line1 = table.Column<string>(type: "TEXT", nullable: true),
                    OrderAddress_Line2 = table.Column<string>(type: "TEXT", nullable: true),
                    OrderAddress_Region = table.Column<string>(type: "TEXT", nullable: true),
                    OrderAddress_City = table.Column<string>(type: "TEXT", nullable: true),
                    OrderAddress_Country = table.Column<string>(type: "TEXT", nullable: true),
                    OrderMethodId = table.Column<int>(type: "INTEGER", nullable: true),
                    Subtotal = table.Column<double>(type: "REAL", nullable: false),
                    Status = table.Column<int>(type: "nvarchar(10)", nullable: false),
                    PaymentIntentId = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_OrderMethods_OrderMethodId",
                        column: x => x.OrderMethodId,
                        principalTable: "OrderMethods",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ItemOrdered_ProductItemId = table.Column<int>(type: "INTEGER", nullable: true),
                    ItemOrdered_ProductName = table.Column<string>(type: "TEXT", nullable: true),
                    ItemOrdered_pictureUrl = table.Column<string>(type: "TEXT", nullable: true),
                    Price = table.Column<double>(type: "REAL", nullable: false),
                    Quantity = table.Column<double>(type: "REAL", nullable: false),
                    OrderId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderMethodId",
                table: "Orders",
                column: "OrderMethodId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "OrderMethods");
        }
    }
}
