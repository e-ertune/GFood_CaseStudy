using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GFood_CaseStudy.DataAccess.Migrations
{
    public partial class Add_Prices : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Total",
                table: "Baskets",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Price",
                table: "BasketProducts",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.CreateTable(
                name: "CouponCodes",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    Code = table.Column<string>(type: "text", nullable: false),
                    Quota = table.Column<int>(type: "integer", nullable: false),
                    Discount = table.Column<decimal>(type: "numeric", nullable: false),
                    IsPercentage = table.Column<bool>(type: "boolean", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false),
                    StartDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    UpdatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CouponCodes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductPrices",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uuid", nullable: false),
                    ProductId = table.Column<Guid>(type: "uuid", nullable: false),
                    Price = table.Column<decimal>(type: "numeric", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    IsDeleted = table.Column<bool>(type: "boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductPrices", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductPrices_Products_ProductId",
                        column: x => x.ProductId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BasketCouponCodes",
                columns: table => new
                {
                    BasketId = table.Column<Guid>(type: "uuid", nullable: false),
                    CouponCodeId = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BasketCouponCodes", x => new { x.BasketId, x.CouponCodeId });
                    table.ForeignKey(
                        name: "FK_BasketCouponCodes_Baskets_BasketId",
                        column: x => x.BasketId,
                        principalTable: "Baskets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BasketCouponCodes_CouponCodes_CouponCodeId",
                        column: x => x.CouponCodeId,
                        principalTable: "CouponCodes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BasketCouponCodes_CouponCodeId",
                table: "BasketCouponCodes",
                column: "CouponCodeId");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCodes_CreatedAt",
                table: "CouponCodes",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_CouponCodes_UpdatedAt",
                table: "CouponCodes",
                column: "UpdatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_CreatedAt",
                table: "ProductPrices",
                column: "CreatedAt");

            migrationBuilder.CreateIndex(
                name: "IX_ProductPrices_ProductId",
                table: "ProductPrices",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BasketCouponCodes");

            migrationBuilder.DropTable(
                name: "ProductPrices");

            migrationBuilder.DropTable(
                name: "CouponCodes");

            migrationBuilder.DropColumn(
                name: "Total",
                table: "Baskets");

            migrationBuilder.DropColumn(
                name: "Price",
                table: "BasketProducts");
        }
    }
}
