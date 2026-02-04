using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "legclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.CreateTable(
                name: "drivelicences",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: true),
                    code = table.Column<string>(type: "text", nullable: true),
                    reference = table.Column<string>(type: "text", nullable: true),
                    releasedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    expireat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivelicences", x => x.id);
                    table.ForeignKey(
                        name: "fk_drivelicences_personcontacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "drivelicencevehiclekindbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    category = table.Column<int>(type: "integer", nullable: false),
                    achievedat = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_drivelicencevehiclekindbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_drivelicencevehiclekindbridges_drivelicences_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_drivelicencevehiclekindbridges_vehiclekinds_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehiclekinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleasdrivlicbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleasdrivlicbridges_drivelicences_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleasdrivlicbridges_legalclientvehicleleasings_p~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleasdrivlicbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleasdrivlicbridges_drivelicences_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "drivelicences",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleasdrivlicbridges_naturalclientvehicleleasings~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_drivelicences_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_drivelicencevehiclekindbridges_sternid",
                schema: "decisorframework_leasing",
                table: "drivelicencevehiclekindbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleasdrivlicbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleasdrivlicbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleasdrivlicbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleasdrivlicbridges",
                column: "sternid");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "drivelicencevehiclekindbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "legclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "natclientvehleasdrivlicbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "drivelicences",
                schema: "decisorframework_leasing");

            migrationBuilder.CreateTable(
                name: "legclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    drivelicenceidentifier = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legclientvehleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legclientvehleaspersoncontactbridges_legalclientvehicleleas~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "legalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legclientvehleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "natclientvehleaspersoncontactbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    drivelicenceidentifier = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_natclientvehleaspersoncontactbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_natclientvehleaspersoncontactbridges_naturalclientvehiclele~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "naturalclientvehicleleasings",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_natclientvehleaspersoncontactbridges_personcontacts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "personcontacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_legclientvehleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "legclientvehleaspersoncontactbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_natclientvehleaspersoncontactbridges_sternid",
                schema: "decisorframework_leasing",
                table: "natclientvehleaspersoncontactbridges",
                column: "sternid");
        }
    }
}
