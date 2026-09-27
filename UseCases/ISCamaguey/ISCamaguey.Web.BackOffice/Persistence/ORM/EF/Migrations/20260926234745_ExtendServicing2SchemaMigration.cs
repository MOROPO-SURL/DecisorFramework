using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExtendServicing2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "assessmentat",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                newName: "executedat");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "executedat",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                newName: "assessmentat");
        }
    }
}
