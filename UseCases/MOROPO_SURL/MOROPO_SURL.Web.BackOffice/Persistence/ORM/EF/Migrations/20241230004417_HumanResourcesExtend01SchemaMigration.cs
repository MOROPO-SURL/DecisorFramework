using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourcesExtend01SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "representativenamingresolutionnid",
                schema: "decisorframework_domain",
                table: "structures",
                newName: "representativenamingresolutionid");

            migrationBuilder.RenameIndex(
                name: "ix_structures_representativenamingresolutionnid",
                schema: "decisorframework_domain",
                table: "structures",
                newName: "ix_structures_representativenamingresolutionid");

            migrationBuilder.AddColumn<Guid>(
                name: "ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "ocupationkinds",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_ocupationkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "organizationalunities",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationalunities", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationalunities_organizationalunities_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "organizationalunities",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "schoolings",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_schoolings", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vacants",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    schoolingid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacants", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacants_ocupationkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "ocupationkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacants_schoolings_schoolingid",
                        column: x => x.schoolingid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "schoolings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ix_namingresolutions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                column: "ocupationid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalunities_parentid",
                schema: "decisorframework_humanresources",
                table: "organizationalunities",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationalunityvacantbridges_sternid",
                schema: "decisorframework_humanresources",
                table: "organizationalunityvacantbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_kindid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_vacants_schoolingid",
                schema: "decisorframework_humanresources",
                table: "vacants",
                column: "schoolingid");

            migrationBuilder.AddForeignKey(
                name: "fk_namingresolutions_vacants_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                column: "ocupationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_namingresolutions_vacants_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropTable(
                name: "organizationalunityvacantbridges",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "organizationalunities",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacants",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "ocupationkinds",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "schoolings",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropIndex(
                name: "ix_namingresolutions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropColumn(
                name: "ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.RenameColumn(
                name: "representativenamingresolutionid",
                schema: "decisorframework_domain",
                table: "structures",
                newName: "representativenamingresolutionnid");

            migrationBuilder.RenameIndex(
                name: "ix_structures_representativenamingresolutionid",
                schema: "decisorframework_domain",
                table: "structures",
                newName: "ix_structures_representativenamingresolutionnid");
        }
    }
}
