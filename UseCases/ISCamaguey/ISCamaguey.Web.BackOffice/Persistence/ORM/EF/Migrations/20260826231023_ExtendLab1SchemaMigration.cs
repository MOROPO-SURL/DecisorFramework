using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_samples_productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "productionid");

            migrationBuilder.AddForeignKey(
                name: "fk_samples_productions_productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "productionid",
                principalSchema: "decisorframework_production",
                principalTable: "productions",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_samples_productions_productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropIndex(
                name: "ix_samples_productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropColumn(
                name: "productionid",
                schema: "decisoriscamaguey_lab",
                table: "samples");
        }
    }
}
