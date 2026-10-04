using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendQualityChecksSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "analysisqualitycheckcubanstandardbridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysisqualitycheckcubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_analysisqualitycheckcubanstandardbridges_analysisqualityche~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysisqualitychecks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysisqualitycheckcubanstandardbridges_cubanstandards_ste~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "analysisqualitycheckisostandardbridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_analysisqualitycheckisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_analysisqualitycheckisostandardbridges_analysisqualitycheck~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "analysisqualitychecks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_analysisqualitycheckisostandardbridges_isostandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessmentqualitycheckcubanstandardbridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assessmentqualitycheckcubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_assessmentqualitycheckcubanstandardbridges_assessmentqualit~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "assessmentqualitychecks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assessmentqualitycheckcubanstandardbridges_cubanstandards_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "assessmentqualitycheckisostandardbridges",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_assessmentqualitycheckisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_assessmentqualitycheckisostandardbridges_assessmentqualityc~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_lab",
                        principalTable: "assessmentqualitychecks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_assessmentqualitycheckisostandardbridges_isostandards_stern~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionqualitycheckcubanstandardbridges",
                schema: "decisoriscamaguey_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionqualitycheckcubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionqualitycheckcubanstandardbridges_cubanstandards_s~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionqualitycheckcubanstandardbridges_productionqualit~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_production",
                        principalTable: "productionqualitychecks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productionqualitycheckisostandardbridges",
                schema: "decisoriscamaguey_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productionqualitycheckisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productionqualitycheckisostandardbridges_isostandards_stern~",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productionqualitycheckisostandardbridges_productionqualityc~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_production",
                        principalTable: "productionqualitychecks",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_analysisqualitycheckcubanstandardbridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitycheckcubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_analysisqualitycheckisostandardbridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "analysisqualitycheckisostandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_assessmentqualitycheckcubanstandardbridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "assessmentqualitycheckcubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_assessmentqualitycheckisostandardbridges_sternid",
                schema: "decisoriscamaguey_lab",
                table: "assessmentqualitycheckisostandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionqualitycheckcubanstandardbridges_sternid",
                schema: "decisoriscamaguey_production",
                table: "productionqualitycheckcubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productionqualitycheckisostandardbridges_sternid",
                schema: "decisoriscamaguey_production",
                table: "productionqualitycheckisostandardbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "analysisqualitycheckcubanstandardbridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "analysisqualitycheckisostandardbridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "assessmentqualitycheckcubanstandardbridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "assessmentqualitycheckisostandardbridges",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropTable(
                name: "productionqualitycheckcubanstandardbridges",
                schema: "decisoriscamaguey_production");

            migrationBuilder.DropTable(
                name: "productionqualitycheckisostandardbridges",
                schema: "decisoriscamaguey_production");
        }
    }
}
