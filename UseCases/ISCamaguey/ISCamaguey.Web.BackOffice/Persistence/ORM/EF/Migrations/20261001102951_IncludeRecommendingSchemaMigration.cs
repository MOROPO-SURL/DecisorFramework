using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IncludeRecommendingSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_recommending");

            migrationBuilder.CreateTable(
                name: "recomendationreports",
                schema: "decisoriscamaguey_recommending",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    documentid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recomendationreports", x => x.id);
                    table.ForeignKey(
                        name: "fk_recomendationreports_documents_documentid",
                        column: x => x.documentid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "recomendationreportemployeebridges",
                schema: "decisoriscamaguey_recommending",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_recomendationreportemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_recomendationreportemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_recomendationreportemployeebridges_recomendationreports_pro~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_recommending",
                        principalTable: "recomendationreports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_recomendationreportemployeebridges_sternid",
                schema: "decisoriscamaguey_recommending",
                table: "recomendationreportemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_recomendationreports_documentid",
                schema: "decisoriscamaguey_recommending",
                table: "recomendationreports",
                column: "documentid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "recomendationreportemployeebridges",
                schema: "decisoriscamaguey_recommending");

            migrationBuilder.DropTable(
                name: "recomendationreports",
                schema: "decisoriscamaguey_recommending");
        }
    }
}
