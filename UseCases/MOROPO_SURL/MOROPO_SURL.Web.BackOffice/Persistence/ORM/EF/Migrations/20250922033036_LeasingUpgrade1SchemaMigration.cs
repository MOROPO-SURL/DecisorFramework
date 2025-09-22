using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade1SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_vehleaspersonpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_vehleasorgpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_propleaspersonpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "bankaccountid");

            migrationBuilder.CreateIndex(
                name: "ix_propleasorgpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "bankaccountid");

            migrationBuilder.AddForeignKey(
                name: "fk_propleasorgpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations",
                column: "bankaccountid",
                principalSchema: "decisorframework_finantial",
                principalTable: "bankaccounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_propleaspersonpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations",
                column: "bankaccountid",
                principalSchema: "decisorframework_finantial",
                principalTable: "bankaccounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleasorgpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations",
                column: "bankaccountid",
                principalSchema: "decisorframework_finantial",
                principalTable: "bankaccounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_vehleaspersonpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations",
                column: "bankaccountid",
                principalSchema: "decisorframework_finantial",
                principalTable: "bankaccounts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_propleasorgpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_propleaspersonpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleasorgpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropForeignKey(
                name: "fk_vehleaspersonpostulations_bankaccounts_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropIndex(
                name: "ix_vehleaspersonpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropIndex(
                name: "ix_vehleasorgpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropIndex(
                name: "ix_propleaspersonpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropIndex(
                name: "ix_propleasorgpostulations_bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");

            migrationBuilder.DropColumn(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "vehleasorgpostulations");

            migrationBuilder.DropColumn(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleaspersonpostulations");

            migrationBuilder.DropColumn(
                name: "bankaccountid",
                schema: "decisorframework_leasing",
                table: "propleasorgpostulations");
        }
    }
}
