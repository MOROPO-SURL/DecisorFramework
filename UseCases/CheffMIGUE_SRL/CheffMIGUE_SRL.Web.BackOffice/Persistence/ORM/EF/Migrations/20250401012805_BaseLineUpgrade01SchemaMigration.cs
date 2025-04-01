using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.CheffMIGUE.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class BaseLineUpgrade01SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain");

            migrationBuilder.AddColumn<Guid>(
                name: "mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "representativeid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "stateidentificationcode",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "representativeid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "stateidentificationcode",
                schema: "decisorframework_commercial",
                table: "legalclients",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "brands",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_brands", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalclientdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientdocumentbridges_legalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderdocumentbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderdocumentbridges_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderdocumentbridges_legalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_legalproviders_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviders_representativeid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "representativeid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclients_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclients_representativeid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "representativeid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientdocumentbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderdocumentbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalproviderdocumentbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_legalclients_personcontacts_representativeid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "representativeid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalclients_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "mainpostalcontactid",
                principalSchema: "guamaframework_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviders_personcontacts_representativeid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "representativeid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviders_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "mainpostalcontactid",
                principalSchema: "guamaframework_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_brands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid",
                principalSchema: "decisorframework_domain",
                principalTable: "brands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalclients_personcontacts_representativeid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_legalclients_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviders_personcontacts_representativeid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviders_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicles_brands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles");

            migrationBuilder.DropTable(
                name: "brands",
                schema: "decisorframework_domain");

            migrationBuilder.DropTable(
                name: "legalclientdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderdocumentbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropIndex(
                name: "ix_legalproviders_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropIndex(
                name: "ix_legalproviders_representativeid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropIndex(
                name: "ix_legalclients_mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropIndex(
                name: "ix_legalclients_representativeid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropColumn(
                name: "mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropColumn(
                name: "representativeid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropColumn(
                name: "stateidentificationcode",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropColumn(
                name: "mainpostalcontactid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropColumn(
                name: "representativeid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropColumn(
                name: "stateidentificationcode",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.CreateTable(
                name: "vehiclebrands",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehiclebrands", x => x.id);
                });

            migrationBuilder.AddForeignKey(
                name: "fk_vehicles_vehiclebrands_brandid",
                schema: "decisorframework_domain",
                table: "vehicles",
                column: "brandid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehiclebrands",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
