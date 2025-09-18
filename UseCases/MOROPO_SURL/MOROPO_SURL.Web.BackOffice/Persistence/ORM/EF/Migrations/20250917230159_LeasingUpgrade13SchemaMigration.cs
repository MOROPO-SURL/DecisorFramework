using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade13SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.RenameColumn(
                name: "postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "vehicleleasenaturalpostulationid");

            migrationBuilder.RenameIndex(
                name: "ix_leasecontracts_postulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "ix_leasecontracts_vehicleleasenaturalpostulationid");

            migrationBuilder.AddColumn<Guid>(
                name: "propertyleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "propertyleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "vehicleleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalpostulationid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_propertyleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalpostulationid");

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_vehicleleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalpostulationid");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_propertyleaselegalpo~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleaselegalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleasorgpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_propertyleasenatu~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "propertyleasenaturalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "propleaspersonpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_vehicleleaselegalpost~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleaselegalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleasorgpostulations",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_vehicleleasenatura~",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                column: "vehicleleasenaturalpostulationid",
                principalSchema: "decisorframework_leasing",
                principalTable: "vehleaspersonpostulations",
                principalColumn: "id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_propleasorgpostulations_propertyleaselegalpo~",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_propleaspersonpostulations_propertyleasenatu~",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleasorgpostulations_vehicleleaselegalpost~",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_vehleaspersonpostulations_vehicleleasenatura~",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_propertyleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_propertyleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_vehicleleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "propertyleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "propertyleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "vehicleleaselegalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts");

            migrationBuilder.RenameColumn(
                name: "vehicleleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "postulationid");

            migrationBuilder.RenameIndex(
                name: "ix_leasecontracts_vehicleleasenaturalpostulationid",
                schema: "decisorframework_leasing",
                table: "leasecontracts",
                newName: "ix_leasecontracts_postulationid");

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
    }
}
