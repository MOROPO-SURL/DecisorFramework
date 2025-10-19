using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingDomainTransitionSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "samplekinds",
                schema: "decisoriscamaguey_lab",
                newName: "samplekinds",
                newSchema: "decisoriscamaguey_domain");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameTable(
                name: "samplekinds",
                schema: "decisoriscamaguey_domain",
                newName: "samplekinds",
                newSchema: "decisoriscamaguey_lab");
        }
    }
}
