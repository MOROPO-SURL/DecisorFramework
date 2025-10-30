using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MOROPO.Tool.Decisor.Web.BackOffice.Persistence.ORM.EF.Migrations
{
    /// <inheritdoc />
    public partial class PurchasingUpgrade6SchemaMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_classifications_classifica~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_legalproviderbudgets_budge~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_products_productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_budge~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_requestableservices_servic~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_classifications_classif~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_products_productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_requestableservices_ser~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_naturalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropColumn(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropColumn(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropColumn(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropColumn(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisorframework_sales",
                table: "naturalclientbudget");

            migrationBuilder.DropColumn(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropColumn(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropColumn(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropColumn(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropColumn(
                name: "priority",
                schema: "decisorframework_sales",
                table: "legalclientbudget");

            migrationBuilder.RenameColumn(
                name: "serviceid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_naturalproviderbudgetservicebridges_serviceid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                newName: "ix_naturalproviderbudgetservicebridges_sternid");

            migrationBuilder.RenameColumn(
                name: "productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_naturalproviderbudgetproductbridges_productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                newName: "ix_naturalproviderbudgetproductbridges_sternid");

            migrationBuilder.RenameColumn(
                name: "serviceid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetservicebridge_serviceid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "ix_legalproviderbudgetservicebridge_sternid");

            migrationBuilder.RenameColumn(
                name: "productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                newName: "sternid");

            migrationBuilder.RenameColumn(
                name: "providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                newName: "prowid");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetproductbridge_productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                newName: "ix_legalproviderbudgetproductbridge_sternid");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "classificationid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<Guid>(
                name: "classificationid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                type: "uuid",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uuid");

            migrationBuilder.AddColumn<Guid>(
                name: "id",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "pk_naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_naturalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                column: "id");

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                columns: new[] { "prowid", "sternid" });

            migrationBuilder.CreateIndex(
                name: "ix_naturalproviderbudgets_number_year_providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                columns: new[] { "number", "year", "providerid" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_legalproviderbudgets_number_year_providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                columns: new[] { "number", "year", "providerid" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_classifications_classifica~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "classificationid",
                principalSchema: "decisorframework_inventory",
                principalTable: "classifications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_legalproviderbudgets_prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "legalproviderbudgets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_products_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "sternid",
                principalSchema: "decisorframework_inventory",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "legalproviderbudgets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_requestableservices_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "sternid",
                principalSchema: "decisorframework_commercial",
                principalTable: "requestableservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_classifications_classif~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "classificationid",
                principalSchema: "decisorframework_inventory",
                principalTable: "classifications",
                principalColumn: "id");

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "naturalproviderbudgets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_products_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "sternid",
                principalSchema: "decisorframework_inventory",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "prowid",
                principalSchema: "decisorframework_purchasing",
                principalTable: "naturalproviderbudgets",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_requestableservices_ste~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "sternid",
                principalSchema: "decisorframework_commercial",
                principalTable: "requestableservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_classifications_classifica~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_legalproviderbudgets_prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetproductbridge_products_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_legalproviderbudgetservicebridge_requestableservices_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_classifications_classif~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_products_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_requestableservices_ste~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_naturalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropIndex(
                name: "ix_naturalproviderbudgets_number_year_providerid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropIndex(
                name: "ix_legalproviderbudgets_number_year_providerid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropPrimaryKey(
                name: "pk_legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_sales",
                table: "naturalclientbudget");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets");

            migrationBuilder.DropColumn(
                name: "id",
                schema: "decisorframework_sales",
                table: "legalclientbudget");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                newName: "serviceid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                newName: "providerid");

            migrationBuilder.RenameIndex(
                name: "ix_naturalproviderbudgetservicebridges_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                newName: "ix_naturalproviderbudgetservicebridges_serviceid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                newName: "providerid");

            migrationBuilder.RenameIndex(
                name: "ix_naturalproviderbudgetproductbridges_sternid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                newName: "ix_naturalproviderbudgetproductbridges_productid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "serviceid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "providerid");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetservicebridge_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                newName: "ix_legalproviderbudgetservicebridge_serviceid");

            migrationBuilder.RenameColumn(
                name: "sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                newName: "productid");

            migrationBuilder.RenameColumn(
                name: "prowid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                newName: "providerid");

            migrationBuilder.RenameIndex(
                name: "ix_legalproviderbudgetproductbridge_sternid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                newName: "ix_legalproviderbudgetproductbridge_productid");

            migrationBuilder.AddColumn<int>(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "classificationid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisorframework_sales",
                table: "naturalclientbudget",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<Guid>(
                name: "classificationid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uuid",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "budgetnumber",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "budgetyear",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "priority",
                schema: "decisorframework_sales",
                table: "legalclientbudget",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "pk_naturalproviderbudgetservicebridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                columns: new[] { "budgetnumber", "budgetyear", "providerid", "serviceid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_naturalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgets",
                columns: new[] { "number", "year", "providerid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_naturalproviderbudgetproductbridges",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                columns: new[] { "budgetnumber", "budgetyear", "providerid", "productid", "classificationid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgetservicebridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                columns: new[] { "budgetnumber", "budgetyear", "providerid", "serviceid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgets",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgets",
                columns: new[] { "number", "year", "providerid" });

            migrationBuilder.AddPrimaryKey(
                name: "pk_legalproviderbudgetproductbridge",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                columns: new[] { "budgetnumber", "budgetyear", "providerid", "productid", "classificationid" });

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_classifications_classifica~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "classificationid",
                principalSchema: "decisorframework_inventory",
                principalTable: "classifications",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_legalproviderbudgets_budge~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                columns: new[] { "budgetnumber", "budgetyear", "providerid" },
                principalSchema: "decisorframework_purchasing",
                principalTable: "legalproviderbudgets",
                principalColumns: new[] { "number", "year", "providerid" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetproductbridge_products_productid",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetproductbridge",
                column: "productid",
                principalSchema: "decisorframework_inventory",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_legalproviderbudgets_budge~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                columns: new[] { "budgetnumber", "budgetyear", "providerid" },
                principalSchema: "decisorframework_purchasing",
                principalTable: "legalproviderbudgets",
                principalColumns: new[] { "number", "year", "providerid" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_legalproviderbudgetservicebridge_requestableservices_servic~",
                schema: "decisorframework_purchasing",
                table: "legalproviderbudgetservicebridge",
                column: "serviceid",
                principalSchema: "decisorframework_commercial",
                principalTable: "requestableservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_classifications_classif~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "classificationid",
                principalSchema: "decisorframework_inventory",
                principalTable: "classifications",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                columns: new[] { "budgetnumber", "budgetyear", "providerid" },
                principalSchema: "decisorframework_purchasing",
                principalTable: "naturalproviderbudgets",
                principalColumns: new[] { "number", "year", "providerid" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetproductbridges_products_productid",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetproductbridges",
                column: "productid",
                principalSchema: "decisorframework_inventory",
                principalTable: "products",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_naturalproviderbudgets_~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                columns: new[] { "budgetnumber", "budgetyear", "providerid" },
                principalSchema: "decisorframework_purchasing",
                principalTable: "naturalproviderbudgets",
                principalColumns: new[] { "number", "year", "providerid" },
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "fk_naturalproviderbudgetservicebridges_requestableservices_ser~",
                schema: "decisorframework_purchasing",
                table: "naturalproviderbudgetservicebridges",
                column: "serviceid",
                principalSchema: "decisorframework_commercial",
                principalTable: "requestableservices",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
