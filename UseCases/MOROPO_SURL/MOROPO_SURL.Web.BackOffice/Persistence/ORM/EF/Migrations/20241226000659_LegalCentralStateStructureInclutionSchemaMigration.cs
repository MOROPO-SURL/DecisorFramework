using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LegalCentralStateStructureInclutionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_structures_properties_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures");

            migrationBuilder.AlterColumn<Guid>(
                name: "socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "centralstatestructureid",
                schema: "decisorframework_commercial",
                table: "contacts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_contacts_centralstatestructureid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "centralstatestructureid");

            migrationBuilder.AddForeignKey(
                name: "fk_contacts_centralstatestructures_centralstatestructureid",
                schema: "decisorframework_commercial",
                table: "contacts",
                column: "centralstatestructureid",
                principalSchema: "decisorframework_legal",
                principalTable: "centralstatestructures",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_structures_properties_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "socialpropertyid",
                principalSchema: "decisorframework_domain",
                principalTable: "properties",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_contacts_centralstatestructures_centralstatestructureid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.DropForeignKey(
                name: "fk_structures_properties_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures");

            migrationBuilder.DropIndex(
                name: "ix_contacts_centralstatestructureid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.DropColumn(
                name: "centralstatestructureid",
                schema: "decisorframework_commercial",
                table: "contacts");

            migrationBuilder.AlterColumn<Guid>(
                name: "socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_structures_properties_socialpropertyid",
                schema: "decisorframework_domain",
                table: "structures",
                column: "socialpropertyid",
                principalSchema: "decisorframework_domain",
                principalTable: "properties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
