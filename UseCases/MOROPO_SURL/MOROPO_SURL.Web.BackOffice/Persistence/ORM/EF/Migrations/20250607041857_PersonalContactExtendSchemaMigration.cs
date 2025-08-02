using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PersonalContactExtendSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "userid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                type: "text",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_personcontacts_userid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "userid",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_personcontacts_users_userid",
                schema: "decisorframework_domain",
                table: "personcontacts",
                column: "userid",
                principalSchema: "guamaframework_security_personal",
                principalTable: "users",
                principalColumn: "id",
                onDelete: ReferentialAction.SetNull);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_personcontacts_users_userid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropIndex(
                name: "ix_personcontacts_userid",
                schema: "decisorframework_domain",
                table: "personcontacts");

            migrationBuilder.DropColumn(
                name: "userid",
                schema: "decisorframework_domain",
                table: "personcontacts");
        }
    }
}
