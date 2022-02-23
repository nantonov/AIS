using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIS.DAL.Migrations
{
    public partial class DeleteTrueAnswerId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionIntervieweeAnswers_TrueAnswers_TrueAnswerId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionIntervieweeAnswers_TrueAnswerId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropColumn(
                name: "TrueAnswerId",
                table: "QuestionIntervieweeAnswers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TrueAnswerId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionIntervieweeAnswers_TrueAnswerId",
                table: "QuestionIntervieweeAnswers",
                column: "TrueAnswerId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionIntervieweeAnswers_TrueAnswers_TrueAnswerId",
                table: "QuestionIntervieweeAnswers",
                column: "TrueAnswerId",
                principalTable: "TrueAnswers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
