using Microsoft.EntityFrameworkCore.Migrations;

namespace AIS.DAL.Migrations
{
    public partial class update_SessionEntity_and_QuestionSetEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuestionIntervieweeAnswers_QuestionSetId",
                table: "QuestionIntervieweeAnswers",
                column: "QuestionSetId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionIntervieweeAnswers_SessionId",
                table: "QuestionIntervieweeAnswers",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionIntervieweeAnswers_QuestionSets_QuestionSetId",
                table: "QuestionIntervieweeAnswers",
                column: "QuestionSetId",
                principalTable: "QuestionSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionIntervieweeAnswers_QuestionSets_QuestionSetId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionIntervieweeAnswers_QuestionSetId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionIntervieweeAnswers_SessionId",
                table: "QuestionIntervieweeAnswers");
        }
    }
}
