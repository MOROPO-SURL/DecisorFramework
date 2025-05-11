using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasePostulationConceptTransitionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_documents_cred~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_documents_credential~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_stern~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_documents_crede~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_documents_credentiald~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_pr~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_credentialdocum~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_credentialdocu~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropColumn(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropColumn(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropColumn(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropColumn(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "offerid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "ix_vehicleleaseofferpersoncontactbridges_offerid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "offerid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "ix_vehicleleaseofferorganizationcontactbridges_offerid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "offerid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "ix_propertyleaseofferpersoncontactbridges_offerid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "offerid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "ix_propertyleaseofferorganizationcontactbridges_offerid");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "id");

            migrationBuilder.CreateTable(
                name: "propertyleaseofferclausebridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseofferclausebridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseofferclausebridge_clauses_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseofferclausebridge_propertyleaseoffers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "propertyleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseorganizationpostulationdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseorganizationpostulationdocumentbridge_document~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseorganizationpostulationdocumentbridge_property~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "propertyleaseofferorganizationcontactbridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasepersonpostulationdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulationdocumentbridge_documents_ster~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepersonpostulationdocumentbridge_propertyleaseo~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "propertyleaseofferpersoncontactbridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseofferclausebridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseofferclausebridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferclausebridge_clauses_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "clauses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseofferclausebridge_vehicleleaseoffers_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "vehicleleaseoffers",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleaseorganizationpostulationdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleaseorganizationpostulationdocumentbridge_documents~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleaseorganizationpostulationdocumentbridge_vehiclele~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "vehicleleaseofferorganizationcontactbridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_production",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasepersonpostulationdocumentbridge", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulationdocumentbridge_documents_stern~",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "documents",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepersonpostulationdocumentbridge_vehicleleaseoff~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_production",
                        principalTable: "vehicleleaseofferpersoncontactbridges",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_contactid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_contactid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_contactid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_contactid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferclausebridge_sternid",
                schema: "decisorframework_production",
                table: "propertyleaseofferclausebridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseorganizationpostulationdocumentbridge_sternid",
                schema: "decisorframework_production",
                table: "propertyleaseorganizationpostulationdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepersonpostulationdocumentbridge_sternid",
                schema: "decisorframework_production",
                table: "propertyleasepersonpostulationdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferclausebridge_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferclausebridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseorganizationpostulationdocumentbridge_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseorganizationpostulationdocumentbridge",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepersonpostulationdocumentbridge_sternid",
                schema: "decisorframework_production",
                table: "vehicleleasepersonpostulationdocumentbridge",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_production",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_conta~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_production",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_production",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_contac~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_of~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_production",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_conta~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_contac~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_of~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropTable(
                name: "propertyleaseofferclausebridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseofferclausebridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropTable(
                name: "vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_production");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_contactid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_contactid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_contactid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_contactid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.RenameColumn(
                name: "offerid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "contactid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_offerid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "ix_vehicleleaseofferpersoncontactbridges_sternid");

            migrationBuilder.RenameColumn(
                name: "offerid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "contactid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_offerid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "ix_vehicleleaseofferorganizationcontactbridges_sternid");

            migrationBuilder.RenameColumn(
                name: "offerid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "contactid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_offerid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "ix_propertyleaseofferpersoncontactbridges_sternid");

            migrationBuilder.RenameColumn(
                name: "offerid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "contactid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_offerid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "ix_propertyleaseofferorganizationcontactbridges_sternid");

            migrationBuilder.AddColumn<Guid>(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_credentialdocumentid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_credentialdocum~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_credentialdocumentid",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_credentialdocu~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "credentialdocumentid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_documents_cred~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "credentialdocumentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "sternid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                schema: "decisorframework_production",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "prowid",
                principalSchema: "decisorframework_production",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_documents_credential~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "credentialdocumentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_stern~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "sternid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                schema: "decisorframework_production",
                table: "propertyleaseofferpersoncontactbridges",
                column: "prowid",
                principalSchema: "decisorframework_production",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_documents_crede~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "credentialdocumentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "sternid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "prowid",
                principalSchema: "decisorframework_production",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_documents_credentiald~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "credentialdocumentid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_sternid",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "sternid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_pr~",
                schema: "decisorframework_production",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "prowid",
                principalSchema: "decisorframework_production",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
