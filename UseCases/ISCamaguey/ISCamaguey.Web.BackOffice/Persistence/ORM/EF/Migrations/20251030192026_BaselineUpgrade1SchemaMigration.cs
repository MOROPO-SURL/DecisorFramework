using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class BaselineUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "budgetproductbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "budgetservicebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "abstractbudget",
                schema: "decisorframework_commercial");

            migrationBuilder.RenameTable(
                name: "unitmeasurements",
                schema: "decisorframework_inventory",
                newName: "unitmeasurements",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_inventory",
                newName: "unitmeasurementconversionbridges",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "centralstatestructures",
                schema: "decisorframework_legal",
                newName: "centralstatestructures",
                newSchema: "decisorframework_domain");

            migrationBuilder.CreateTable(
                name: "colaborators",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_colaborators", x => x.id);
                    table.ForeignKey(
                        name: "fk_colaborators_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_colaborators_identityid",
                schema: "decisorframework_domain",
                table: "colaborators",
                column: "identityid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "colaborators",
                schema: "decisorframework_domain");

            migrationBuilder.RenameTable(
                name: "unitmeasurements",
                schema: "decisorframework_domain",
                newName: "unitmeasurements",
                newSchema: "decisorframework_inventory");

            migrationBuilder.RenameTable(
                name: "unitmeasurementconversionbridges",
                schema: "decisorframework_domain",
                newName: "unitmeasurementconversionbridges",
                newSchema: "decisorframework_inventory");

            migrationBuilder.RenameTable(
                name: "centralstatestructures",
                schema: "decisorframework_domain",
                newName: "centralstatestructures",
                newSchema: "decisorframework_legal");

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
                        principalSchema: "decisorframework_inventory",
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
        }
    }
}
