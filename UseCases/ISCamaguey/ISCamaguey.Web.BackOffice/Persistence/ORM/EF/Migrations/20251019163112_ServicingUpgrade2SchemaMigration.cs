using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_sampleanalysisservices_samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                column: "samplekindid");

            migrationBuilder.AddForeignKey(
                name: "fk_sampleanalysisservices_samplekinds_samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices",
                column: "samplekindid",
                principalSchema: "decisoriscamaguey_domain",
                principalTable: "samplekinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_sampleanalysisservices_samplekinds_samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices");

            migrationBuilder.DropIndex(
                name: "ix_sampleanalysisservices_samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices");

            migrationBuilder.DropColumn(
                name: "samplekindid",
                schema: "decisoriscamaguey_servicing",
                table: "sampleanalysisservices");
        }
    }
}
