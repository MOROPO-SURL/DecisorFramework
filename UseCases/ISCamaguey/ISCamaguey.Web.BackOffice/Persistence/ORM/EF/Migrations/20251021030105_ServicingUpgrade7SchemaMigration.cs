using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade7SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "financierdocumentbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financierdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_financierdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_financierdocumentbridges_financiers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "financierresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_financierresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_financierresearchareabridges_financiers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_financierresearchareabridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_financierdocumentbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "financierdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_financierresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "financierresearchareabridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "financierdocumentbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "financierresearchareabridges",
                schema: "decisoriscamaguey_idi");
        }
    }
}
