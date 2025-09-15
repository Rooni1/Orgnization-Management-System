using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjectManagement.Migrations
{
    /// <inheritdoc />
    public partial class alterTabl1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Department_DepartmentsId",
                table: "Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Departments_DepartmentsId",
                table: "Person",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Person_Departments_DepartmentsId",
                table: "Person");

            migrationBuilder.AddForeignKey(
                name: "FK_Person_Department_DepartmentsId",
                table: "Person",
                column: "DepartmentsId",
                principalTable: "Department",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
