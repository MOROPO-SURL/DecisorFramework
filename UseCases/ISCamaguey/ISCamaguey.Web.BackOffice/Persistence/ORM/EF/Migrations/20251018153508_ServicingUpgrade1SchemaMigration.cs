using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "sampleanalysisservicesteps",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservicesteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicesteps_sampleanalysisservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicesteps_sampleanalysisservicesteps_paren~",
                        column: x => x.parentid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservicesteps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "trainingservicesteps",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservicesteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_trainingservicesteps_trainingservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingservicesteps_trainingservicesteps_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservicesteps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    requiredtimingeffort = table.Column<decimal>(type: "numeric", nullable: false),
                    fixedparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    relativeparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservicestepworkpositionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicestepworkpositionbridges_sampleanalysis~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservicesteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicestepworkpositionbridges_workpositions_~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    requiredtimingeffort = table.Column<decimal>(type: "numeric", nullable: false),
                    fixedparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    relativeparticipation = table.Column<decimal>(type: "numeric", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservicestepworkpositionbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingservicestepworkpositionbridges_trainingservicesteps~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservicesteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingservicestepworkpositionbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicesteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicesteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicestepworkpositionbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservicesteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservicesteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingservicestepworkpositionbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "sampleanalysisservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "trainingservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisservicesteps",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "trainingservicesteps",
                schema: "decisoriscamaguey_servicing");
        }
    }
}
