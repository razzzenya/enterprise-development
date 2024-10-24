using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnterpriseWarehouse.Domain.Migrations
{
    /// <inheritdoc />
    public partial class FixProductMappingWithAutoInclude : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_product_ProductId",
                table: "Cell");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_organization_OrganizationId",
                table: "supply");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_product_ProductId",
                table: "supply");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "supply",
                newName: "product");

            migrationBuilder.RenameColumn(
                name: "OrganizationId",
                table: "supply",
                newName: "organization");

            migrationBuilder.RenameIndex(
                name: "IX_supply_ProductId",
                table: "supply",
                newName: "IX_supply_product");

            migrationBuilder.RenameIndex(
                name: "IX_supply_OrganizationId",
                table: "supply",
                newName: "IX_supply_organization");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Cell",
                newName: "product");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_ProductId",
                table: "Cell",
                newName: "IX_Cell_product");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_product_product",
                table: "Cell",
                column: "product",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supply_organization_organization",
                table: "supply",
                column: "organization",
                principalTable: "organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supply_product_product",
                table: "supply",
                column: "product",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cell_product_product",
                table: "Cell");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_organization_organization",
                table: "supply");

            migrationBuilder.DropForeignKey(
                name: "FK_supply_product_product",
                table: "supply");

            migrationBuilder.RenameColumn(
                name: "product",
                table: "supply",
                newName: "ProductId");

            migrationBuilder.RenameColumn(
                name: "organization",
                table: "supply",
                newName: "OrganizationId");

            migrationBuilder.RenameIndex(
                name: "IX_supply_product",
                table: "supply",
                newName: "IX_supply_ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_supply_organization",
                table: "supply",
                newName: "IX_supply_OrganizationId");

            migrationBuilder.RenameColumn(
                name: "product",
                table: "Cell",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Cell_product",
                table: "Cell",
                newName: "IX_Cell_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cell_product_ProductId",
                table: "Cell",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supply_organization_OrganizationId",
                table: "supply",
                column: "OrganizationId",
                principalTable: "organization",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_supply_product_ProductId",
                table: "supply",
                column: "ProductId",
                principalTable: "product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
