using Microsoft.EntityFrameworkCore.Migrations;

namespace AIS.DAL.Migrations
{
    public partial class Add_Columns_Into_QuestionIntervieweeAnswerEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestionSetId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SessionId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionSetId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.DropColumn(
                name: "SessionId",
                table: "QuestionIntervieweeAnswers");
        }
    }
}
