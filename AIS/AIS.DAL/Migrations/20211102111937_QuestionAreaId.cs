using Microsoft.EntityFrameworkCore.Migrations;

namespace AIS.DAL.Migrations
{
    public partial class QuestionAreaId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionAreaId",
                table: "Sessions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Sessions_QuestionAreaId",
                table: "Sessions",
                column: "QuestionAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Sessions_QuestionAreas_QuestionAreaId",
                table: "Sessions",
                column: "QuestionAreaId",
                principalTable: "QuestionAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Sessions_QuestionAreas_QuestionAreaId",
                table: "Sessions");

            migrationBuilder.DropIndex(
                name: "IX_Sessions_QuestionAreaId",
                table: "Sessions");

            migrationBuilder.DropColumn(
                name: "QuestionAreaId",
                table: "Sessions");
        }
    }
}
