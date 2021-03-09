using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CurrencyApi.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SymbolTypes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SymbolTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Symbols",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymbolName = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: true),
                    Name = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: true),
                    SymbolTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Symbols", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Symbols_SymbolTypes_SymbolTypeId",
                        column: x => x.SymbolTypeId,
                        principalTable: "SymbolTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyPrices",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SymbolId = table.Column<int>(type: "int", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Timestamp = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyPrices_Symbols_SymbolId",
                        column: x => x.SymbolId,
                        principalTable: "Symbols",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CurrencyDeltas",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false),
                    Delta1H = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Delta24H = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Delta7D = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Delta30D = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    Low24H = table.Column<decimal>(type: "decimal(18,6)", nullable: false),
                    Hight24H = table.Column<decimal>(type: "decimal(18,6)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CurrencyDeltas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CurrencyDeltas_CurrencyPrices_Id",
                        column: x => x.Id,
                        principalTable: "CurrencyPrices",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CurrencyPrices_SymbolId",
                table: "CurrencyPrices",
                column: "SymbolId");

            migrationBuilder.CreateIndex(
                name: "IX_Symbols_SymbolTypeId",
                table: "Symbols",
                column: "SymbolTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CurrencyDeltas");

            migrationBuilder.DropTable(
                name: "CurrencyPrices");

            migrationBuilder.DropTable(
                name: "Symbols");

            migrationBuilder.DropTable(
                name: "SymbolTypes");
        }
    }
}
