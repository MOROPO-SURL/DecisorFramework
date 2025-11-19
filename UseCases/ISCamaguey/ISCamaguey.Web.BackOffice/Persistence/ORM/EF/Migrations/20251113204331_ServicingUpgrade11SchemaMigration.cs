using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade11SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "feed",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "feed",
                schema: "decisoriscamaguey_servicing",
                table: "servicingcontracts",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
