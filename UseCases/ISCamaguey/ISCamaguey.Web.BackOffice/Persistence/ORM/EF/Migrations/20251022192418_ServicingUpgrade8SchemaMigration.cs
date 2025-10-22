using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade8SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicesteps_sampleanalysisservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicesteps_sampleanalysisservicesteps_paren~",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicestepworkpositionbridges_sampleanalysis~",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservicestepworkpositionbridges_workpositions_~",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservicesteps_trainingservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservicesteps_trainingservicesteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservicestepworkpositionbridges_trainingservicesteps~",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservicestepworkpositionbridges_workpositions_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_trainingservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_trainingservicesteps",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sampleanalysisservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sampleanalysisservicesteps",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps");

            migrationBuilder.RenameTable(
                name: "trainingservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                newName: "trainingservstepworkposbridges",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameTable(
                name: "trainingservicesteps",
                schema: "decisoriscamaguey_servicing",
                newName: "trainingservsteps",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameTable(
                name: "sampleanalysisservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                newName: "sampanalservstepworkposbridges",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameTable(
                name: "sampleanalysisservicesteps",
                schema: "decisoriscamaguey_servicing",
                newName: "sampanalservsteps",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameIndex(
                name: "ix_trainingservicestepworkpositionbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges",
                newName: "ix_trainingservstepworkposbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_trainingservicesteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                newName: "ix_trainingservsteps_serviceid");

            migrationBuilder.RenameIndex(
                name: "ix_trainingservicesteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                newName: "ix_trainingservsteps_parentid");

            migrationBuilder.RenameIndex(
                name: "ix_sampleanalysisservicestepworkpositionbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges",
                newName: "ix_sampanalservstepworkposbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_sampleanalysisservicesteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                newName: "ix_sampanalservsteps_serviceid");

            migrationBuilder.RenameIndex(
                name: "ix_sampleanalysisservicesteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                newName: "ix_sampanalservsteps_parentid");

            migrationBuilder.AddColumn<Guid>(
                name: "responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudyserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_trainingservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_trainingservsteps",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sampanalservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_sampanalservsteps",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                column: "id");

            migrationBuilder.CreateTable(
                name: "groundintegralstudyservices",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    responsibleid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintegralstudyservices", x => x.id);
                    table.ForeignKey(
                        name: "fk_groundintegralstudyservices_employees_responsibleid",
                        column: x => x.responsibleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "sampleanalysisserviceemployeebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_sampleanalysisserviceemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_sampleanalysisserviceemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_sampleanalysisserviceemployeebridges_sampleanalysisservices~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "sampleanalysisservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "trainingserviceemployeebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_trainingserviceemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_trainingserviceemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_trainingserviceemployeebridges_trainingservices_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "trainingservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintegralstudyservicedocumentbridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintegralstudyservicedocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_groundintegralstudyservicedocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintegralstudyservicedocumentbridges_groundintegralstu~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintegralstudyserviceemployeebridges",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintegralstudyserviceemployeebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_groundintegralstudyserviceemployeebridges_employees_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintegralstudyserviceemployeebridges_groundintegralstu~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "groundintstudyservsteps",
                schema: "decisoriscamaguey_servicing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    parentid = table.Column<Guid>(type: "uuid", nullable: true),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    description = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_groundintstudyservsteps", x => x.id);
                    table.ForeignKey(
                        name: "fk_groundintstudyservsteps_groundintegralstudyservices_service~",
                        column: x => x.serviceid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintegralstudyservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintstudyservsteps_groundintstudyservsteps_parentid",
                        column: x => x.parentid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintstudyservsteps",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "groundintstudyservstepworkposbridges",
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
                    table.PrimaryKey("pk_groundintstudyservstepworkposbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_groundintstudyservstepworkposbridges_groundintstudyservstep~",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_servicing",
                        principalTable: "groundintstudyservsteps",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_groundintstudyservstepworkposbridges_workpositions_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "workpositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_trainingservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudylegalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudynaturalclientid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyresponsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudyserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyserviceid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintegralstudyservicedocumentbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintegralstudyservicedocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintegralstudyserviceemployeebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintegralstudyserviceemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintegralstudyservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintegralstudyservices",
                column: "responsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintstudyservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintstudyservsteps",
                column: "parentid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintstudyservsteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintstudyservsteps",
                column: "serviceid");

            migrationBuilder.CreateIndex(
                name: "ix_groundintstudyservstepworkposbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "groundintstudyservstepworkposbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisserviceemployeebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisserviceemployeebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_trainingserviceemployeebridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingserviceemployeebridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_sampanalservsteps_sampanalservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                column: "parentid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampanalservsteps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sampanalservsteps_sampleanalysisservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps",
                column: "serviceid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampleanalysisservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampanalservstepworkposbridges_sampanalservsteps_prowid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges",
                column: "prowid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampanalservsteps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampanalservstepworkposbridges_workpositions_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges",
                column: "sternid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservices_employees_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                column: "responsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_employees_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyresponsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_groundintegralstudyservices_groundintegralstu~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyserviceid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "groundintegralstudyservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_legalclients_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudylegalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_naturalclients_groundintegralstudynaturalclie~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudynaturalclientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservices_employees_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices",
                column: "responsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservsteps_trainingservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                column: "serviceid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "trainingservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservsteps_trainingservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps",
                column: "parentid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "trainingservsteps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservstepworkposbridges_trainingservsteps_prowid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges",
                column: "prowid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "trainingservsteps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservstepworkposbridges_workpositions_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges",
                column: "sternid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sampanalservsteps_sampanalservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps");

            migrationBuilder.DropForeignKey(
                name: "fk_sampanalservsteps_sampleanalysisservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps");

            migrationBuilder.DropForeignKey(
                name: "fk_sampanalservstepworkposbridges_sampanalservsteps_prowid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_sampanalservstepworkposbridges_workpositions_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservices_employees_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_employees_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_groundintegralstudyservices_groundintegralstu~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_legalclients_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_naturalclients_groundintegralstudynaturalclie~",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservices_employees_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservsteps_trainingservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservsteps_trainingservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservstepworkposbridges_trainingservsteps_prowid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_trainingservstepworkposbridges_workpositions_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges");

            migrationBuilder.DropTable(
                name: "groundintegralstudyservicedocumentbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "groundintegralstudyserviceemployeebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "groundintstudyservstepworkposbridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "sampleanalysisserviceemployeebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "trainingserviceemployeebridges",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "groundintstudyservsteps",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropTable(
                name: "groundintegralstudyservices",
                schema: "decisoriscamaguey_servicing");

            migrationBuilder.DropIndex(
                name: "ix_trainingservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudyserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_sampleanalysisservices_responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices");

            migrationBuilder.DropPrimaryKey(
                name: "pk_trainingservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservstepworkposbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_trainingservsteps",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservsteps");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sampanalservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservstepworkposbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_sampanalservsteps",
                schema: "decisoriscamaguey_servicing",
                table: "sampanalservsteps");

            migrationBuilder.DropColumn(
                name: "responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservices");

            migrationBuilder.DropColumn(
                name: "groundintegralstudylegalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudynaturalclientid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudyserviceid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "responsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices");

            migrationBuilder.RenameTable(
                name: "trainingservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                newName: "trainingservicestepworkpositionbridges",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameTable(
                name: "trainingservsteps",
                schema: "decisoriscamaguey_servicing",
                newName: "trainingservicesteps",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameTable(
                name: "sampanalservstepworkposbridges",
                schema: "decisoriscamaguey_servicing",
                newName: "sampleanalysisservicestepworkpositionbridges",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameTable(
                name: "sampanalservsteps",
                schema: "decisoriscamaguey_servicing",
                newName: "sampleanalysisservicesteps",
                newSchema: "decisoriscamaguey_servicing");

            migrationBuilder.RenameIndex(
                name: "ix_trainingservstepworkposbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges",
                newName: "ix_trainingservicestepworkpositionbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_trainingservsteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                newName: "ix_trainingservicesteps_serviceid");

            migrationBuilder.RenameIndex(
                name: "ix_trainingservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                newName: "ix_trainingservicesteps_parentid");

            migrationBuilder.RenameIndex(
                name: "ix_sampanalservstepworkposbridges_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges",
                newName: "ix_sampleanalysisservicestepworkpositionbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_sampanalservsteps_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                newName: "ix_sampleanalysisservicesteps_serviceid");

            migrationBuilder.RenameIndex(
                name: "ix_sampanalservsteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                newName: "ix_sampleanalysisservicesteps_parentid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_trainingservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_trainingservicesteps",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_sampleanalysisservicestepworkpositionbridges",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_sampleanalysisservicesteps",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                column: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicesteps_sampleanalysisservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                column: "serviceid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampleanalysisservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicesteps_sampleanalysisservicesteps_paren~",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicesteps",
                column: "parentid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampleanalysisservicesteps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicestepworkpositionbridges_sampleanalysis~",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges",
                column: "prowid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "sampleanalysisservicesteps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservicestepworkpositionbridges_workpositions_~",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservicestepworkpositionbridges",
                column: "sternid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservicesteps_trainingservices_serviceid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                column: "serviceid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "trainingservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservicesteps_trainingservicesteps_parentid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicesteps",
                column: "parentid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "trainingservicesteps",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservicestepworkpositionbridges_trainingservicesteps~",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges",
                column: "prowid",
                principalSchema: "decisoriscamaguey_servicing",
                principalTable: "trainingservicesteps",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_trainingservicestepworkpositionbridges_workpositions_sternid",
                schema: "decisoriscamaguey_servicing",
                table: "trainingservicestepworkpositionbridges",
                column: "sternid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "workpositions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
