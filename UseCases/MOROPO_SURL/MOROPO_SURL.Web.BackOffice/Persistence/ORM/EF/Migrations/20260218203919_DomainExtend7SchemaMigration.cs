using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend7SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_r~",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunities_organizationalunities_organi~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities");

            migrationBuilder.DropTable(
                name: "organizationalstructuringunities",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "structureorganizationalunitybridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalunities",
                schema: "decisorframework_domain");

            migrationBuilder.RenameColumn(
                name: "rootstructuringunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "rootstructuringunitid");

            migrationBuilder.RenameIndex(
                name: "ix_organizationalstructures_rootstructuringunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "ix_organizationalstructures_rootstructuringunitid");

            migrationBuilder.AddColumn<Guid>(
                name: "organizationalstructureid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "organizationalunits",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "character varying(200)", maxLength: 200, nullable: false),
                    description = table.Column<string>(type: "character varying(1024)", maxLength: 1024, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunits", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizationalstructuringunits",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunitid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    reference = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructuringunits", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunits_organizationalstructuringuni~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunits",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunits_organizationalunits_organiza~",
                        column: x => x.organizationalunitid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunits",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_administrativeentities_organizationalstructureid",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "organizationalstructureid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunits_organizationalunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunits",
                column: "organizationalunitid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunits_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunits",
                column: "parentid");

            migrationBuilder.AddForeignKey(
                name: "fk_administrativeentities_organizationalstructures_organizatio~",
                schema: "decisorframework_domain",
                table: "administrativeentities",
                column: "organizationalstructureid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructures",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunits_roo~",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "rootstructuringunitid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructuringunits",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunities_organizationalunits_organiza~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "organizationalunityid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalunits",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_administrativeentities_organizationalstructures_organizatio~",
                schema: "decisorframework_domain",
                table: "administrativeentities");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunits_roo~",
                schema: "decisorframework_domain",
                table: "organizationalstructures");

            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunities_organizationalunits_organiza~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities");

            migrationBuilder.DropTable(
                name: "organizationalstructuringunits",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "organizationalunits",
                schema: "decisorframework_domain");

            migrationBuilder.DropIndex(
                name: "ix_administrativeentities_organizationalstructureid",
                schema: "decisorframework_domain",
                table: "administrativeentities");

            migrationBuilder.DropColumn(
                name: "organizationalstructureid",
                schema: "decisorframework_domain",
                table: "administrativeentities");

            migrationBuilder.RenameColumn(
                name: "rootstructuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "rootstructuringunityid");

            migrationBuilder.RenameIndex(
                name: "ix_organizationalstructures_rootstructuringunitid",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                newName: "ix_organizationalstructures_rootstructuringunityid");

            migrationBuilder.CreateTable(
                name: "organizationalunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalunities_organizationalunities_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "organizationalstructuringunities",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    organizationalunityid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    reference = table.Column<string>(type: "character varying(120)", maxLength: 120, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalstructuringunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunities_organizationalstructuringu~",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalstructuringunities",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationalstructuringunities_organizationalunities_orga~",
                        column: x => x.organizationalunityid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
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
                        name: "fk_structureorganizationalunitybridges_administrativeentities_~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "administrativeentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_structureorganizationalunitybridges_organizationalunities_s~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "organizationalunities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunities_organizationalunityid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                column: "organizationalunityid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalstructuringunities_parentid",
                schema: "decisorframework_domain",
                table: "organizationalstructuringunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalunities_parentid",
                schema: "decisorframework_domain",
                table: "organizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_structureorganizationalunitybridges_sternid",
                schema: "decisorframework_domain",
                table: "structureorganizationalunitybridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationalstructures_organizationalstructuringunities_r~",
                schema: "decisorframework_domain",
                table: "organizationalstructures",
                column: "rootstructuringunityid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalstructuringunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunities_organizationalunities_organi~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunities",
                column: "organizationalunityid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationalunities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
