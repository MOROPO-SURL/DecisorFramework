using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade11SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_legalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_naturalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_legalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "clientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_naturalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "clientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleasorgpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleaspersonpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleasorgpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleaspersonpostulations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_legalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_naturalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_legalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "clientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "legalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_naturalclients_clientid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "clientid",
                principalSchema: "decisorframework_commercial",
                principalTable: "naturalclients",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleasorgpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "postulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleaspersonpostulations",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

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
        }
    }
}
