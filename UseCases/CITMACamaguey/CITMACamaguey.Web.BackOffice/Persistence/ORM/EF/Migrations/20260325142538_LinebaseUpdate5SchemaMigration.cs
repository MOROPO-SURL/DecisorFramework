using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.CITMACamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LinebaseUpdate5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "academicachievements",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    academiclevel = table.Column<int>(type: "integer", nullable: false),
                    mainknowledgeareaid = table.Column<Guid>(type: "uuid", nullable: false),
                    title = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: true),
                    institution = table.Column<string>(type: "character varying(512)", maxLength: 512, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academicachievements", x => x.id);
                    table.ForeignKey(
                        name: "fk_academicachievements_knowledgeareas_mainknowledgeareaid",
                        column: x => x.mainknowledgeareaid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academicachievements_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "academicachievementknowledgeareabridges",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_academicachievementknowledgeareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_academicachievementknowledgeareabridges_academicachievement~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "academicachievements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_academicachievementknowledgeareabridges_knowledgeareas_ster~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "knowledgeareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_academicachievementknowledgeareabridges_sternid",
                schema: "decisorframework_domain",
                table: "academicachievementknowledgeareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_academicachievements_contactid",
                schema: "decisorframework_domain",
                table: "academicachievements",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_academicachievements_mainknowledgeareaid",
                schema: "decisorframework_domain",
                table: "academicachievements",
                column: "mainknowledgeareaid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "academicachievementknowledgeareabridges",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "academicachievements",
                schema: "decisorframework_domain");
        }
    }
}
