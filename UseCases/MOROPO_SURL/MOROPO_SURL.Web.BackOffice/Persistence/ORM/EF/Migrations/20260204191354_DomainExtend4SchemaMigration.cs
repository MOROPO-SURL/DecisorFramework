using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class DomainExtend4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "authorid",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "kind",
                schema: "decisorframework_domain",
                table: "changenotifications",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "ix_changenotifications_authorid",
                schema: "decisorframework_domain",
                table: "changenotifications",
                column: "authorid");

            migrationBuilder.AddForeignKey(
                name: "fk_changenotifications_users_authorid",
                schema: "decisorframework_domain",
                table: "changenotifications",
                column: "authorid",
                principalSchema: "guamaframework_security_personal",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_changenotifications_users_authorid",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.DropIndex(
                name: "ix_changenotifications_authorid",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.DropColumn(
                name: "authorid",
                schema: "decisorframework_domain",
                table: "changenotifications");

            migrationBuilder.DropColumn(
                name: "kind",
                schema: "decisorframework_domain",
                table: "changenotifications");
        }
    }
}
