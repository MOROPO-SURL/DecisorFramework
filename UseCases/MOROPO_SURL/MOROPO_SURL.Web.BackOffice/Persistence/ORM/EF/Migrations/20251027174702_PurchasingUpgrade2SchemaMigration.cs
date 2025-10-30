using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_purchaserequests_requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropTable(
                name: "purchaseorderproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropColumn(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaserequests");

            migrationBuilder.AlterColumn<Guid>(
                name: "requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<decimal>(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                type: "numeric",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "estimatedadvanceunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "purchaseorderproductresultbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderproductresultbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseorderproductresultbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderproductresultbridges_purchaseorders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderproductresultbridges_unitmeasurements_unitmeas~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderproductspentbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderproductspentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseorderproductspentbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderproductspentbridges_purchaseorders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderproductspentbridges_unitmeasurements_unitmeasu~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_estimatedadvanceunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "estimatedadvanceunitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderproductresultbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderproductresultbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderproductresultbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderproductresultbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderproductspentbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderproductspentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderproductspentbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderproductspentbridges",
                column: "unitmeasurementid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_purchaserequests_requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "requestid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaserequests",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_unitmeasurements_estimatedadvanceunitmeasure~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "estimatedadvanceunitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_purchaserequests_requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseorders_unitmeasurements_estimatedadvanceunitmeasure~",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropTable(
                name: "purchaseorderproductresultbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseorderproductspentbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropIndex(
                name: "ix_purchaseorders_estimatedadvanceunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropColumn(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.DropColumn(
                name: "estimatedadvanceunitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders");

            migrationBuilder.AddColumn<decimal>(
                name: "estimatedadvance",
                schema: "decisorframework_purchasing",
                table: "purchaserequests",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<Guid>(
                name: "requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "purchaseorderproductbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseorderproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderproductbridges_purchaseorders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderproductbridges_unitmeasurements_unitmeasuremen~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseorders_purchaserequests_requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "requestid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaserequests",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
