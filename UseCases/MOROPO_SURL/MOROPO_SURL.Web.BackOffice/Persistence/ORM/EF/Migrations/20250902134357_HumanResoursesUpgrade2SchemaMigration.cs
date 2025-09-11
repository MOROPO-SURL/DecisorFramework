using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class HumanResoursesUpgrade2SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions");

            migrationBuilder.DropForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions");

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_personcontacts_contactid",
                table: "resolutions",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_staffs_staffid",
                table: "resolutions",
                column: "staffid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "staffs",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_resolutions_vacants_vacantid",
                table: "resolutions",
                column: "vacantid",
                principalSchema: "decisorframework_humanresources",
                principalTable: "vacants",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
