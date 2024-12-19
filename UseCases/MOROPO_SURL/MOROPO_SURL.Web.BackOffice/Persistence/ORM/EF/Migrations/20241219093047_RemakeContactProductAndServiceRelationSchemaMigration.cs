using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class RemakeContactProductAndServiceRelationSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contacts_legalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "contactproductbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "contactservicebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.CreateTable(
                name: "productvaluepropositions",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    productid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    evaluation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvaluepropositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_productvaluepropositions_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productvaluepropositions_products_productid",
                        column: x => x.productid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicevaluepropositions",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    contactid = table.Column<Guid>(type: "uuid", nullable: false),
                    serviceid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    evaluation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicevaluepropositions", x => x.id);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositions_contacts_contactid",
                        column: x => x.contactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositions_requestableservices_serviceid",
                        column: x => x.serviceid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productvaluepropositionimagebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvaluepropositionimagebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_productvaluepropositionimagebridges_images_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_productvaluepropositionimagebridges_productvalueproposition~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "productvaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "productvaluepropositionrates",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    regularcost = table.Column<double>(type: "double precision", nullable: false),
                    minimumcost = table.Column<double>(type: "double precision", nullable: true),
                    maximumcost = table.Column<double>(type: "double precision", nullable: true),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_productvaluepropositionrates", x => x.id);
                    table.ForeignKey(
                        name: "fk_productvaluepropositionrates_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_productvaluepropositionrates_productvaluepropositions_propo~",
                        column: x => x.propositionid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "productvaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicevaluepropositionimagebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicevaluepropositionimagebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionimagebridges_images_sternid",
                        column: x => x.sternid,
                        principalSchema: "guamaframework_media",
                        principalTable: "images",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionimagebridges_servicevalueproposition~",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "servicevaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "servicevaluepropositionrates",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propositionid = table.Column<Guid>(type: "uuid", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    regularcost = table.Column<double>(type: "double precision", nullable: false),
                    minimumcost = table.Column<double>(type: "double precision", nullable: true),
                    maximumcost = table.Column<double>(type: "double precision", nullable: true),
                    currencyid = table.Column<Guid>(type: "uuid", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_servicevaluepropositionrates", x => x.id);
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionrates_currencies_currencyid",
                        column: x => x.currencyid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "currencies",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_servicevaluepropositionrates_servicevaluepropositions_propo~",
                        column: x => x.propositionid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "servicevaluepropositions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositionimagebridges_sternid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositionimagebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositionrates_currencyid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositionrates",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositionrates_propositionid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositionrates",
                column: "propositionid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositions_contactid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositions_productid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions",
                column: "productid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositionimagebridges_sternid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositionimagebridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositionrates_currencyid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositionrates",
                column: "currencyid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositionrates_propositionid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositionrates",
                column: "propositionid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositions_contactid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositions_serviceid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions",
                column: "serviceid");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_legalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "businesskindid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "businesskindid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contacts_legalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.DropTable(
                name: "productvaluepropositionimagebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "productvaluepropositionrates",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "servicevaluepropositionimagebridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "servicevaluepropositionrates",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "productvaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "servicevaluepropositions",
                schema: "decisorframework_commercial");

            migrationBuilder.CreateTable(
                name: "contactproductbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    abstractcontactid = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    evaluation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contactproductbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_contactproductbridges_contacts_abstractcontactid",
                        column: x => x.abstractcontactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_contactproductbridges_contacts_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contactproductbridges_products_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_inventory",
                        principalTable: "products",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "contactservicebridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false),
                    abstractcontactid = table.Column<Guid>(type: "uuid", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true),
                    evaluation = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_contactservicebridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_contactservicebridges_contacts_abstractcontactid",
                        column: x => x.abstractcontactid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_contactservicebridges_contacts_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "contacts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_contactservicebridges_requestableservices_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "requestableservices",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_contactproductbridges_abstractcontactid",
                schema: "decisorframework_commercial",
                table: "contactproductbridges",
                column: "abstractcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_contactproductbridges_sternid",
                schema: "decisorframework_commercial",
                table: "contactproductbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_contactservicebridges_abstractcontactid",
                schema: "decisorframework_commercial",
                table: "contactservicebridges",
                column: "abstractcontactid");

            migrationBuilder.CreateIndex(
                name: "ix_contactservicebridges_sternid",
                schema: "decisorframework_commercial",
                table: "contactservicebridges",
                column: "sternid");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_legalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "businesskindid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "businesskindid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
