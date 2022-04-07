using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Catalyte.Apparel.Data.Migrations
{
    public partial class creditcard : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CVV",
                table: "Purchases",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "CardHolder",
                table: "Purchases",
                type: "character varying(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CardNumber",
                table: "Purchases",
                type: "character varying(16)",
                maxLength: 16,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expiration",
                table: "Purchases",
                type: "character varying(5)",
                maxLength: 5,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LineItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 55, 20, 560, DateTimeKind.Utc).AddTicks(1585), new DateTime(2021, 10, 5, 14, 55, 20, 560, DateTimeKind.Utc).AddTicks(1588) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Soccer", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(2829), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3161), "Men", "po-JNLUACY", new DateTime(2021, 10, 5, 10, 55, 20, 557, DateTimeKind.Local).AddTicks(4705), "scUSNNI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3488), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3489), "po-COYMTJX", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3466), "scOZVQT" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Basketball", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3498), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3499), "Men", "po-UBXMALQ", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3495), "scEXBWN" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3506), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3506), "po-XYEXVUE", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3504), "scLRNIV" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Football", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3513), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3514), "Women", "po-NPEGVOZ", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3511), "scRQBIY" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3523), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3524), "Women", "po-QXQGZPQ", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3521), "scARSXN" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Basketball", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3530), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3530), "po-JJEFAVR", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3528), "scHXQSV" });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "CVV", "CardHolder", "CardNumber", "DateCreated", "DateModified", "Expiration" },
                values: new object[] { 456, "Max Perkins", "1435678998761234", new DateTime(2021, 10, 5, 14, 55, 20, 560, DateTimeKind.Utc).AddTicks(6863), new DateTime(2021, 10, 5, 14, 55, 20, 560, DateTimeKind.Utc).AddTicks(6873), "11/21" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CVV",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CardHolder",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "CardNumber",
                table: "Purchases");

            migrationBuilder.DropColumn(
                name: "Expiration",
                table: "Purchases");

            migrationBuilder.UpdateData(
                table: "LineItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 10, 4, 15, 39, 24, 705, DateTimeKind.Utc).AddTicks(9727), new DateTime(2021, 10, 4, 15, 39, 24, 705, DateTimeKind.Utc).AddTicks(9734) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(1676), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(2312), "Women", "po-ZQAHBOE", new DateTime(2021, 10, 4, 11, 39, 24, 700, DateTimeKind.Local).AddTicks(8469), "scISBXS" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Skateboarding", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3157), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3159), "po-LOVWKBW", new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3110), "scWZLQD" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Baseball", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3178), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3179), "Women", "po-WXRJZPA", new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3171), "scCPCJF" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Football", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3194), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3196), "po-LRPIFHZ", new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3190), "scRGMRH" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Boxing", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3209), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3211), "Men", "po-RPRXWNL", new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3204), "scVKOTH" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Soccer", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3232), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3234), "Men", "po-YSNFPKK", new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3227), "scHWIYL" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Baseball", new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3248), new DateTime(2021, 10, 4, 15, 39, 24, 704, DateTimeKind.Utc).AddTicks(3250), "po-QERRRXL", new DateTime(2021, 10, 4, 11, 39, 24, 704, DateTimeKind.Local).AddTicks(3243), "scALLJY" });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 10, 4, 15, 39, 24, 706, DateTimeKind.Utc).AddTicks(8369), new DateTime(2021, 10, 4, 15, 39, 24, 706, DateTimeKind.Utc).AddTicks(8383) });
        }
    }
}
