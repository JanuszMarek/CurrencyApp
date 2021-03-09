using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyApi.Migrations
{
    public partial class Seed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "SymbolTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Currency" });

            migrationBuilder.InsertData(
                table: "SymbolTypes",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Cryptocurrency" });

            migrationBuilder.InsertData(
                table: "Symbols",
                columns: new[] { "Id", "Code", "Name", "SymbolTypeId" },
                values: new object[,]
                {
                    { 1, "USD", "United States Dollar", 1 },
                    { 2, "EUR", "Euro", 1 },
                    { 3, "GBP", "British Pound", 1 },
                    { 4, "BTC", "Bitcoin", 2 },
                    { 5, "ETH", "Etherum", 2 },
                    { 6, "USDT", "Tether", 2 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Symbols",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "SymbolTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SymbolTypes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
