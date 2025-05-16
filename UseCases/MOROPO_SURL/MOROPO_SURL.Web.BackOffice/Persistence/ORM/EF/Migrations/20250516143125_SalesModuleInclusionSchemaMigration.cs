using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class SalesModuleInclusionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisorframework_sales");

            migrationBuilder.CreateTable(
                name: "abstractsale",
                schema: "decisorframework_sales",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    sellerid = table.Column<Guid>(type: "uuid", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    contractnumber = table.Column<int>(type: "integer", nullable: true),
                    contractyear = table.Column<int>(type: "integer", nullable: true),
                    budgetnumber = table.Column<int>(type: "integer", nullable: true),
                    budgetyear = table.Column<int>(type: "integer", nullable: true),
                    identityid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_abstractsale", x => x.id);
                    table.ForeignKey(
                        name: "fk_abstractsale_abstractbudget_budgetnumber_budgetyear",
                        columns: x => new { x.budgetnumber, x.budgetyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "abstractbudget",
                        principalColumns: new[] { "number", "year" },
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_employees_sellerid",
                        column: x => x.sellerid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_abstractsale_legalclientsalecontracts_contractnumber_contra~",
                        columns: x => new { x.contractnumber, x.contractyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclientsalecontracts",
                        principalColumns: new[] { "number", "year" });
                    table.ForeignKey(
                        name: "fk_abstractsale_naturalclientsalecontracts_contractnumber_cont~",
                        columns: x => new { x.contractnumber, x.contractyear },
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclientsalecontracts",
                        principalColumns: new[] { "number", "year" });
                    table.ForeignKey(
                        name: "fk_abstractsale_personidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "personidentities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_budgetnumber_budgetyear",
                schema: "decisorframework_sales",
                table: "abstractsale",
                columns: new[] { "budgetnumber", "budgetyear" });

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_contractnumber_contractyear",
                schema: "decisorframework_sales",
                table: "abstractsale",
                columns: new[] { "contractnumber", "contractyear" });

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_identityid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "identityid");

            migrationBuilder.CreateIndex(
                name: "ix_abstractsale_sellerid",
                schema: "decisorframework_sales",
                table: "abstractsale",
                column: "sellerid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abstractsale",
                schema: "decisorframework_sales");
        }
    }
}
