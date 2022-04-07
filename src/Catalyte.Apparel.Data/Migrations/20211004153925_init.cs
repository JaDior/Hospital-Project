using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using System;

namespace Catalyte.Apparel.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>(type: "text", nullable: true),
                    Description = table.Column<string>(type: "text", nullable: true),
                    Demographic = table.Column<string>(type: "text", nullable: true),
                    Category = table.Column<string>(type: "text", nullable: true),
                    Type = table.Column<string>(type: "text", nullable: true),
                    ReleaseDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    PrimaryColorCode = table.Column<string>(type: "text", nullable: true),
                    SecondaryColorCode = table.Column<string>(type: "text", nullable: true),
                    StyleNumber = table.Column<string>(type: "text", nullable: true),
                    GlobalProductCode = table.Column<string>(type: "text", nullable: true),
                    Active = table.Column<bool>(type: "boolean", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Purchases",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    OrderDate = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    BillingStreet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingStreet2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingCity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    BillingState = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    BillingZip = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: true),
                    BillingEmail = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    BillingPhone = table.Column<string>(type: "character varying(15)", maxLength: 15, nullable: true),
                    DeliveryFirstName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeliveryLastName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeliveryStreet = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeliveryStreet2 = table.Column<string>(type: "character varying(100)", maxLength: 100, nullable: true),
                    DeliveryCity = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: true),
                    DeliveryState = table.Column<string>(type: "character varying(2)", maxLength: 2, nullable: true),
                    DeliveryZip = table.Column<int>(type: "integer", maxLength: 10, nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Purchases", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LineItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PurchaseID = table.Column<int>(type: "integer", nullable: false),
                    ProductID = table.Column<int>(type: "integer", nullable: false),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    DateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    DateModified = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LineItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LineItems_Products_ProductID",
                        column: x => x.ProductID,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LineItems_Purchases_PurchaseID",
                        column: x => x.PurchaseID,
                        principalTable: "Purchases",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Id", "Active", "Category", "DateCreated", "DateModified", "Demographic", "Description", "GlobalProductCode", "Name", "PrimaryColorCode", "ReleaseDate", "SecondaryColorCode", "StyleNumber", "Type" },
                values: new object[,]
                {
                    { 1, false, "Hockey", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(1676), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(2312), "Women", null, "po-ZQAHBOE", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 700, DateTimeKind.Local).AddTicks(8469), null, "scISBXS", "Pant" },
                    { 2, false, "Skateboarding", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3157), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3159), "Men", null, "po-LOVWKBW", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3110), null, "scWZLQD", "Pant" },
                    { 3, false, "Baseball", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3178), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3179), "Women", null, "po-WXRJZPA", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3171), null, "scCPCJF", "Pant" },
                    { 4, false, "Football", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3194), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3196), "Men", null, "po-LRPIFHZ", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3190), null, "scRGMRH", "Pant" },
                    { 5, false, "Boxing", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3209), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3211), "Men", null, "po-RPRXWNL", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3204), null, "scVKOTH", "Pant" },
                    { 6, false, "Soccer", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3232), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3234), "Men", null, "po-YSNFPKK", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3227), null, "scHWIYL", "Pant" },
                    { 7, false, "Baseball", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3248), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3250), "Men", null, "po-QERRRXL", null, null, new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3243), null, "scALLJY", "Pant" }
                });

            migrationBuilder.InsertData(
                table: "Purchases",
                columns: new[] { "Id", "BillingCity", "BillingEmail", "BillingPhone", "BillingState", "BillingStreet", "BillingStreet2", "BillingZip", "DateCreated", "DateModified", "DeliveryCity", "DeliveryFirstName", "DeliveryLastName", "DeliveryState", "DeliveryStreet", "DeliveryStreet2", "DeliveryZip", "OrderDate" },
                values: new object[] { 1, "Atlanta", "customer@home.com", "(714) 345-8765", "GA", "123 Main", "Apt A", "31675", new DateTime(2021, 10, 4, 15, 39, 24, 706, DateTimeKind.Utc).AddTicks(8369), new DateTime(2021, 10, 4, 15, 39, 24, 706, DateTimeKind.Utc).AddTicks(8383), "Birmingham", "Max", "Space", "AL", "123 Hickley", null, 43690, new DateTime(2021, 5, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "LineItems",
                columns: new[] { "Id", "DateCreated", "DateModified", "ProductID", "PurchaseID", "Quantity" },
                values: new object[] { 1, new DateTime(2021, 10, 4, 15, 39, 24, 705, DateTimeKind.Utc).AddTicks(9727), new DateTime(2021, 10, 4, 15, 39, 24, 705, DateTimeKind.Utc).AddTicks(9734), 1, 1, 1 });

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_ProductID",
                table: "LineItems",
                column: "ProductID");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_PurchaseID",
                table: "LineItems",
                column: "PurchaseID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LineItems");

            migrationBuilder.DropTable(
                name: "Products");

            migrationBuilder.DropTable(
                name: "Purchases");
        }
    }
}
