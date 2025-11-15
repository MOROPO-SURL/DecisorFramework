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
            migrationBuilder.DropTable(
                name: "naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgetproducts",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    budgetid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: true),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false),
                    currentyid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgetproducts", x => x.id);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_classifications_classificatio~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_naturalproviderbudgets_budget~",
                        column: x => x.budgetid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproducts_unitmeasurements_unitmeasurem~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_budgetid_productid_classifica~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                columns: new[] { "budgetid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_classificationid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproducts_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproducts",
                column: "unitmeasurementid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "naturalproviderbudgetproducts",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    budgetid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    classificationid = table.Column<Guid>(type: "uuid", nullable: false),
                    currentyid = table.Column<Guid>(type: "uuid", nullable: false),
                    unitmeasurementid = table.Column<Guid>(type: "uuid", nullable: false),
                    amount = table.Column<decimal>(type: "numeric", nullable: false),
                    unitprice = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbudgetproductbridges", x => new { x.budgetid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_classifications_classif~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbudgetproductbridges_naturalproviderbudgets_~",
                        column: x => x.budgetid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumn: "id",
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

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproductbridges_classificationid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgetproductbridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "currentyid");

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
        }
    }
}
