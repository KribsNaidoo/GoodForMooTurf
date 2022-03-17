using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GoodForMooTurf.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Reference = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CaptureDate = table.Column<DateTime>(nullable: false),
                    DueDate = table.Column<DateTime>(nullable: false),
                    UserId = table.Column<int>(nullable: false),
                    VAT = table.Column<decimal>(nullable: false),
                    GrandTotal = table.Column<decimal>(nullable: false),
                    SubTotal = table.Column<decimal>(nullable: false),
                    TotalVAT = table.Column<decimal>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Reference);
                    table.ForeignKey(
                        name: "FK_Orders_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "OrderItems",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(nullable: true),
                    UnitCostAmount = table.Column<decimal>(nullable: false),
                    Quantity = table.Column<int>(nullable: false),
                    TotalAmount = table.Column<decimal>(nullable: false),
                    OrderId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OrderItems_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Reference",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Customers",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Adam" },
                    { 2, "Bob" },
                    { 3, "Chris" },
                    { 4, "Dave" }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "John", "J0hn" },
                    { 2, "Doe", "D0e" }
                });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Reference", "CaptureDate", "CustomerId", "DueDate", "GrandTotal", "SubTotal", "TotalVAT", "UserId", "VAT" },
                values: new object[] { 1, new DateTime(2022, 3, 15, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, new DateTime(2022, 3, 31, 0, 0, 0, 0, DateTimeKind.Unspecified), 1800m, 1500m, 300m, 1, 20m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Reference", "CaptureDate", "CustomerId", "DueDate", "GrandTotal", "SubTotal", "TotalVAT", "UserId", "VAT" },
                values: new object[] { 2, new DateTime(2022, 3, 16, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, new DateTime(2022, 3, 25, 0, 0, 0, 0, DateTimeKind.Unspecified), 2200m, 2000m, 200m, 1, 10m });

            migrationBuilder.InsertData(
                table: "Orders",
                columns: new[] { "Reference", "CaptureDate", "CustomerId", "DueDate", "GrandTotal", "SubTotal", "TotalVAT", "UserId", "VAT" },
                values: new object[] { 3, new DateTime(2022, 3, 17, 0, 0, 0, 0, DateTimeKind.Unspecified), 4, new DateTime(2022, 3, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), 3750m, 3000m, 750m, 1, 25m });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Description", "OrderId", "Quantity", "TotalAmount", "UnitCostAmount" },
                values: new object[] { 1, "Dichondra", 1, 10, 1500m, 150m });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Description", "OrderId", "Quantity", "TotalAmount", "UnitCostAmount" },
                values: new object[] { 3, "Bermuda", 2, 4, 3000m, 750m });

            migrationBuilder.InsertData(
                table: "OrderItems",
                columns: new[] { "Id", "Description", "OrderId", "Quantity", "TotalAmount", "UnitCostAmount" },
                values: new object[] { 2, "Perennial Ryegrass", 3, 4, 2000m, 500m });

            migrationBuilder.CreateIndex(
                name: "IX_OrderItems_OrderId",
                table: "OrderItems",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CustomerId",
                table: "Orders",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_UserId",
                table: "Orders",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OrderItems");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
