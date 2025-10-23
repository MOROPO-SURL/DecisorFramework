using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade9SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "callforpropousals",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    title = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    financierid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforpropousals", x => x.id);
                    table.ForeignKey(
                        name: "fk_callforpropousals_financiers_financierid",
                        column: x => x.financierid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "financiers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforpropousaldocumentbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforpropousaldocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforpropousaldocumentbridges_callforpropousals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforpropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforpropousaldocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "callforpropousalresearchareabridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_callforpropousalresearchareabridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_callforpropousalresearchareabridges_callforpropousals_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "callforpropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_callforpropousalresearchareabridges_researchareas_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "researchareas",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_callforpropousaldocumentbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforpropousaldocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforpropousalresearchareabridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "callforpropousalresearchareabridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_callforpropousals_financierid",
                schema: "decisoriscamaguey_idi",
                table: "callforpropousals",
                column: "financierid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "callforpropousaldocumentbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforpropousalresearchareabridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "callforpropousals",
                schema: "decisoriscamaguey_idi");
        }
    }
}
