using Microsoft.EntityFrameworkCore.Migrations;

namespace AIS.DAL.Migrations
{
    public partial class Update_SessionEntity_and_QuestionIntervieweeAnswerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_QuestionIntervieweeAnswers_SessionId",
                table: "QuestionIntervieweeAnswers",
                column: "SessionId");

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
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionIntervieweeAnswers_SessionId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.AddColumn<int>(
                name: "QuestionSetId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
