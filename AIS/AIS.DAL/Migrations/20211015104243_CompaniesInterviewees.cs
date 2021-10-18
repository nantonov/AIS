using Microsoft.EntityFrameworkCore.Migrations;

namespace AIS.DAL.Migrations
{
    public partial class CompaniesInterviewees : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IntervieweeId",
                table: "Interviewees",
                newName: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Interviewees",
                newName: "IntervieweeId");
        }
    }
}
