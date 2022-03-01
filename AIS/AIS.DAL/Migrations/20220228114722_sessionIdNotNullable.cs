using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIS.DAL.Migrations
{
    public partial class sessionIdNotNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers");

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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

            migrationBuilder.AlterColumn<int>(
                name: "SessionId",
                table: "QuestionIntervieweeAnswers",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionIntervieweeAnswers_Sessions_SessionId",
                table: "QuestionIntervieweeAnswers",
                column: "SessionId",
                principalTable: "Sessions",
                principalColumn: "Id");
        }
    }
}
