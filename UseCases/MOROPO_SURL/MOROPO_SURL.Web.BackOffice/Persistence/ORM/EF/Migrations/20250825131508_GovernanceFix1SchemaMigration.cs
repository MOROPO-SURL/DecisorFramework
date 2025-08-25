using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class GovernanceFix1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_meetings_employees_authorid",
                schema: "decisorframework_governance",
                table: "meetings");

            migrationBuilder.AddForeignKey(
                name: "fk_meetings_personcontacts_authorid",
                schema: "decisorframework_governance",
                table: "meetings",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_meetings_personcontacts_authorid",
                schema: "decisorframework_governance",
                table: "meetings");

            migrationBuilder.AddForeignKey(
                name: "fk_meetings_employees_authorid",
                schema: "decisorframework_governance",
                table: "meetings",
                column: "authorid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
