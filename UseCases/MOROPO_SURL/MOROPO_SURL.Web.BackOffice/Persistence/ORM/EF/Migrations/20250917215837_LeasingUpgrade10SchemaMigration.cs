using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade10SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "ix_naturalclientvehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                column: "contractid");

            migrationBuilder.CreateIndex(
                name: "ix_legalclientvehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "contractid");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleasorgpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleaspersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalclientvehicleleasings_leasecontracts_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings",
                column: "contractid",
                principalSchema: "decisorframework_leasing",
                principalTable: "leasecontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalclientvehicleleasings_leasecontracts_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings",
                column: "contractid",
                principalSchema: "decisorframework_leasing",
                principalTable: "leasecontracts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_legalclientvehicleleasings_leasecontracts_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalclientvehicleleasings_leasecontracts_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings");

            migrationBuilder.DropIndex(
                name: "ix_naturalclientvehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "naturalclientvehicleleasings");

            migrationBuilder.DropIndex(
                name: "ix_legalclientvehicleleasings_contractid",
                schema: "decisorframework_leasing",
                table: "legalclientvehicleleasings");
        }
    }
}
