using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HHRRExtend1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_agreements_agreementid",
                table: "resolutions",
                column: "agreementid",
                principalSchema: "decisorframework_governance",
                principalTable: "agreements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
