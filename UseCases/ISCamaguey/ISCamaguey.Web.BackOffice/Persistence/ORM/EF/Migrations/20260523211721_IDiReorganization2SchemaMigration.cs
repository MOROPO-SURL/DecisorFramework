using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class IDiReorganization2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "projectexternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "projectinternalresearcherbridges",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.CreateTable(
                name: "externalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcherid = table.Column<Guid>(type: "uuid", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_externalresearcherprojectparticipations", x => x.id);
                    table.ForeignKey(
                        name: "fk_externalresearcherprojectparticipations_externalresearchers~",
                        column: x => x.researcherid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_externalresearcherprojectparticipations_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "internalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    researcherid = table.Column<Guid>(type: "uuid", nullable: false),
                    projectid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false),
                    startat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    endat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_internalresearcherprojectparticipations", x => x.id);
                    table.ForeignKey(
                        name: "fk_internalresearcherprojectparticipations_internalresearchers~",
                        column: x => x.researcherid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_internalresearcherprojectparticipations_projects_projectid",
                        column: x => x.projectid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_externalresearcherprojectparticipations_projectid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearcherprojectparticipations",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_externalresearcherprojectparticipations_researcherid",
                schema: "decisoriscamaguey_idi",
                table: "externalresearcherprojectparticipations",
                column: "researcherid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearcherprojectparticipations_projectid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearcherprojectparticipations",
                column: "projectid");

            migrationBuilder.CreateIndex(
                name: "ix_internalresearcherprojectparticipations_researcherid",
                schema: "decisoriscamaguey_idi",
                table: "internalresearcherprojectparticipations",
                column: "researcherid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "externalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.DropTable(
                name: "internalresearcherprojectparticipations",
                schema: "decisoriscamaguey_idi");

            migrationBuilder.CreateTable(
                name: "projectexternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectexternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectexternalresearcherbridges_externalresearchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "externalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectexternalresearcherbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "projectinternalresearcherbridges",
                schema: "decisoriscamaguey_idi",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    timeavailability = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_projectinternalresearcherbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_projectinternalresearcherbridges_internalresearchers_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "internalresearchers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_projectinternalresearcherbridges_projects_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisoriscamaguey_idi",
                        principalTable: "projects",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_projectexternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectexternalresearcherbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_projectinternalresearcherbridges_sternid",
                schema: "decisoriscamaguey_idi",
                table: "projectinternalresearcherbridges",
                column: "sternid");
        }
    }
}
