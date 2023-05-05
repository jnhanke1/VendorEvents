using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VendorEvents_1.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Event",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    EventName = table.Column<string>(type: "TEXT", nullable: false),
                    EventLocation = table.Column<string>(type: "TEXT", nullable: false),
                    EventStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    EventCost = table.Column<decimal>(type: "TEXT", nullable: false),
                    EventContactName = table.Column<string>(type: "TEXT", nullable: false),
                    EventPhone = table.Column<int>(type: "INTEGER", nullable: false),
                    EventEmail = table.Column<string>(type: "TEXT", nullable: false),
                    EventComments = table.Column<string>(type: "TEXT", nullable: false),
                    EventPaid = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false),
                    EventBooked = table.Column<string>(type: "TEXT", maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Event", x => x.EventID);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                columns: table => new
                {
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ProductName = table.Column<string>(type: "TEXT", nullable: false),
                    ProductDescription = table.Column<string>(type: "TEXT", nullable: false),
                    ProductPrice = table.Column<decimal>(type: "TEXT", nullable: false),
                    ProductQty = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductSource = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Product", x => x.ProductID);
                });

            migrationBuilder.CreateTable(
                name: "EventProduct",
                columns: table => new
                {
                    EventID = table.Column<int>(type: "INTEGER", nullable: false),
                    ProductID = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventProduct", x => new { x.ProductID, x.EventID });
                    table.ForeignKey(
                        name: "FK_EventProduct_Event_EventID",
                        column: x => x.EventID,
                        principalTable: "Event",
                        principalColumn: "EventID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventProduct_Product_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Product",
                        principalColumn: "ProductID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventProduct_EventID",
                table: "EventProduct",
                column: "EventID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventProduct");

            migrationBuilder.DropTable(
                name: "Event");

            migrationBuilder.DropTable(
                name: "Product");
        }
    }
}
