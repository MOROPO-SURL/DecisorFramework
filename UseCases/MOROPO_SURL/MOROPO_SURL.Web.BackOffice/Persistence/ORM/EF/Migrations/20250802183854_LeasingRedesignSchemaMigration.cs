using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingRedesignSchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_properties_propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_vehicles_vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.RenameColumn(
                name: "vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "postulationid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseoffers_vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "ix_vehicleleaseoffers_postulationid");

            migrationBuilder.RenameColumn(
                name: "propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "postulationid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseoffers_propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "ix_propertyleaseoffers_postulationid");

            migrationBuilder.CreateTable(
                name: "propertyleasepostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    propertyid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_propertyleasepostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_propertyleasepostulations_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepostulations_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_propertyleasepostulations_properties_propertyid",
                        column: x => x.propertyid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "properties",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "vehicleleasepostulations",
                schema: "decisorframework_leasing",
                columns: table => new
                {
                    id = table.Column<Guid>(type: "uuid", nullable: false),
                    vehicleid = table.Column<Guid>(type: "uuid", nullable: false),
                    archived = table.Column<bool>(type: "boolean", nullable: false),
                    enabled = table.Column<bool>(type: "boolean", nullable: false),
                    priority = table.Column<int>(type: "integer", nullable: false),
                    at = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    authorid = table.Column<Guid>(type: "uuid", nullable: false),
                    description = table.Column<string>(type: "text", nullable: true),
                    agreementid = table.Column<Guid>(type: "uuid", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_vehicleleasepostulations", x => x.id);
                    table.ForeignKey(
                        name: "fk_vehicleleasepostulations_agreements_agreementid",
                        column: x => x.agreementid,
                        principalSchema: "decisorframework_governance",
                        principalTable: "agreements",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepostulations_employees_authorid",
                        column: x => x.authorid,
                        principalSchema: "decisorframework_humanresources",
                        principalTable: "employees",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_vehicleleasepostulations_vehicles_vehicleid",
                        column: x => x.vehicleid,
                        principalSchema: "decisorframework_domain",
                        principalTable: "vehicles",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepostulations_agreementid",
                schema: "decisorframework_leasing",
                table: "propertyleasepostulations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepostulations_authorid",
                schema: "decisorframework_leasing",
                table: "propertyleasepostulations",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_propertyleasepostulations_propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleasepostulations",
                column: "propertyid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepostulations_agreementid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepostulations",
                column: "agreementid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepostulations_authorid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepostulations",
                column: "authorid");

            migrationBuilder.CreateIndex(
                name: "ix_vehicleleasepostulations_vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleasepostulations",
                column: "vehicleid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_propertyleasepostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propertyleasepostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_vehicleleasepostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehicleleasepostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propertyleaseoffers_propertyleasepostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers");

            migrationBuilder.DropForeignKey(
                name: "fk_vehicleleaseoffers_vehicleleasepostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers");

            migrationBuilder.DropTable(
                name: "propertyleasepostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.DropTable(
                name: "vehicleleasepostulations",
                schema: "decisorframework_leasing");

            migrationBuilder.RenameColumn(
                name: "postulationid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "vehicleid");

            migrationBuilder.RenameIndex(
                name: "ix_vehicleleaseoffers_postulationid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                newName: "ix_vehicleleaseoffers_vehicleid");

            migrationBuilder.RenameColumn(
                name: "postulationid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "propertyid");

            migrationBuilder.RenameIndex(
                name: "ix_propertyleaseoffers_postulationid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                newName: "ix_propertyleaseoffers_propertyid");

            migrationBuilder.AddForeignKey(
                name: "fk_propertyleaseoffers_properties_propertyid",
                schema: "decisorframework_leasing",
                table: "propertyleaseoffers",
                column: "propertyid",
                principalSchema: "decisorframework_domain",
                principalTable: "properties",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehicleleaseoffers_vehicles_vehicleid",
                schema: "decisorframework_leasing",
                table: "vehicleleaseoffers",
                column: "vehicleid",
                principalSchema: "decisorframework_domain",
                principalTable: "vehicles",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
