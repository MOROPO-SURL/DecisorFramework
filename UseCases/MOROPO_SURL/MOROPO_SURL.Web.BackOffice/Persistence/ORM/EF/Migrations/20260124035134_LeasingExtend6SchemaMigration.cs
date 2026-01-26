using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingExtend6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_drivelicences_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences");

            migrationBuilder.AlterColumn<string>(
                name: "reference",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "character varying(100)",
                maxLength: 100,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "text",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "fk_drivelicences_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_drivelicences_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences");

            migrationBuilder.AlterColumn<string>(
                name: "reference",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<Guid>(
                name: "contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AlterColumn<string>(
                name: "code",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                type: "text",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "character varying(100)",
                oldMaxLength: 100);

            migrationBuilder.AddForeignKey(
                name: "fk_drivelicences_personcontacts_contactid",
                schema: "decisorframework_leasing",
                table: "drivelicences",
                column: "contactid",
                principalSchema: "decisorframework_domain",
                principalTable: "personcontacts",
                principalColumn: "id");
        }
    }
}
