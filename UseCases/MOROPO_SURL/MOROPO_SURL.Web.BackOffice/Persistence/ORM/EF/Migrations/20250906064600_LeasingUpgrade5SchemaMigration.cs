using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade5SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propleaspersonpostulations_naturalbusinesskinds_businesskin~",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostulations_naturalbusinesskinds_businesskind~",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropIndex(
                name: "ix_vehleaspersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropIndex(
                name: "ix_propleaspersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "stateidentificationcode",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropColumn(
                name: "businesskindid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "stateidentificationcode",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");

            migrationBuilder.DropColumn(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "stateidentificationcode",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "businesskindid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "stateidentificationcode",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "taxidentificationnumber",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "ix_vehleaspersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "businesskindid");

            migrationBuilder.CreateIndex(
                name: "ix_propleaspersonpostulations_businesskindid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "businesskindid");

            migrationBuilder.AddForeignKey(
                name: "fk_propleaspersonpostulations_naturalbusinesskinds_businesskin~",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostulations_naturalbusinesskinds_businesskind~",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "businesskindid",
                principalSchema: "decisorframework_domain",
                principalTable: "naturalbusinesskinds",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
