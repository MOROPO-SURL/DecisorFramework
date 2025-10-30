using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseplanlegalproviderbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseplannaturalproviderbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "purchaseorderlegalproviderbudgetbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseorderlegalproviderbudgetbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseorderlegalproviderbudgetbridges_legalproviderbudget~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "legalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseorderlegalproviderbudgetbridges_purchaseorders_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseordernaturalproviderbudgetbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseordernaturalproviderbudgetbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseordernaturalproviderbudgetbridges_naturalproviderbu~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "naturalproviderbudgets",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseordernaturalproviderbudgetbridges_purchaseorders_pr~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaseorderlegalproviderbudgetbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseorderlegalproviderbudgetbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseordernaturalproviderbudgetbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseordernaturalproviderbudgetbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "purchaseorderlegalproviderbudgetbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.DropTable(
                name: "purchaseordernaturalproviderbudgetbridges",
                schema: "decisorframework_purchasing");

            migrationBuilder.CreateTable(
                name: "purchaseplanlegalproviderbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplanlegalproviderbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplanlegalproviderbridges_legalproviders_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplanlegalproviderbridges_purchaseorders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "purchaseplannaturalproviderbridges",
                schema: "decisorframework_purchasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    debt = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_purchaseplannaturalproviderbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_purchaseplannaturalproviderbridges_naturalproviders_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_purchaseplannaturalproviderbridges_purchaseorders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_purchasing",
                        principalTable: "purchaseorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplanlegalproviderbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplanlegalproviderbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_purchaseplannaturalproviderbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "purchaseplannaturalproviderbridges",
                column: "sternid");
        }
    }
}
