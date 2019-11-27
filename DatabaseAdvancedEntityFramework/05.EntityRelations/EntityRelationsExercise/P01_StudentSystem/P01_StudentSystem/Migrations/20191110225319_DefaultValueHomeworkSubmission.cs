using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace P01_StudentSystem.Migrations
{
    public partial class DefaultValueHomeworkSubmission : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "HomeworkSubmissions",
                nullable: false,
                defaultValue: new DateTime(2019, 11, 10, 22, 53, 19, 77, DateTimeKind.Utc).AddTicks(3045),
                oldClrType: typeof(DateTime));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "SubmissionTime",
                table: "HomeworkSubmissions",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 11, 10, 22, 53, 19, 77, DateTimeKind.Utc).AddTicks(3045));
        }
    }
}
