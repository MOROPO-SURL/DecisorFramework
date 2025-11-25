using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LabUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_samples_samplekinds_defaultsamplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropColumn(
                name: "reference",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.RenameColumn(
                name: "defaultsamplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                newName: "unitmeasurementid");

            migrationBuilder.RenameIndex(
                name: "ix_samples_defaultsamplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                newName: "ix_samples_unitmeasurementid");

            migrationBuilder.AddColumn<decimal>(
                name: "amount",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "numeric",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<Guid>(
                name: "featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "labelid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "samplereceptionlabels",
                schema: "decisoriscamaguey_lab",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    reference = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_samplereceptionlabels", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_samples_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "featureimageid");

            migrationBuilder.CreateIndex(
                name: "ix_samples_labelid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "labelid",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_samples_samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "samplekindid");

            migrationBuilder.AddForeignKey(
                name: "fk_samples_images_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "featureimageid",
                principalSchema: "guamaframework_media",
                principalTable: "images",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_samples_samplekinds_samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "samplekindid",
                principalSchema: "decisoriscamaguey_domain",
                principalTable: "samplekinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_samples_samplereceptionlabels_labelid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "labelid",
                principalSchema: "decisoriscamaguey_lab",
                principalTable: "samplereceptionlabels",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_samples_unitmeasurements_unitmeasurementid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "unitmeasurementid",
                principalSchema: "decisorframework_domain",
                principalTable: "unitmeasurements",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_samples_images_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropForeignKey(
                name: "fk_samples_samplekinds_samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropForeignKey(
                name: "fk_samples_samplereceptionlabels_labelid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropForeignKey(
                name: "fk_samples_unitmeasurements_unitmeasurementid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropTable(
                name: "samplereceptionlabels",
                schema: "decisoriscamaguey_lab");

            migrationBuilder.DropIndex(
                name: "ix_samples_featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropIndex(
                name: "ix_samples_labelid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropIndex(
                name: "ix_samples_samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropColumn(
                name: "amount",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropColumn(
                name: "featureimageid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropColumn(
                name: "labelid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.DropColumn(
                name: "samplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples");

            migrationBuilder.RenameColumn(
                name: "unitmeasurementid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                newName: "defaultsamplekindid");

            migrationBuilder.RenameIndex(
                name: "ix_samples_unitmeasurementid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                newName: "ix_samples_defaultsamplekindid");

            migrationBuilder.AddColumn<string>(
                name: "reference",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddForeignKey(
                name: "fk_samples_samplekinds_defaultsamplekindid",
                schema: "decisoriscamaguey_lab",
                table: "samples",
                column: "defaultsamplekindid",
                principalSchema: "decisoriscamaguey_domain",
                principalTable: "samplekinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
