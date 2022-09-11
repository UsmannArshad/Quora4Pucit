using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoraForPucit.Migrations
{
    public partial class Inheritanceadded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Users",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "QuestionsUpvoters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "QuestionsUpvoters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "QuestionsUpvoters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "QuestionsUpvoters",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Questions",
                type: "varchar(80)",
                unicode: false,
                maxLength: 80,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(50)",
                oldUnicode: false,
                oldMaxLength: 50);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Questions",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Questions",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Q_Comments",
                type: "varchar(240)",
                unicode: false,
                maxLength: 240,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(max)",
                oldUnicode: false);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Q_Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Q_Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Q_Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Q_Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "AnswerUpvoter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "AnswerUpvoter",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "AnswerUpvoter",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "AnswerUpvoter",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "Answers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "Answers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "Answers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "CreatedByUser",
                table: "A_Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedDate",
                table: "A_Comments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ModifiedByUser",
                table: "A_Comments",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ModifiedDate",
                table: "A_Comments",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "QuestionsUpvoters");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "QuestionsUpvoters");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "QuestionsUpvoters");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "QuestionsUpvoters");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Questions");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Q_Comments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Q_Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Q_Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Q_Comments");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "AnswerUpvoter");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "AnswerUpvoter");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "AnswerUpvoter");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "AnswerUpvoter");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "Answers");

            migrationBuilder.DropColumn(
                name: "CreatedByUser",
                table: "A_Comments");

            migrationBuilder.DropColumn(
                name: "CreatedDate",
                table: "A_Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedByUser",
                table: "A_Comments");

            migrationBuilder.DropColumn(
                name: "ModifiedDate",
                table: "A_Comments");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Questions",
                type: "varchar(50)",
                unicode: false,
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(80)",
                oldUnicode: false,
                oldMaxLength: 80);

            migrationBuilder.AlterColumn<string>(
                name: "Comment",
                table: "Q_Comments",
                type: "varchar(max)",
                unicode: false,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(240)",
                oldUnicode: false,
                oldMaxLength: 240);
        }
    }
}
