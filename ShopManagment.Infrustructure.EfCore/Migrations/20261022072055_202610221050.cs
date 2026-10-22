using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagment.Infrustructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class _202610221050 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ProductStandardId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.AddColumn<long>(
                name: "ProductUnitId",
                table: "Products",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductStandardId",
                table: "Products",
                column: "ProductStandardId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ProductUnitId",
                table: "Products",
                column: "ProductUnitId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductStandards_ProductStandardId",
                table: "Products",
                column: "ProductStandardId",
                principalTable: "ProductStandards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ProductUnits_ProductUnitId",
                table: "Products",
                column: "ProductUnitId",
                principalTable: "ProductUnits",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductStandards_ProductStandardId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ProductUnits_ProductUnitId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductStandardId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ProductUnitId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductStandardId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductUnitId",
                table: "Products");
        }
    }
}
