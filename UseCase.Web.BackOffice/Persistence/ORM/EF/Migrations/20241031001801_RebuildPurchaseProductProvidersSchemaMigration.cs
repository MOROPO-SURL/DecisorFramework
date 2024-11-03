using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class RebuildPurchaseProductProvidersSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_products_sternid",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_purchases_prowid",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_products_sternid",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_purchases_prowid",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchaseproductnaturalproviderbridges",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchaseproductlegalproviderbridges",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.RenameColumn(
                name: "sternid",
                table: "purchaseproductnaturalproviderbridges",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                table: "purchaseproductnaturalproviderbridges",
                newName: "purchaseid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseproductnaturalproviderbridges_sternid",
                table: "purchaseproductnaturalproviderbridges",
                newName: "ix_purchaseproductnaturalproviderbridges_productid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                table: "purchaseproductlegalproviderbridges",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                table: "purchaseproductlegalproviderbridges",
                newName: "purchaseid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseproductlegalproviderbridges_sternid",
                table: "purchaseproductlegalproviderbridges",
                newName: "ix_purchaseproductlegalproviderbridges_productid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchaseproductnaturalproviderbridges",
                table: "purchaseproductnaturalproviderbridges",
                columns: new[] { "purchaseid", "providerid", "productid", "costcenterid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchaseproductlegalproviderbridges",
                table: "purchaseproductlegalproviderbridges",
                columns: new[] { "purchaseid", "providerid", "productid", "costcenterid" });

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_products_productid",
                table: "purchaseproductlegalproviderbridges",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_purchases_purchaseid",
                table: "purchaseproductlegalproviderbridges",
                column: "purchaseid",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_products_productid",
                table: "purchaseproductnaturalproviderbridges",
                column: "productid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_purchases_purchaseid",
                table: "purchaseproductnaturalproviderbridges",
                column: "purchaseid",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_products_productid",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_purchases_purchaseid",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_products_productid",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_purchases_purchaseid",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchaseproductnaturalproviderbridges",
                table: "purchaseproductnaturalproviderbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_purchaseproductlegalproviderbridges",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "purchaseproductnaturalproviderbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "purchaseid",
                table: "purchaseproductnaturalproviderbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseproductnaturalproviderbridges_productid",
                table: "purchaseproductnaturalproviderbridges",
                newName: "ix_purchaseproductnaturalproviderbridges_sternid");

            migrationBuilder.RenameColumn(
                name: "productid",
                table: "purchaseproductlegalproviderbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "purchaseid",
                table: "purchaseproductlegalproviderbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_purchaseproductlegalproviderbridges_productid",
                table: "purchaseproductlegalproviderbridges",
                newName: "ix_purchaseproductlegalproviderbridges_sternid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchaseproductnaturalproviderbridges",
                table: "purchaseproductnaturalproviderbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_purchaseproductlegalproviderbridges",
                table: "purchaseproductlegalproviderbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_products_sternid",
                table: "purchaseproductlegalproviderbridges",
                column: "sternid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_purchases_prowid",
                table: "purchaseproductlegalproviderbridges",
                column: "prowid",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_products_sternid",
                table: "purchaseproductnaturalproviderbridges",
                column: "sternid",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductnaturalproviderbridges_purchases_prowid",
                table: "purchaseproductnaturalproviderbridges",
                column: "prowid",
                principalTable: "purchases",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
