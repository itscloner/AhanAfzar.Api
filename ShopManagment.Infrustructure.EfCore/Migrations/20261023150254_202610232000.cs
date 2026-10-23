using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopManagment.Infrustructure.EfCore.Migrations
{
    /// <inheritdoc />
    public partial class _202610232000 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductBrands",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_ProductBrands_ProductId_BrandId",
                table: "ProductBrands",
                columns: new[] { "ProductId", "BrandId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands");

            migrationBuilder.DropIndex(
                name: "IX_ProductBrands_ProductId_BrandId",
                table: "ProductBrands");

            migrationBuilder.AlterColumn<long>(
                name: "Id",
                table: "ProductBrands",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ProductBrands",
                table: "ProductBrands",
                columns: new[] { "ProductId", "BrandId" });
        }
    }
}
