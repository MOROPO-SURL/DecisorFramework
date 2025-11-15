using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseorderproductresultbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseorderproductspentbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "purchaseorderexpectedproductresults",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderexpectedproductresults", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_classifications_classif~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_purchaseorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderexpectedproductresults_unitmeasurements_unitme~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorderplannedproductspents",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    orderid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderplannedproductspents", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_classifications_classific~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_purchaseorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderplannedproductspents_unitmeasurements_unitmeas~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_classificationid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_orderid_productid_class~",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                columns: new[] { "orderid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_productid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderexpectedproductresults_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderexpectedproductresults",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_classificationid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_orderid_productid_classif~",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                columns: new[] { "orderid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_productid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderplannedproductspents_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderplannedproductspents",
                column: "unitmeasurementid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseorderexpectedproductresults",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseorderplannedproductspents",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "purchaseorderproductresultbridges",
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
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
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
        }
    }
}
