using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ContactChangesSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_abstractbudget_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_centralstatestructures_centralstatestructureid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_legalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_organizationidentities_identityid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_contacts_personidentities_identityid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_employees_contacts_contactid",
                schema: "decisorframework_humanresources",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "fk_legalclients_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviders_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclients_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_productvaluepropositions_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions");

            migrationBuilder.DropForeignKey(
                name: "fk_servicevaluepropositions_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions");

            migrationBuilder.DropIndex(
                name: "ix_servicevaluepropositions_contactid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions");

            migrationBuilder.DropIndex(
                name: "ix_productvaluepropositions_contactid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions");

            migrationBuilder.DropPrimaryKey(
                name: "pk_contacts",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropIndex(
                name: "ix_contacts_centralstatestructureid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "centralstatestructureid",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "discriminator",
                schema: "decisorframework_domain",
                table: "contacts");

            migrationBuilder.RenameTable(
                name: "contacts",
                schema: "decisorframework_domain",
                newName: "personcontacts",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameIndex(
                name: "ix_contacts_identityid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                newName: "ix_personcontacts_identityid");

            migrationBuilder.RenameIndex(
                name: "ix_contacts_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                newName: "ix_personcontacts_businesskindid");

            migrationBuilder.AlterColumn<Guid>(
                name: "identityid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "pk_personcontacts",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "id");

            migrationBuilder.CreateTable(
                name: "organizationcontacts",
                schema: "decisorframework_domain",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    identityid = table.Column<Guid>(type: "uuid", nullable: false),
                    businesskindid = table.Column<Guid>(type: "uuid", nullable: false),
                    centralstatestructureid = table.Column<Guid>(type: "uuid", nullable: true),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_organizationcontacts", x => x.id);
                    table.ForeignKey(
                        name: "fk_organizationcontacts_centralstatestructures_centralstatestr~",
                        column: x => x.centralstatestructureid,
                        principalSchema: "decisorframework_legal",
                        principalTable: "centralstatestructures",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "fk_organizationcontacts_legalbusinesskinds_businesskindid",
                        column: x => x.businesskindid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "legalbusinesskinds",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_organizationcontacts_organizationidentities_identityid",
                        column: x => x.identityid,
                        principalSchema: "guamaframework_identity",
                        principalTable: "organizationidentities",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_centralstatestructureid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "centralstatestructureid");

            migrationBuilder.CreateIndex(
                name: "ix_organizationcontacts_identityid",
                schema: "decisorframework_domain",
                table: "organizationcontacts",
                column: "identityid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_abstractbudget_organizationcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_abstractbudget_personcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_employees_personcontacts_contactid",
                schema: "decisorframework_humanresources",
                table: "employees",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_legalclients_organizationcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviders_organizationcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "organizationcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclients_personcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviders_personcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
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

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_personidentities_identityid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "identityid",
                principalSchema: "guamaframework_identity",
                principalTable: "personidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_abstractbudget_organizationcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget");

            migrationBuilder.DropForeignKey(
                name: "fk_abstractbudget_personcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget");

            migrationBuilder.DropForeignKey(
                name: "fk_employees_personcontacts_contactid",
                schema: "decisorframework_humanresources",
                table: "employees");

            migrationBuilder.DropForeignKey(
                name: "fk_legalclients_organizationcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviders_organizationcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclients_personcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalclients");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviders_personcontacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalproviders");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_personidentities_identityid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropTable(
                name: "organizationcontacts",
                schema: "decisorframework_domain");

            migrationBuilder.DropPrimaryKey(
                name: "pk_personcontacts",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.RenameTable(
                name: "personcontacts",
                schema: "decisorframework_domain",
                newName: "contacts",
                newSchema: "decisorframework_domain");

            migrationBuilder.RenameIndex(
                name: "ix_personcontacts_identityid",
                schema: "decisorframework_domain",
                table: "contacts",
                newName: "ix_contacts_identityid");

            migrationBuilder.RenameIndex(
                name: "ix_personcontacts_businesskindid",
                schema: "decisorframework_domain",
                table: "contacts",
                newName: "ix_contacts_businesskindid");

            migrationBuilder.AlterColumn<Guid>(
                name: "identityid",
                schema: "decisorframework_domain",
                table: "contacts",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "centralstatestructureid",
                schema: "decisorframework_domain",
                table: "contacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "discriminator",
                schema: "decisorframework_domain",
                table: "contacts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "pk_contacts",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "id");

            migrationBuilder.CreateIndex(
                name: "ix_servicevaluepropositions_contactid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_productvaluepropositions_contactid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions",
                column: "contactid");

            migrationBuilder.CreateIndex(
                name: "ix_contacts_centralstatestructureid",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "centralstatestructureid");

            migrationBuilder.AddForeignKey(
                name: "fk_abstractbudget_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "abstractbudget",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_centralstatestructures_centralstatestructureid",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "centralstatestructureid",
                principalSchema: "decisorframework_legal",
                principalTable: "centralstatestructures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_legalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "legalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_naturalbusinesskinds_businesskindid",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_organizationidentities_identityid",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "identityid",
                principalSchema: "guamaframework_identity",
                principalTable: "organizationidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_personidentities_identityid",
                schema: "decisorframework_domain",
                table: "contacts",
                column: "identityid",
                principalSchema: "guamaframework_identity",
                principalTable: "personidentities",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_employees_contacts_contactid",
                schema: "decisorframework_humanresources",
                table: "employees",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "fk_legalclients_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalclients",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviders_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "legalproviders",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclients_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalclients",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviders_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "naturalproviders",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_productvaluepropositions_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "productvaluepropositions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_servicevaluepropositions_contacts_contactid",
                schema: "decisorframework_commercial",
                table: "servicevaluepropositions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "contacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
