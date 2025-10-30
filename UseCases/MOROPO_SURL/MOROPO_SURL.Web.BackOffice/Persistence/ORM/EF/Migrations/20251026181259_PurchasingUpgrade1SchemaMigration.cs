using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_departures_purchaseplans_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "departures");

            migrationBuilder.DropForeignKey(
                name: "fk_purchasecashadvances_purchaseplans_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseplanlegalproviderbridges_purchaseplans_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanlegalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseplannaturalproviderbridges_purchaseplans_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplannaturalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchases_purchaseplans_planid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.DropTable(
                name: "purchaseplaninputproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplanoutputproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplans",
                schema: "decisorframework_purchasing");

            migrationBuilder.RenameColumn(
                name: "planid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                newName: "orderid");

            migrationBuilder.RenameIndex(
                name: "ix_purchases_planid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                newName: "ix_purchases_orderid");

            migrationBuilder.RenameColumn(
                name: "purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                newName: "purchaseorderid");

            migrationBuilder.RenameIndex(
                name: "ix_purchasecashadvances_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                newName: "ix_purchasecashadvances_purchaseorderid");

            migrationBuilder.RenameColumn(
                name: "purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "departures",
                newName: "purchaseorderid");

            migrationBuilder.RenameIndex(
                name: "ix_departures_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "departures",
                newName: "ix_departures_purchaseorderid");

            migrationBuilder.CreateTable(
                name: "purchaserequests",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    argument = table.Column<string>(type: "text", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    estimatedadvance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaserequests", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaserequests_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseorders",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    plannedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    requestid = table.Column<Guid>(type: "uuid", nullable: false),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    zoneid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseorders_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorders_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorders_purchaserequests_requestid",
                        column: x => x.requestid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaserequests",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorders_purchasezones_zoneid",
                        column: x => x.zoneid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaserequestproductbridges",
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

            migrationBuilder.CreateTable(
                name: "purchaseorderproductbridges",
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

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_agreementid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_requestid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "requestid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_responsibleid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorders_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchaseorders",
                column: "zoneid");

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

            migrationBuilder.CreateIndex(
                name: "ix_purchaserequests_authorid",
                schema: "decisorframework_purchasing",
                table: "purchaserequests",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "fk_departures_purchaseorders_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "departures",
                column: "purchaseorderid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchasecashadvances_purchaseorders_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                column: "purchaseorderid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseplanlegalproviderbridges_purchaseorders_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanlegalproviderbridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseplannaturalproviderbridges_purchaseorders_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplannaturalproviderbridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchases_purchaseorders_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "orderid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_departures_purchaseorders_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "departures");

            migrationBuilder.DropForeignKey(
                name: "fk_purchasecashadvances_purchaseorders_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseplanlegalproviderbridges_purchaseorders_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanlegalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchaseplannaturalproviderbridges_purchaseorders_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplannaturalproviderbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_purchases_purchaseorders_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.DropTable(
                name: "purchaseorderproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaserequestproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseorders",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaserequests",
                schema: "decisorframework_purchasing");

            migrationBuilder.RenameColumn(
                name: "orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                newName: "planid");

            migrationBuilder.RenameIndex(
                name: "ix_purchases_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                newName: "ix_purchases_planid");

            migrationBuilder.RenameColumn(
                name: "purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                newName: "purchaseplanid");

            migrationBuilder.RenameIndex(
                name: "ix_purchasecashadvances_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                newName: "ix_purchasecashadvances_purchaseplanid");

            migrationBuilder.RenameColumn(
                name: "purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "departures",
                newName: "purchaseplanid");

            migrationBuilder.RenameIndex(
                name: "ix_departures_purchaseorderid",
                schema: "decisorframework_purchasing",
                table: "departures",
                newName: "ix_departures_purchaseplanid");

            migrationBuilder.CreateTable(
                name: "purchaseplans",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    decisorid = table.Column<Guid>(type: "uuid", nullable: false),
                    plannerid = table.Column<Guid>(type: "uuid", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false),
                    zoneid = table.Column<Guid>(type: "uuid", nullable: false),
                    approvedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    estimatedadvance = table.Column<decimal>(type: "numeric", nullable: false),
                    plannedfor = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplans", x => x.id);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_decisorid",
                        column: x => x.decisorid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_plannerid",
                        column: x => x.plannerid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplans_purchasezones_zoneid",
                        column: x => x.zoneid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchasezones",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplaninputproductbridges",
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
                    table.PrimaryKey("pk_purchaseplaninputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplaninputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplaninputproductbridges_purchaseplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplaninputproductbridges_unitmeasurements_unitmeasur~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplanoutputproductbridges",
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
                    table.PrimaryKey("pk_purchaseplanoutputproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplanoutputproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplanoutputproductbridges_purchaseplans_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseplans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplanoutputproductbridges_unitmeasurements_unitmeasu~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplaninputproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplaninputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplaninputproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseplaninputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplanoutputproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanoutputproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplanoutputproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanoutputproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_decisorid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "decisorid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_plannerid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "plannerid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_responsibleid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplans_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchaseplans",
                column: "zoneid");

            migrationBuilder.AddForeignKey(
                name: "fk_departures_purchaseplans_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "departures",
                column: "purchaseplanid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseplans",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchasecashadvances_purchaseplans_purchaseplanid",
                schema: "decisorframework_purchasing",
                table: "purchasecashadvances",
                column: "purchaseplanid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseplans",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseplanlegalproviderbridges_purchaseplans_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanlegalproviderbridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseplans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchaseplannaturalproviderbridges_purchaseplans_prowid",
                schema: "decisorframework_purchasing",
                table: "purchaseplannaturalproviderbridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseplans",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchases_purchaseplans_planid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "planid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseplans",
                principalColumn: "id");
        }
    }
}
