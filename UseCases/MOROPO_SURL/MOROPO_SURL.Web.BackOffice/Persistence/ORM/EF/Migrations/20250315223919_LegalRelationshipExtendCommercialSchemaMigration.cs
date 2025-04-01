using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LegalRelationshipExtendCommercialSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
