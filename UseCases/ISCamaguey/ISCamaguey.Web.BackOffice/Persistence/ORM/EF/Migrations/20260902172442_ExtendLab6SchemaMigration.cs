using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendLab6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropColumn(
                name: "enabled",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.CreateIndex(
                name: "ix_analysises_sampleid_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                columns: new[] { "sampleid", "predecessorid" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_analysises_sampleid_predecessorid",
                schema: "decisoriscamaguey_lab",
                table: "analysises");

            migrationBuilder.AddColumn<bool>(
                name: "enabled",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                type: "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_analysises_sampleid",
                schema: "decisoriscamaguey_lab",
                table: "analysises",
                column: "sampleid");
        }
    }
}
