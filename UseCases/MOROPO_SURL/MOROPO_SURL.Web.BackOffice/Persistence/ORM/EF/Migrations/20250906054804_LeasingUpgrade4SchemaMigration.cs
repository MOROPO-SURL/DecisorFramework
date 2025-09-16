using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class LeasingUpgrade4SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "paymenttermid",
                table: "leasecontracts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "ix_leasecontracts_paymenttermid",
                table: "leasecontracts",
                column: "paymenttermid");

            migrationBuilder.AddForeignKey(
                name: "fk_leasecontracts_paymentterms_paymenttermid",
                table: "leasecontracts",
                column: "paymenttermid",
                principalSchema: "decisorframework_commercial",
                principalTable: "paymentterms",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_leasecontracts_paymentterms_paymenttermid",
                table: "leasecontracts");

            migrationBuilder.DropIndex(
                name: "ix_leasecontracts_paymenttermid",
                table: "leasecontracts");

            migrationBuilder.DropColumn(
                name: "paymenttermid",
                table: "leasecontracts");
        }
    }
}
