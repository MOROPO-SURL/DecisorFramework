using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRUpgrade3SchemaMigration : Migration
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

            migrationBuilder.DropTable(
                name: "workforceorganizationalunitybridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workforceorganizationalunityvacantbridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropIndex(
                name: "ix_vacants_organizationunityid",
                schema: "decisorframework_humanresources",
                table: "vacants");

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
                name: "workforceorganizationalunities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    chiefvacantid = table.Column<Guid>(type: "uuid", nullable: false),
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
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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

            migrationBuilder.CreateTable(
                name: "workforceorganizationalunityvacantbridges",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    workforceid = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    vacantid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workforceorganizationalunityvacantbridges", x => new { x.workforceid, x.organizationalunityid, x.vacantid });
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridges_organizationaluni~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridges_vacants_vacantid",
                        column: x => x.vacantid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacants",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workforceorganizationalunityvacantbridges_workforces_workfo~",
                        column: x => x.workforceid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workforces",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridges_organizationaluni~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridges",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_workforceorganizationalunityvacantbridges_vacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridges",
                column: "vacantid",
                unique: true);

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
        }
    }
}
