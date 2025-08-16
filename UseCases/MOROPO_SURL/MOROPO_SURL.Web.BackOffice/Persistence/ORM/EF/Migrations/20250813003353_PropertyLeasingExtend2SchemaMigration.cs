using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PropertyLeasingExtend2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_naturalbusinesskinds~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_conta~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridge_document~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridge_property~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridge_documents_ster~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridge_propertyleaseo~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_naturalbusinesskinds_~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_contac~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_of~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridge_documents~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridge_vehiclele~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridge_documents_stern~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridge_vehicleleaseoff~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges");

            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "vehicleleasepersonpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseorganizationpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleasepersonpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseorganizationpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "propertyleasepersonpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorganizationpostulationdocumentbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleasepersonpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorganizationpostulations",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulationdocumentbridge_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                newName: "ix_vehicleleasepersonpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulationdocumentbridge_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                newName: "ix_vehicleleaseorganizationpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                newName: "ix_vehicleleasepersonpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                newName: "ix_vehicleleasepersonpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferpersoncontactbridges_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                newName: "ix_vehicleleasepersonpostulations_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                newName: "ix_vehicleleaseorganizationpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseofferorganizationcontactbridges_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                newName: "ix_vehicleleaseorganizationpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulationdocumentbridge_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                newName: "ix_propertyleasepersonpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulationdocumentbridge_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                newName: "ix_propertyleaseorganizationpostulationdocumentbridges_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                newName: "ix_propertyleasepersonpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                newName: "ix_propertyleasepersonpostulations_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferpersoncontactbridges_businesskindid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                newName: "ix_propertyleasepersonpostulations_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                newName: "ix_propertyleaseorganizationpostulations_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseofferorganizationcontactbridges_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                newName: "ix_propertyleaseorganizationpostulations_contactid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "id");

            migrationBuilder.CreateTable(
                name: "propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseorgpostulationspacepropousalbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertyle~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleaseorganizationpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseorgpostulationspacepropousalbridges_propertysp~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyspaceleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleaseperspostulationspacepropousalbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_propertyleaseperspostulationspacepropousalbridges_propertyl~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyleasepersonpostulations",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleaseperspostulationspacepropousalbridges_propertys~",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_leasing",
                        principalTable: "propertyspaceleasepropousals",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseorgpostulationspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorgpostulationspacepropousalbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleaseperspostulationspacepropousalbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseperspostulationspacepropousalbridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_documen~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_propert~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseorganizationpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulations_organizationcontacts_~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulations_propertyleaseoffers_o~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_documents_ste~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_propertylease~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleasepersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulations_naturalbusinesskinds_busine~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_document~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_vehiclel~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseorganizationpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_organizationcontacts_c~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_vehicleleaseoffers_off~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_documents_ster~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_vehicleleasepe~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleasepersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulations_naturalbusinesskinds_busines~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_documen~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridges_propert~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulations_organizationcontacts_~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseorganizationpostulations_propertyleaseoffers_o~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_documents_ste~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridges_propertylease~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulations_naturalbusinesskinds_busine~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propertyleasepersonpostulations_propertyleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_document~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridges_vehiclel~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_organizationcontacts_c~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseorganizationpostulations_vehicleleaseoffers_off~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_documents_ster~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridges_vehicleleasepe~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulations_naturalbusinesskinds_busines~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulations_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleasepersonpostulations_vehicleleaseoffers_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropTable(
                name: "propertyleaseorgpostulationspacepropousalbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "propertyleaseperspostulationspacepropousalbridges",
                schema: "decisorframework_leasing");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulations");

            migrationBuilder.DropPrimaryKey(
                name: "pk_propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridges");

            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulations",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseofferpersoncontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleasepersonpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseofferorganizationcontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "vehicleleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "vehicleleaseorganizationpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleasepersonpostulations",
                schema: "decisorframework_leasing",
                newName: "propertyleaseofferpersoncontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleasepersonpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleasepersonpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulations",
                schema: "decisorframework_leasing",
                newName: "propertyleaseofferorganizationcontactbridges",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameTable(
                name: "propertyleaseorganizationpostulationdocumentbridges",
                schema: "decisorframework_leasing",
                newName: "propertyleaseorganizationpostulationdocumentbridge",
                newSchema: "decisorframework_leasing");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "ix_vehicleleaseofferpersoncontactbridges_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "ix_vehicleleaseofferpersoncontactbridges_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                newName: "ix_vehicleleaseofferpersoncontactbridges_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleasepersonpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge",
                newName: "ix_vehicleleasepersonpostulationdocumentbridge_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "ix_vehicleleaseofferorganizationcontactbridges_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges",
                newName: "ix_vehicleleaseofferorganizationcontactbridges_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseorganizationpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge",
                newName: "ix_vehicleleaseorganizationpostulationdocumentbridge_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "ix_propertyleaseofferpersoncontactbridges_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "ix_propertyleaseofferpersoncontactbridges_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                newName: "ix_propertyleaseofferpersoncontactbridges_businesskindid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleasepersonpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge",
                newName: "ix_propertyleasepersonpostulationdocumentbridge_sternid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulations_offerid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "ix_propertyleaseofferorganizationcontactbridges_offerid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulations_contactid",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges",
                newName: "ix_propertyleaseofferorganizationcontactbridges_contactid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseorganizationpostulationdocumentbridges_sternid",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge",
                newName: "ix_propertyleaseorganizationpostulationdocumentbridge_sternid");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_vehicleleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseofferpersoncontactbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleasepersonpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseofferorganizationcontactbridges",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_propertyleaseorganizationpostulationdocumentbridge",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_organizationco~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferorganizationcontactbridges_propertyleaseo~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferorganizationcontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_naturalbusinesskinds~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_personcontacts_conta~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseofferpersoncontactbridges_propertyleaseoffers_~",
                schema: "decisorframework_leasing",
                table: "propertyleaseofferpersoncontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridge_document~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseorganizationpostulationdocumentbridge_property~",
                schema: "decisorframework_leasing",
                table: "propertyleaseorganizationpostulationdocumentbridge",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseofferorganizationcontactbridges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridge_documents_ster~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleasepersonpostulationdocumentbridge_propertyleaseo~",
                schema: "decisorframework_leasing",
                table: "propertyleasepersonpostulationdocumentbridge",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleaseofferpersoncontactbridges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_organizationcon~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferorganizationcontactbridges_vehicleleaseoff~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferorganizationcontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_naturalbusinesskinds_~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_personcontacts_contac~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseofferpersoncontactbridges_vehicleleaseoffers_of~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseofferpersoncontactbridges",
                column: "offerid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseoffers",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridge_documents~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseorganizationpostulationdocumentbridge_vehiclele~",
                schema: "decisorframework_leasing",
                table: "vehicleleaseorganizationpostulationdocumentbridge",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseofferorganizationcontactbridges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridge_documents_stern~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge",
                column: "sternid",
                principalSchema: "guamaframework_media",
                principalTable: "documents",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleasepersonpostulationdocumentbridge_vehicleleaseoff~",
                schema: "decisorframework_leasing",
                table: "vehicleleasepersonpostulationdocumentbridge",
                column: "prowid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleaseofferpersoncontactbridges",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
