using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIS.DAL.Migrations
{
    public partial class addQuestionsQuestionSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questions_QuestionSets_QuestionSetId",
                table: "Questions");

            migrationBuilder.DropIndex(
                name: "IX_Questions_QuestionSetId",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "QuestionSetId",
                table: "Questions");

            migrationBuilder.CreateTable(
                name: "QuestionsQuestionSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    QuestionSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsQuestionSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsQuestionSets_Questions_QuestionId",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionsQuestionSets_QuestionSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsQuestionSets_QuestionId",
                table: "QuestionsQuestionSets",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsQuestionSets_QuestionSetId",
                table: "QuestionsQuestionSets",
                column: "QuestionSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionsQuestionSets");

            migrationBuilder.AddColumn<int>(
                name: "QuestionSetId",
                table: "Questions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionSetId",
                table: "Questions",
                column: "QuestionSetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_QuestionSets_QuestionSetId",
                table: "Questions",
                column: "QuestionSetId",
                principalTable: "QuestionSets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
