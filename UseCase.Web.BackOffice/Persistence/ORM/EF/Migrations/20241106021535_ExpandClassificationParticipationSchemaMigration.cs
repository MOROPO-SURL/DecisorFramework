using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Framework.Decisor.UseCase.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ExpandClassificationParticipationSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "classificationid",
                schema: "decisorframework_inventory",
                table: "batches",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_batches_classificationid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "classificationid");

            migrationBuilder.AddForeignKey(
                name: "fk_batches_classifications_classificationid",
                schema: "decisorframework_inventory",
                table: "batches",
                column: "classificationid",
                principalSchema: "decisorframework_inventory",
                principalTable: "classifications",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_batches_classifications_classificationid",
                schema: "decisorframework_inventory",
                table: "batches");

            migrationBuilder.DropIndex(
                name: "ix_batches_classificationid",
                schema: "decisorframework_inventory",
                table: "batches");

            migrationBuilder.DropColumn(
                name: "classificationid",
                schema: "decisorframework_inventory",
                table: "batches");
        }
    }
}
