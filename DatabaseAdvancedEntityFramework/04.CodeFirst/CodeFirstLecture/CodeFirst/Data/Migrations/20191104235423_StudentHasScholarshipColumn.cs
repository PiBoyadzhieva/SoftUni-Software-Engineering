namespace CodeFirst.Data.Migrations
{
    using Microsoft.EntityFrameworkCore.Migrations;

    public partial class StudentHasScholarshipColumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "HasScholarship",
                table: "Students",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HasScholarship",
                table: "Students");
        }
    }
}
