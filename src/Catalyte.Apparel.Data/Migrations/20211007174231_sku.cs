using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Catalyte.Apparel.Data.Migrations
{
    public partial class sku : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Sku",
                table: "Products",
                type: "text",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "LineItems",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 10, 7, 17, 42, 31, 7, DateTimeKind.Utc).AddTicks(1098), new DateTime(2021, 10, 7, 17, 42, 31, 7, DateTimeKind.Utc).AddTicks(1102) });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { "Baseball", new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(1722), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2044), "po-AEOHPRU", new DateTime(2021, 10, 7, 13, 42, 31, 4, DateTimeKind.Local).AddTicks(3406), "SHL-100-Blue", "scEDMDI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2399), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2400), "Women", "po-BYLCRRR", new DateTime(2021, 10, 7, 13, 42, 31, 6, DateTimeKind.Local).AddTicks(2378), "SHL-100-Red", "scNFSFW" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { "Soccer", new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2410), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2411), "Women", "po-XNQIMLJ", new DateTime(2021, 10, 7, 13, 42, 31, 6, DateTimeKind.Local).AddTicks(2407), "HOV-AB-KJ", "scGQBDI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { "Football", new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2418), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2419), "Women", "po-TRPDZRH", new DateTime(2021, 10, 7, 13, 42, 31, 6, DateTimeKind.Local).AddTicks(2416), "TLX-DRESS-SM", "scZCTDA" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { "Baseball", new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2462), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2463), "po-ZVCSNDG", new DateTime(2021, 10, 7, 13, 42, 31, 6, DateTimeKind.Local).AddTicks(2460), "ATK-34-RD", "scPVUVY" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { "Running", new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2472), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2473), "po-HKZIFAT", new DateTime(2021, 10, 7, 13, 42, 31, 6, DateTimeKind.Local).AddTicks(2470), "TRE-33-LRG", "scNDBXM" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "Sku", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2479), new DateTime(2021, 10, 7, 17, 42, 31, 6, DateTimeKind.Utc).AddTicks(2480), "Women", "po-KXELTWH", new DateTime(2021, 10, 7, 13, 42, 31, 6, DateTimeKind.Local).AddTicks(2477), "TRE-30-SM", "scUZKVI" });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 10, 7, 17, 42, 31, 7, DateTimeKind.Utc).AddTicks(4798), new DateTime(2021, 10, 7, 17, 42, 31, 7, DateTimeKind.Utc).AddTicks(4801) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sku",
                table: "Products");

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
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Soccer", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(2829), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3161), "po-JNLUACY", new DateTime(2021, 10, 5, 10, 55, 20, 557, DateTimeKind.Local).AddTicks(4705), "scUSNNI" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3488), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3489), "Men", "po-COYMTJX", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3466), "scOZVQT" });

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
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3506), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3506), "Men", "po-XYEXVUE", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3504), "scLRNIV" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Football", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3513), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3514), "po-NPEGVOZ", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3511), "scRQBIY" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "Category", "DateCreated", "DateModified", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Hockey", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3523), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3524), "po-QXQGZPQ", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3521), "scARSXN" });

            migrationBuilder.UpdateData(
                table: "Products",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "Category", "DateCreated", "DateModified", "Demographic", "GlobalProductCode", "ReleaseDate", "StyleNumber" },
                values: new object[] { "Basketball", new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3530), new DateTime(2021, 10, 5, 14, 55, 20, 559, DateTimeKind.Utc).AddTicks(3530), "Men", "po-JJEFAVR", new DateTime(2021, 10, 5, 10, 55, 20, 559, DateTimeKind.Local).AddTicks(3528), "scHXQSV" });

            migrationBuilder.UpdateData(
                table: "Purchases",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "DateCreated", "DateModified" },
                values: new object[] { new DateTime(2021, 10, 5, 14, 55, 20, 560, DateTimeKind.Utc).AddTicks(6863), new DateTime(2021, 10, 5, 14, 55, 20, 560, DateTimeKind.Utc).AddTicks(6873) });
        }
    }
}
