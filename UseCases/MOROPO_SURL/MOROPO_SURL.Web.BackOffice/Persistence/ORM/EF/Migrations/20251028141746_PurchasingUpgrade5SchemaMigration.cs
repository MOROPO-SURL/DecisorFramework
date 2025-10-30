using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_abstractsale_abstractbudget_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "abstractsale");

            migrationBuilder.DropForeignKey(
                name: "fk_purchases_purchaseorders_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.DropForeignKey(
                name: "fk_purchases_purchasezones_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.DropTable(
                name: "budgetproductbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "budgetservicebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "abstractbudget",
                schema: "decisorframework_commercial");

            migrationBuilder.DropIndex(
                name: "ix_purchases_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.DropIndex(
                name: "ix_abstractsale_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "abstractsale");

            migrationBuilder.DropColumn(
                name: "zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.AlterColumn<Guid>(
                name: "orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "legalclientbudget",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbudget", x => new { x.number, x.year, x.clientid });
                    table.ForeignKey(
                        name: "fk_legalclientbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudget_legalclients_clientid",
                        column: x => x.clientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgets",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbudgets", x => new { x.number, x.year, x.providerid });
                    table.ForeignKey(
                        name: "fk_legalproviderbudgets_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgets_legalproviders_providerid",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientbudget",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbudget", x => new { x.number, x.year, x.clientid });
                    table.ForeignKey(
                        name: "fk_naturalclientbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudget_naturalclients_clientid",
                        column: x => x.clientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgets",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgets", x => new { x.number, x.year, x.providerid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgets_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgets_naturalproviders_providerid",
                        column: x => x.providerid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientbudgetproductbridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbudgetproductbridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_classifications_classificati~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_legalclientbudget_budgetnumb~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "legalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetproductbridge_unitmeasurements_unitmeasure~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalclientbudgetservicebridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbudgetservicebridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_legalclientbudgetservicebridge_legalclientbudget_budgetnumb~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "legalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbudgetservicebridge_provisionableservices_servic~",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "provisionableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbudgetproductbridge", x => new { x.budgetnumber, x.budgetyear, x.providerid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_classifications_classifica~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_legalproviderbudgets_budge~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.providerid },
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumns: new[] { "number", "year", "providerid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_unitmeasurements_unitmeasu~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbudgetservicebridge", x => new { x.budgetnumber, x.budgetyear, x.providerid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_budge~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.providerid },
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumns: new[] { "number", "year", "providerid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetservicebridge_requestableservices_servic~",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientbudgetproductbridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbudgetproductbridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_classifications_classifica~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_naturalclientbudget_budget~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "naturalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetproductbridge_unitmeasurements_unitmeasu~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientbudgetservicebridge",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    clientid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbudgetservicebridge", x => new { x.budgetnumber, x.budgetyear, x.clientid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetservicebridge_naturalclientbudget_budget~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.clientid },
                        principalSchema: "decisorframework_sales",
                        principalTable: "naturalclientbudget",
                        principalColumns: new[] { "number", "year", "clientid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbudgetservicebridge_provisionableservices_serv~",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "provisionableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgetproductbridges", x => new { x.budgetnumber, x.budgetyear, x.providerid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_classifications_classif~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_naturalproviderbudgets_~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.providerid },
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumns: new[] { "number", "year", "providerid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_unitmeasurements_unitme~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    providerid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgetservicebridges", x => new { x.budgetnumber, x.budgetyear, x.providerid, x.serviceid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetservicebridges_naturalproviderbudgets_~",
                        columns: x => new { x.budgetnumber, x.budgetyear, x.providerid },
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumns: new[] { "number", "year", "providerid" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetservicebridges_requestableservices_ser~",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudget_clientid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudget_commercialid",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetproductbridge_classificationid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetproductbridge",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetproductbridge_productid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetproductbridge",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetproductbridge_unitmeasurementid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetproductbridge",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientbudgetservicebridge_serviceid",
                schema: "decisorframework_sales",
                table: "legalclientbudgetservicebridge",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproductbridge_classificationid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproductbridge_productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproductbridge_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_commercialid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetservicebridge_serviceid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudget_clientid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "clientid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudget_commercialid",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetproductbridge_classificationid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetproductbridge",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetproductbridge_productid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetproductbridge",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetproductbridge_unitmeasurementid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetproductbridge",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbudgetservicebridge_serviceid",
                schema: "decisorframework_sales",
                table: "naturalclientbudgetservicebridge",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproductbridges_classificationid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproductbridges_productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproductbridges_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_commercialid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "providerid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetservicebridges_serviceid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "serviceid");

            migrationBuilder.AddForeignKey(
                name: "fk_purchases_purchaseorders_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "orderid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_purchases_purchaseorders_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases");

            migrationBuilder.DropTable(
                name: "legalclientbudgetproductbridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "legalclientbudgetservicebridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "naturalclientbudgetproductbridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "naturalclientbudgetservicebridge",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "legalclientbudget",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "legalproviderbudgets",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "naturalclientbudget",
                schema: "decisorframework_sales");

            migrationBuilder.DropTable(
                name: "naturalproviderbudgets",
                schema: "decisorframework_purchasing");

            migrationBuilder.AlterColumn<Guid>(
                name: "orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "abstractbudget",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    number = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    commercialid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    confirmedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    sharedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abstractbudget", x => new { x.number, x.year });
                    table.ForeignKey(
                        name: "fk_abstractbudget_employees_commercialid",
                        column: x => x.commercialid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractbudget_organizationcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationcontacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_abstractbudget_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "budgetproductbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: true),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budgetproductbridges", x => new { x.budgetnumber, x.budgetyear, x.productid });
                    table.ForeignKey(
                        name: "fk_budgetproductbridges_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_budgetproductbridges_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_budgetproductbridges_unitmeasurements_unitmeasurementid",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "budgetservicebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    budgetnumber = table.Column<int>(type: "integer", nullable: false),
                    budgetyear = table.Column<int>(type: "integer", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_budgetservicebridges", x => new { x.budgetnumber, x.budgetyear, x.serviceid });
                    table.ForeignKey(
                        name: "fk_budgetservicebridges_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_budgetservicebridges_provisionableservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "provisionableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchases_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "zoneid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "abstractsale",
                columns: new[] { "budgetnumber", "budgetyear" });

            migrationBuilder.CreateIndex(
                name: "ix_abstractbudget_commercialid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "commercialid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractbudget_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_budgetproductbridges_productid",
                schema: "decisorframework_commercial",
                table: "budgetproductbridges",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_budgetproductbridges_unitmeasurementid",
                schema: "decisorframework_commercial",
                table: "budgetproductbridges",
                column: "unitmeasurementid");

            migrationBuilder.CreateIndex(
                name: "ix_budgetservicebridges_serviceid",
                schema: "decisorframework_commercial",
                table: "budgetservicebridges",
                column: "serviceid");

            migrationBuilder.AddForeignKey(
                name: "fk_abstractsale_abstractbudget_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "abstractsale",
                columns: new[] { "budgetnumber", "budgetyear" },
                principalSchema: "decisorframework_commercial",
                principalTable: "abstractbudget",
                principalColumns: new[] { "number", "year" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_purchases_purchaseorders_orderid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "orderid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchaseorders",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_purchases_purchasezones_zoneid",
                schema: "decisorframework_purchasing",
                table: "purchases",
                column: "zoneid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "purchasezones",
                principalColumn: "id");
        }
    }
}
