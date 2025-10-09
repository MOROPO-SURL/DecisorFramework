using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class FrameworkUpdate2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacants_organizationalunities_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropIndex(
                name: "ix_vacants_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropColumn(
                name: "responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces");

            migrationBuilder.DropColumn(
                name: "organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.RenameColumn(
                name: "workforceid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "workforceorganizationalunityid");

            migrationBuilder.RenameIndex(
                name: "ix_vacants_workforceid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "ix_vacants_workforceorganizationalunityid");

            migrationBuilder.CreateTable(
                name: "employeedailycheckings",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false),
                    day = table.Column<int>(type: "integer", nullable: false),
                    month = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    checkin = table.Column<TimeSpan>(type: "interval", nullable: false),
                    partialcheckout = table.Column<TimeSpan>(type: "interval", nullable: true),
                    partialcheckin = table.Column<TimeSpan>(type: "interval", nullable: true),
                    checkout = table.Column<TimeSpan>(type: "interval", nullable: true),
                    extracheckin = table.Column<TimeSpan>(type: "interval", nullable: true),
                    extracheckout = table.Column<TimeSpan>(type: "interval", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_employeedailycheckings", x => x.id);
                    table.ForeignKey(
                        name: "fk_employeedailycheckings_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: true),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_organizationalunities_organi~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_vacants_chiefvacantid",
                        column: x => x.chiefvacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_workforceorganizationaluniti~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforceorganizationalunities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunities_workforces_workforceid",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_employeedailycheckings_employeeid_day_month_year",
                schema: "decisorframework_humanresources",
                table: "employeedailycheckings",
                columns: new[] { "employeeid", "day", "month", "year" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_chiefvacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "chiefvacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_organizationalunityid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_parentid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunities_workforceid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "workforceid");

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceorganizationalunityid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforceorganizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vacants_workforceorganizationalunities_workforceorganizatio~",
                schema: "decisorframework_humanresources",
                table: "vacants");

            migrationBuilder.DropTable(
                name: "employeedailycheckings",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources");

            migrationBuilder.RenameColumn(
                name: "workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "workforceid");

            migrationBuilder.RenameIndex(
                name: "ix_vacants_workforceorganizationalunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                newName: "ix_vacants_workforceid");

            migrationBuilder.AddColumn<Guid>(
                name: "responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunitybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunitybridges_workforces_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workforces_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_vacants_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "organizationunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunitybridges_sternid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunitybridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_organizationalunities_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "organizationunityid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vacants_workforces_workforceid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "workforceid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workforces",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workforces_vacants_responsiblevacantid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "responsiblevacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }
    }
}
