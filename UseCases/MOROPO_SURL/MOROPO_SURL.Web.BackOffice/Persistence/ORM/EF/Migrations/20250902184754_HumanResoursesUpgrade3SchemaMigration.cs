using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_resolutions_index_year",
                table: "resolutions");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_index_year",
                table: "resolutions",
                columns: new[] { "index", "year" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "ix_resolutions_index_year",
                table: "resolutions");

            migrationBuilder.CreateIndex(
                name: "ix_resolutions_index_year",
                table: "resolutions",
                columns: new[] { "index", "year" });
        }
    }
}
