using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class RelationshipAndContactRemapSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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
                name: "fk_naturalclients_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropIndex(
                name: "ix_naturalclients_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

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
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

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
                name: "taxidentificationnumber",
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

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "stateidentificationcode",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalclientdocumentbridge_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientdocumentbridge_naturalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderdocumentbridge",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderdocumentbridge_documents_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderdocumentbridge_naturalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "mainpostalcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "representativeid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderdocumentbridge_sternid",
                schema: "decisorframework_commercial",
                table: "naturalproviderdocumentbridge",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationcontacts_personcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "representativeid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_organizationcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "mainpostalcontactid",
                principalSchema: "guamaframework_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "mainpostalcontactid",
                principalSchema: "guamaframework_identity",
                principalTable: "postalcontactitems",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_organizationcontacts_personcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_organizationcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_postalcontactitems_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropTable(
                name: "naturalclientdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderdocumentbridge",
                schema: "decisorframework_commercial");

            migrationBuilder.DropIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_personcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_organizationcontacts_mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropIndex(
                name: "ix_organizationcontacts_representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropColumn(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropColumn(
                name: "mainpostalcontactid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "representativeid",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "stateidentificationcode",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_domain",
                table: "organizationcontacts");

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                type: "uuid",
                nullable: true);

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

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                type: "text",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_commercial",
                table: "legalclients",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclients_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "businesskindid");

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
                name: "fk_naturalclients_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");
        }
    }
}
