using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.ISCamaguey.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class ServicingUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_employees_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropForeignKey(
                name: "fk_serviceorders_employees_trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropIndex(
                name: "ix_serviceorders_trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");

            migrationBuilder.DropColumn(
                name: "trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyresponsibleid");

            migrationBuilder.CreateIndex(
                name: "ix_serviceorders_trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingresponsibleid");

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_employees_groundintegralstudyresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "groundintegralstudyresponsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_serviceorders_employees_trainingresponsibleid",
                schema: "decisoriscamaguey_servicing",
                table: "serviceorders",
                column: "trainingresponsibleid",
                principalSchema: "decisorframework_domain",
                principalTable: "employees",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
