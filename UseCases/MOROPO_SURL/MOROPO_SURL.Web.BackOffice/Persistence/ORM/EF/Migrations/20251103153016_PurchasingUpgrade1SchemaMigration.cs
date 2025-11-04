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
                name: "fk_legalproviderbudgetservicebridge_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_requestableservices_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropTable(
                name: "legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.RenameTable(
                name: "legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                newName: "legalproviderbudgetservicebridges",
                newSchema: "decisorframework_purchasing");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetservicebridge_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                newName: "ix_legalproviderbudgetservicebridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetservicebridge_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                newName: "ix_legalproviderbudgetservicebridges_currentyid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgetproducts",
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
                    table.PrimaryKey("pk_legalproviderbudgetproducts", x => x.id);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_classifications_classificationid",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_legalproviderbudgets_budgetid",
                        column: x => x.budgetid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproducts_unitmeasurements_unitmeasuremen~",
                        column: x => x.unitmeasurementid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "unitmeasurements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_budgetid_productid_classificati~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                columns: new[] { "budgetid", "productid", "classificationid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_classificationid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "currentyid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproducts_unitmeasurementid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproducts",
                column: "unitmeasurementid");

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridges_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                column: "currentyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridges_legalproviderbudgets_prow~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "legalproviderbudgets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridges_requestableservices_stern~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges",
                column: "sternid",
                principalSchema: "decisorframework_commercial",
                principalTable: "requestableservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridges_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridges_legalproviderbudgets_prow~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridges_requestableservices_stern~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges");

            migrationBuilder.DropTable(
                name: "legalproviderbudgetproducts",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridges");

            migrationBuilder.RenameTable(
                name: "legalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                newName: "legalproviderbudgetservicebridge",
                newSchema: "decisorframework_purchasing");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetservicebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "ix_legalproviderbudgetservicebridge_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetservicebridges_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "ix_legalproviderbudgetservicebridge_currentyid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.CreateTable(
                name: "legalproviderbudgetproductbridge",
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
                    table.PrimaryKey("pk_legalproviderbudgetproductbridge", x => new { x.budgetid, x.productid, x.classificationid });
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_classifications_classifica~",
                        column: x => x.classificationid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "classifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_currencies_currentyid",
                        column: x => x.currentyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbudgetproductbridge_legalproviderbudgets_budge~",
                        column: x => x.budgetid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumn: "id",
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

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproductbridge_classificationid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "classificationid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgetproductbridge_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "currentyid");

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

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_currencies_currentyid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "currentyid",
                principalSchema: "decisorframework_finantial",
                principalTable: "currencies",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "legalproviderbudgets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_requestableservices_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "sternid",
                principalSchema: "decisorframework_commercial",
                principalTable: "requestableservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
