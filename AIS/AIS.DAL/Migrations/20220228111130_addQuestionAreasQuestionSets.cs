using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AIS.DAL.Migrations
{
    public partial class addQuestionAreasQuestionSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_QuestionSets_QuestionAreas_QuestionAreaId",
                table: "QuestionSets");

            migrationBuilder.DropIndex(
                name: "IX_QuestionSets_QuestionAreaId",
                table: "QuestionSets");

            migrationBuilder.DropColumn(
                name: "QuestionAreaId",
                table: "QuestionSets");

            migrationBuilder.CreateTable(
                name: "QuestionAreasQuestionSets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionAreaId = table.Column<int>(type: "int", nullable: false),
                    QuestionSetId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionAreasQuestionSets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionAreasQuestionSets_QuestionAreas_QuestionAreaId",
                        column: x => x.QuestionAreaId,
                        principalTable: "QuestionAreas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_QuestionAreasQuestionSets_QuestionSets_QuestionSetId",
                        column: x => x.QuestionSetId,
                        principalTable: "QuestionSets",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAreasQuestionSets_QuestionAreaId",
                table: "QuestionAreasQuestionSets",
                column: "QuestionAreaId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionAreasQuestionSets_QuestionSetId",
                table: "QuestionAreasQuestionSets",
                column: "QuestionSetId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "QuestionAreasQuestionSets");

            migrationBuilder.AddColumn<int>(
                name: "QuestionAreaId",
                table: "QuestionSets",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_QuestionSets_QuestionAreaId",
                table: "QuestionSets",
                column: "QuestionAreaId");

            migrationBuilder.AddForeignKey(
                name: "FK_QuestionSets_QuestionAreas_QuestionAreaId",
                table: "QuestionSets",
                column: "QuestionAreaId",
                principalTable: "QuestionAreas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
