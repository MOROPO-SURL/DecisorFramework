using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class RedefineDomainAndHHRRSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_structures_namingresolutions_representativenamingresolution~",
                schema: "decisorframework_domain",
                table: "structures");

            migrationBuilder.DropTable(
                name: "organizationalunityvacantbridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropIndex(
                name: "ix_structures_representativenamingresolutionid",
                schema: "decisorframework_domain",
                table: "structures");

            migrationBuilder.DropColumn(
                name: "representativenamingresolutionid",
                schema: "decisorframework_domain",
                table: "structures");

            migrationBuilder.RenameTable(
                name: "organizationalunities",
                schema: "decisorframework_humanresources",
                newName: "organizationalunities",
                newSchema: "decisorframework_domain");

            migrationBuilder.CreateTable(
                name: "salarystandards",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    fee = table.Column<double>(type: "double precision", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_salarystandards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_structureorganizationalunitybridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_structures_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workforces",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforces", x => x.id);
                    table.ForeignKey(
                        name: "fk_workforces_structures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunityvacantbridge",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false),
                    salarystandardid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunityvacantbridge", x => new { x.workforceid, x.organizationunityid, x.vacantid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_organizationalunit~",
                        column: x => x.organizationunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_salarystandards_sa~",
                        column: x => x.salarystandardid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "salarystandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_vacants_vacantid",
                        column: x => x.vacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridge_workforces_workfor~",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "ix_structureorganizationalunitybridges_sternid",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridge_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "organizationunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridge_salarystandardid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "salarystandardid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridge_vacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "vacantid");

            migrationBuilder.CreateIndex(
                name: "ix_workforces_structureid",
                schema: "decisorframework_humanresources",
                table: "workforces",
                column: "structureid",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunityvacantbridge",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "salarystandards",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workforces",
                schema: "decisorframework_humanresources");

            migrationBuilder.RenameTable(
                name: "organizationalunities",
                schema: "decisorframework_domain",
                newName: "organizationalunities",
                newSchema: "decisorframework_humanresources");

            migrationBuilder.AddColumn<long>(
                name: "representativenamingresolutionid",
                schema: "decisorframework_domain",
                table: "structures",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateTable(
                name: "organizationalunityvacantbridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    count = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunityvacantbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_organizationalunityvacantbridges_organizationalunities_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationalunityvacantbridges_vacants_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_structures_representativenamingresolutionid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "representativenamingresolutionid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalunityvacantbridges_sternid",
                schema: "decisorframework_humanresources",
                table: "organizationalunityvacantbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_structures_namingresolutions_representativenamingresolution~",
                schema: "decisorframework_domain",
                table: "structures",
                column: "representativenamingresolutionid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "namingresolutions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
