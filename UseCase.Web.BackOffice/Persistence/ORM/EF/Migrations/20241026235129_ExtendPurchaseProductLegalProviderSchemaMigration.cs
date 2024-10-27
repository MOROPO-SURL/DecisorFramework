using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendPurchaseProductLegalProviderSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "costcenterid",
                table: "purchaseproductlegalproviderbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_purchaseproductlegalproviderbridges_costcenterid",
                table: "purchaseproductlegalproviderbridges",
                column: "costcenterid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_costcenters_costcenterid",
                table: "purchaseproductlegalproviderbridges",
                column: "costcenterid",
                principalTable: "costcenters",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseproductlegalproviderbridges_costcenters_costcenterid",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.DropIndex(
                name: "ix_purchaseproductlegalproviderbridges_costcenterid",
                table: "purchaseproductlegalproviderbridges");

            migrationBuilder.DropColumn(
                name: "costcenterid",
                table: "purchaseproductlegalproviderbridges");
        }
    }
}
