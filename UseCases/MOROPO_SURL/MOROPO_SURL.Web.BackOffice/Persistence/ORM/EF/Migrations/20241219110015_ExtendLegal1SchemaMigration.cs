using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLegal1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_clausetagbridges_clauses_clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges");

            migrationBuilder.DropIndex(
                name: "ix_clausetagbridges_clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges");

            migrationBuilder.DropColumn(
                name: "clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges");

            migrationBuilder.CreateTable(
                name: "centralstatestructures",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_centralstatestructures", x => x.id);
                    table.ForeignKey(
                        name: "fk_centralstatestructures_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "proclamationkinds",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proclamationkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "regulationkinds",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regulationkinds", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "proclamations",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    releasedat = table.Column<DateTime>(type: "timestamp with time zone", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false),
                    documentid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_proclamations", x => x.id);
                    table.ForeignKey(
                        name: "fk_proclamations_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_proclamations_proclamationkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proclamationkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "regulations",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    year = table.Column<int>(type: "integer", nullable: false),
                    proclamationid = table.Column<Guid>(type: "uuid", nullable: false),
                    kindid = table.Column<Guid>(type: "uuid", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_regulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_regulations_centralstatestructures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "centralstatestructures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_regulations_proclamations_proclamationid",
                        column: x => x.proclamationid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "proclamations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_regulations_regulationkinds_kindid",
                        column: x => x.kindid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "regulationkinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dispositions",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    regulationid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    segment = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_dispositions_regulations_regulationid",
                        column: x => x.regulationid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "regulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "dispositiontagbridges",
                schema: "decisorframework_legal",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_dispositiontagbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_dispositiontagbridges_clausetags_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clausetags",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_dispositiontagbridges_dispositions_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "dispositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_centralstatestructures_identityid",
                schema: "decisorframework_legal",
                table: "centralstatestructures",
                column: "identityid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_dispositions_regulationid",
                schema: "decisorframework_legal",
                table: "dispositions",
                column: "regulationid");

            migrationBuilder.CreateIndex(
                name: "ix_dispositiontagbridges_sternid",
                schema: "decisorframework_legal",
                table: "dispositiontagbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_proclamations_documentid",
                schema: "decisorframework_legal",
                table: "proclamations",
                column: "documentid");

            migrationBuilder.CreateIndex(
                name: "ix_proclamations_kindid",
                schema: "decisorframework_legal",
                table: "proclamations",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_regulations_kindid",
                schema: "decisorframework_legal",
                table: "regulations",
                column: "kindid");

            migrationBuilder.CreateIndex(
                name: "ix_regulations_proclamationid",
                schema: "decisorframework_legal",
                table: "regulations",
                column: "proclamationid");

            migrationBuilder.CreateIndex(
                name: "ix_regulations_structureid",
                schema: "decisorframework_legal",
                table: "regulations",
                column: "structureid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "dispositiontagbridges",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "dispositions",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "regulations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "centralstatestructures",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "proclamations",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "regulationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.DropTable(
                name: "proclamationkinds",
                schema: "decisorframework_legal");

            migrationBuilder.AddColumn<Guid>(
                name: "clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_clausetagbridges_clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges",
                column: "clauseid");

            migrationBuilder.AddForeignKey(
                name: "fk_clausetagbridges_clauses_clauseid",
                schema: "decisorframework_legal",
                table: "clausetagbridges",
                column: "clauseid",
                principalSchema: "decisorframework_legal",
                principalTable: "clauses",
                principalColumn: "id");
        }
    }
}
