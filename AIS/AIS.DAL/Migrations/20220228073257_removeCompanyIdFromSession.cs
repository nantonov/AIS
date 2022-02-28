using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIS.DAL.Migrations
{
    public partial class removeCompanyIdFromSession : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_Companies_CompanyId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_CompanyId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "CompanyId",
                table: "Sessions");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompanyId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_CompanyId",
                table: "Sessions",
                column: "CompanyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_Companies_CompanyId",
                table: "Sessions",
                column: "CompanyId",
                principalTable: "Companies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
