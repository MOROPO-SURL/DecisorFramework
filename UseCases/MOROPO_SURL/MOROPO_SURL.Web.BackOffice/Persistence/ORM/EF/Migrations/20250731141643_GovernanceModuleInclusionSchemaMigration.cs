using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class GovernanceModuleInclusionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisorframework_governance");

            migrationBuilder.CreateTable(
                name: "decisionmakinggroups",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    structureid = table.Column<Guid>(type: "uuid", nullable: false),
                    leaderid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroups", x => x.id);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroups_employees_leaderid",
                        column: x => x.leaderid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroups_structures_structureid",
                        column: x => x.structureid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "structures",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "decisionmakinggroupcontactbridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroupcontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupcontactbridges_decisionmakinggroups_prow~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "decisionmakinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupcontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "decisionmakinggroupemployeebridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_decisionmakinggroupemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupemployeebridges_decisionmakinggroups_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "decisionmakinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_decisionmakinggroupemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetings",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    decisionmakinggroupid = table.Column<Guid>(type: "uuid", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    summary = table.Column<string>(type: "text", nullable: true),
                    rapporteurship = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetings", x => x.id);
                    table.ForeignKey(
                        name: "fk_meetings_decisionmakinggroups_decisionmakinggroupid",
                        column: x => x.decisionmakinggroupid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "decisionmakinggroups",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetings_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "agreements",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meetingid = table.Column<Guid>(type: "uuid", nullable: false),
                    index = table.Column<int>(type: "integer", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_agreements", x => x.id);
                    table.ForeignKey(
                        name: "fk_agreements_meetings_meetingid",
                        column: x => x.meetingid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_agreements_personcontacts_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "meetingcontactbridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetingcontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_meetingcontactbridges_meetings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetingcontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetingdocumentbridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetingdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_meetingdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetingdocumentbridges_meetings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "meetingemployeebridges",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_meetingemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_meetingemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_meetingemployeebridges_meetings_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "statements",
                schema: "decisorframework_governance",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    meetingid = table.Column<Guid>(type: "uuid", nullable: false),
                    rapporteurship = table.Column<string>(type: "text", nullable: true),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_statements", x => x.id);
                    table.ForeignKey(
                        name: "fk_statements_meetings_meetingid",
                        column: x => x.meetingid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "meetings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_statements_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "ix_agreements_index_meetingid",
                schema: "decisorframework_governance",
                table: "agreements",
                columns: new[] { "index", "meetingid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_agreements_meetingid",
                schema: "decisorframework_governance",
                table: "agreements",
                column: "meetingid");

            migrationBuilder.CreateIndex(
                name: "ix_agreements_responsibleid",
                schema: "decisorframework_governance",
                table: "agreements",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroupcontactbridges_sternid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroupcontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroupemployeebridges_sternid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroupemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroups_leaderid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "leaderid");

            migrationBuilder.CreateIndex(
                name: "ix_decisionmakinggroups_structureid",
                schema: "decisorframework_governance",
                table: "decisionmakinggroups",
                column: "structureid");

            migrationBuilder.CreateIndex(
                name: "ix_meetingcontactbridges_sternid",
                schema: "decisorframework_governance",
                table: "meetingcontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_meetingdocumentbridges_sternid",
                schema: "decisorframework_governance",
                table: "meetingdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_meetingemployeebridges_sternid",
                schema: "decisorframework_governance",
                table: "meetingemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_meetings_authorid",
                schema: "decisorframework_governance",
                table: "meetings",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_meetings_decisionmakinggroupid",
                schema: "decisorframework_governance",
                table: "meetings",
                column: "decisionmakinggroupid");

            migrationBuilder.CreateIndex(
                name: "ix_meetings_index_decisionmakinggroupid",
                schema: "decisorframework_governance",
                table: "meetings",
                columns: new[] { "index", "decisionmakinggroupid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_statements_contactid",
                schema: "decisorframework_governance",
                table: "statements",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_statements_meetingid",
                schema: "decisorframework_governance",
                table: "statements",
                column: "meetingid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "agreements",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "decisionmakinggroupcontactbridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "decisionmakinggroupemployeebridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetingcontactbridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetingdocumentbridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetingemployeebridges",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "statements",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "meetings",
                schema: "decisorframework_governance");

            migrationBuilder.DropTable(
                name: "decisionmakinggroups",
                schema: "decisorframework_governance");
        }
    }
}
