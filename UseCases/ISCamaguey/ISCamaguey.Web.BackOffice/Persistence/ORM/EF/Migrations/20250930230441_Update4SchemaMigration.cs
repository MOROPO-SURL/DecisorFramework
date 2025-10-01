using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class Update4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "index",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_programexpectresults_index",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults",
                column: "index",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_programexpectresults_index",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults");

            migrationBuilder.DropColumn(
                name: "index",
                schema: "decisoriscamaguey_idi",
                table: "programexpectresults");
        }
    }
}
