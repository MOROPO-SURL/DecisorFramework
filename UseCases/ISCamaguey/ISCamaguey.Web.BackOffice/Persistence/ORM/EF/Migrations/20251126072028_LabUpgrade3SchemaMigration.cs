using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LabUpgrade3SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_samples_images_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.AlterColumn<Guid>(
                name: "featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddForeignKey(
                name: "fk_samples_images_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "featureimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_samples_images_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.AlterColumn<Guid>(
                name: "featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_samples_images_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "featureimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
