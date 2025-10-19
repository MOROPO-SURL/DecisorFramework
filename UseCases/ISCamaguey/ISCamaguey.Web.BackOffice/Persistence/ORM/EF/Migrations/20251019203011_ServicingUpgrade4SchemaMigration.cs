using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sampleanalysisservicedocumentbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservicedocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicedocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicedocumentbridges_sampleanalysisservices~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingservicedocumentbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservicedocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingservicedocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingservicedocumentbridges_trainingservices_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicedocumentbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicedocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservicedocumentbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicedocumentbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sampleanalysisservicedocumentbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "trainingservicedocumentbridges",
                schema: "decisoriscamaguey_servicing");
        }
    }
}
