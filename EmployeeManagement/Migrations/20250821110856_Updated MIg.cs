using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedMIg : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonPersonType_PersonTypes_PersonTypeId",
                table: "PersonPersonType");

            migrationBuilder.RenameColumn(
                name: "PersonTypeId",
                table: "PersonPersonType",
                newName: "PersonTypesId");

            migrationBuilder.AddColumn<Guid>(
                name: "PersonTypeId",
                table: "Persons",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddForeignKey(
                name: "FK_PersonPersonType_PersonTypes_PersonTypesId",
                table: "PersonPersonType",
                column: "PersonTypesId",
                principalTable: "PersonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PersonPersonType_PersonTypes_PersonTypesId",
                table: "PersonPersonType");

            migrationBuilder.DropColumn(
                name: "PersonTypeId",
                table: "Persons");

            migrationBuilder.RenameColumn(
                name: "PersonTypesId",
                table: "PersonPersonType",
                newName: "PersonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_PersonPersonType_PersonTypes_PersonTypeId",
                table: "PersonPersonType",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
