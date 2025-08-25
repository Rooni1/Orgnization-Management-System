using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EmployeeManagement.Migrations
{
    /// <inheritdoc />
    public partial class relationshipUpdated : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PersonPersonType");

            migrationBuilder.CreateIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                table: "Persons",
                column: "PersonTypeId",
                principalTable: "PersonTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Persons_PersonTypes_PersonTypeId",
                table: "Persons");

            migrationBuilder.DropIndex(
                name: "IX_Persons_PersonTypeId",
                table: "Persons");

            migrationBuilder.CreateTable(
                name: "PersonPersonType",
                columns: table => new
                {
                    PersonTypesId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PersonsId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PersonPersonType", x => new { x.PersonTypesId, x.PersonsId });
                    table.ForeignKey(
                        name: "FK_PersonPersonType_PersonTypes_PersonTypesId",
                        column: x => x.PersonTypesId,
                        principalTable: "PersonTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PersonPersonType_Persons_PersonsId",
                        column: x => x.PersonsId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PersonPersonType_PersonsId",
                table: "PersonPersonType",
                column: "PersonsId");
        }
    }
}
