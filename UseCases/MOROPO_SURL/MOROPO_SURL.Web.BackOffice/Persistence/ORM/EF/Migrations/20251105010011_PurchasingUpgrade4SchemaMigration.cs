using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaserequestproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "purchaserequestexpectedproductadquisitions",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaserequestexpectedproductadquisitions", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_classifications_~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_products_product~",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_purchaserequests~",
                        column: x => x.requestid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaserequests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequestexpectedproductadquisitions_unitmeasurements~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_classificationid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_productid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_requestid_produc~",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                columns: new[] { "requestid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestexpectedproductadquisitions_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestexpectedproductadquisitions",
                column: "unitmeasurementid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaserequestexpectedproductadquisitions",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "purchaserequestproductbridges",
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
                    table.PrimaryKey("pk_purchaserequestproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaserequestproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequestproductbridges_purchaserequests_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaserequests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaserequestproductbridges_unitmeasurements_unitmeasurem~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequestproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaserequestproductbridges",
                column: "unitmeasurementid");
        }
    }
}
