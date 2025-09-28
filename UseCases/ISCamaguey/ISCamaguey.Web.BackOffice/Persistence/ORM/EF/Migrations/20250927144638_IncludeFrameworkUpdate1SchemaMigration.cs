using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IncludeFrameworkUpdate1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "area",
                schema: "decisorframework_domain",
                table: "properties");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_quality");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_servicing");

            migrationBuilder.EnsureSchema(
                name: "decisoriscamaguey_domain");

            migrationBuilder.CreateTable(
                name: "certifications",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    created = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certifications", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "cubanstandards",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_cubanstandards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "isostandards",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_isostandards", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisservicereports",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    employeeid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservicereports", x => x.id);
                    table.ForeignKey(
                        name: "fk_sampleanalysisservicereports_employees_employeeid",
                        column: x => x.employeeid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisservices",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisservices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "techniques",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_techniques", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "trainingservices",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingservices", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "certificationcubanstandardbridges",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificationcubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_certificationcubanstandardbridges_certifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "certifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_certificationcubanstandardbridges_cubanstandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "certificationisostandardbridges",
                schema: "decisoriscamaguey_quality",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_certificationisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_certificationisostandardbridges_certifications_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "certifications",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_certificationisostandardbridges_isostandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "techniquecubanstandardbridges",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_techniquecubanstandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_techniquecubanstandardbridges_cubanstandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "cubanstandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_techniquecubanstandardbridges_techniques_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "techniqueisostandardbridges",
                schema: "decisoriscamaguey_domain",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_techniqueisostandardbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_techniqueisostandardbridges_isostandards_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_quality",
                        principalTable: "isostandards",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_techniqueisostandardbridges_techniques_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "serviceorders",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    sampleanalysislegalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleanalysisserviceid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleanalysisreportid = table.Column<Guid>(type: "uuid", nullable: true),
                    requestedtechniqueid = table.Column<Guid>(type: "uuid", nullable: true),
                    traininglegalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    trainingserviceid = table.Column<Guid>(type: "uuid", nullable: true),
                    trainingresponsibleid = table.Column<Guid>(type: "uuid", nullable: true),
                    sampleanalysisnaturalclientid = table.Column<Guid>(type: "uuid", nullable: true),
                    trainingnaturalclientid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_serviceorders", x => x.id);
                    table.ForeignKey(
                        name: "fk_serviceorders_employees_trainingresponsibleid",
                        column: x => x.trainingresponsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_legalclients_sampleanalysislegalclientid",
                        column: x => x.sampleanalysislegalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_legalclients_traininglegalclientid",
                        column: x => x.traininglegalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_naturalclients_sampleanalysisnaturalclientid",
                        column: x => x.sampleanalysisnaturalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_naturalclients_trainingnaturalclientid",
                        column: x => x.trainingnaturalclientid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_sampleanalysisservicereports_sampleanalysisre~",
                        column: x => x.sampleanalysisreportid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservicereports",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_sampleanalysisservices_sampleanalysisserviceid",
                        column: x => x.sampleanalysisserviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_serviceorders_techniques_requestedtechniqueid",
                        column: x => x.requestedtechniqueid,
                        principalSchema: "decisoriscamaguey_domain",
                        principalTable: "techniques",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_serviceorders_trainingservices_trainingserviceid",
                        column: x => x.trainingserviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "collects",
                schema: "decisorframework_finantial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expectedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    amount = table.Column<float>(type: "real", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    discriminator = table.Column<string>(type: "text", nullable: false),
                    orderid = table.Column<long>(type: "bigint", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_collects", x => x.id);
                    table.ForeignKey(
                        name: "fk_collects_serviceorders_orderid",
                        column: x => x.orderid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "serviceorders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_certificationcubanstandardbridges_sternid",
                schema: "decisoriscamaguey_quality",
                table: "certificationcubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_certificationisostandardbridges_sternid",
                schema: "decisoriscamaguey_quality",
                table: "certificationisostandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_collects_orderid",
                schema: "decisorframework_finantial",
                table: "collects",
                column: "orderid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservicereports_employeeid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicereports",
                column: "employeeid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_requestedtechniqueid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "requestedtechniqueid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysislegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysislegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisnaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisreportid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisreportid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_sampleanalysisserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "sampleanalysisserviceid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_traininglegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "traininglegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingnaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingnaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingresponsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingserviceid");

            migrationBuilder.CreateIndex(
                name: "ix_techniquecubanstandardbridges_sternid",
                schema: "decisoriscamaguey_domain",
                table: "techniquecubanstandardbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_techniqueisostandardbridges_sternid",
                schema: "decisoriscamaguey_domain",
                table: "techniqueisostandardbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "certificationcubanstandardbridges",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "certificationisostandardbridges",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "collects",
                schema: "decisorframework_finantial");

            migrationBuilder.DropTable(
                name: "techniquecubanstandardbridges",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "techniqueisostandardbridges",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "certifications",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "serviceorders",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "cubanstandards",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "isostandards",
                schema: "decisoriscamaguey_quality");

            migrationBuilder.DropTable(
                name: "sampleanalysisservicereports",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisservices",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "techniques",
                schema: "decisoriscamaguey_domain");

            migrationBuilder.DropTable(
                name: "trainingservices",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.AddColumn<decimal>(
                name: "area",
                schema: "decisorframework_domain",
                table: "properties",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);
        }
    }
}
