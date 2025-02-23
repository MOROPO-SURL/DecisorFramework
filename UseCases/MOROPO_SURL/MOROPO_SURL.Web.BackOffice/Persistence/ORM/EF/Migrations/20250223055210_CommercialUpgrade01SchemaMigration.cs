using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class CommercialUpgrade01SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_employmentcontracts_proformas_proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderpurchasingcontracts_proformas_proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderpurchasingcontracts_proformas_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviderpurchasingcontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropIndex(
                name: "ix_legalproviderpurchasingcontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropIndex(
                name: "ix_employmentcontracts_proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropColumn(
                name: "proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts");

            migrationBuilder.DropColumn(
                name: "proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts");

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

            migrationBuilder.CreateTable(
                name: "legalclientbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalclientbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalclientbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalclientbankaccountbridges_legalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "legalproviderbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_legalproviderbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_legalproviderbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_legalproviderbankaccountbridges_legalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "legalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalclientbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalclientbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalclientbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalclientbankaccountbridges_naturalclients_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalclients",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "naturalproviderbankaccountbridges",
                schema: "decisorframework_commercial",
                columns: table => new
                {
                    prowid = table.Column<Guid>(type: "uuid", nullable: false),
                    sternid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_naturalproviderbankaccountbridges", x => new { x.prowid, x.sternid });
                    table.ForeignKey(
                        name: "fk_naturalproviderbankaccountbridges_bankaccounts_sternid",
                        column: x => x.sternid,
                        principalSchema: "decisorframework_finantial",
                        principalTable: "bankaccounts",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_naturalproviderbankaccountbridges_naturalproviders_prowid",
                        column: x => x.prowid,
                        principalSchema: "decisorframework_commercial",
                        principalTable: "naturalproviders",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                name: "ix_legalclientbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalclientbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "legalproviderbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalclientbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "naturalclientbankaccountbridges",
                column: "sternid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbankaccountbridges_sternid",
                schema: "decisorframework_commercial",
                table: "naturalproviderbankaccountbridges",
                column: "sternid");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_naturalclients_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropTable(
                name: "legalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "legalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalclientbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropTable(
                name: "naturalproviderbankaccountbridges",
                schema: "decisorframework_commercial");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviders_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropIndex(
                name: "ix_naturalclients_businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderpurchasingcontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderpurchasingcontracts_proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                column: "proformaid");

            migrationBuilder.CreateIndex(
                name: "ix_employmentcontracts_proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "proformaid");

            migrationBuilder.AddForeignKey(
                name: "fk_employmentcontracts_proformas_proformaid",
                schema: "decisorframework_humanresources",
                table: "employmentcontracts",
                column: "proformaid",
                principalSchema: "decisorframework_legal",
                principalTable: "proformas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderpurchasingcontracts_proformas_proformaid",
                schema: "decisorframework_commercial",
                table: "legalproviderpurchasingcontracts",
                column: "proformaid",
                principalSchema: "decisorframework_legal",
                principalTable: "proformas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderpurchasingcontracts_proformas_proformaid",
                schema: "decisorframework_commercial",
                table: "naturalproviderpurchasingcontracts",
                column: "proformaid",
                principalSchema: "decisorframework_legal",
                principalTable: "proformas",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");
        }
    }
}
