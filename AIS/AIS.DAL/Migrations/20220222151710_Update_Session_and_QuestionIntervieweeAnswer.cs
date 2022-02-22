using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIS.DAL.Migrations
{
    public partial class Update_Session_and_QuestionIntervieweeAnswer : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionIntervieweeAnswers_SessionId",
                table: "QuestionIntervieweeAnswers",
                column: "SessionId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropIndex(
                name: "IX_QuestionIntervieweeAnswers_SessionId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "QuestionIntervieweeAnswers");
        }
    }
}
