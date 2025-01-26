using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResourcesRedefine01SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_namingresolutions_vacants_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunityvacantbridge_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge");

            migrationBuilder.DropTable(
                name: "vacants",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "vacantkinds",
                schema: "decisorframework_humanresources");

            migrationBuilder.CreateTable(
                name: "workpositionkinds",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    shortname = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_workpositionkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "workpositions",
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
                    table.PrimaryKey("pk_workpositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_workpositions_schoolings_schoolingid",
                        column: x => x.schoolingid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "schoolings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_workpositions_workpositionkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositionkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_workpositions_kindid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_workpositions_schoolingid",
                schema: "decisorframework_humanresources",
                table: "workpositions",
                column: "schoolingid");

            migrationBuilder.AddForeignKey(
                name: "fk_namingresolutions_workpositions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions",
                column: "ocupationid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunityvacantbridge_workpositions_vaca~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_namingresolutions_workpositions_ocupationid",
                schema: "decisorframework_humanresources",
                table: "namingresolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_workforceorganizationalunityvacantbridge_workpositions_vaca~",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge");

            migrationBuilder.DropTable(
                name: "workpositions",
                schema: "decisorframework_humanresources");

            migrationBuilder.DropTable(
                name: "workpositionkinds",
                schema: "decisorframework_humanresources");

            migrationBuilder.CreateTable(
                name: "vacantkinds",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    shortname = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacantkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "vacants",
                schema: "decisorframework_humanresources",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    schoolingid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vacants", x => x.id);
                    table.ForeignKey(
                        name: "fk_vacants_schoolings_schoolingid",
                        column: x => x.schoolingid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "schoolings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vacants_vacantkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "vacantkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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

            migrationBuilder.AddForeignKey(
                name: "fk_workforceorganizationalunityvacantbridge_vacants_vacantid",
                schema: "decisorframework_humanresources",
                table: "workforceorganizationalunityvacantbridge",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
