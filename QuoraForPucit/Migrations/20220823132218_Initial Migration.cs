using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace QuoraForPucit.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            /*migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Name = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    About = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Github = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Twitter = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    Website = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true),
                    ProfilePicture = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Questions",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Subject = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    QuestionaireId = table.Column<int>(type: "int", nullable: false),
                    Upvote = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    QuestionaireName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Questions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Questions_ToTable",
                        column: x => x.QuestionaireId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Answers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerDescription = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Time = table.Column<DateTime>(type: "datetime", nullable: true),
                    Upvote = table.Column<int>(type: "int", nullable: true, defaultValueSql: "((0))"),
                    AnswererId = table.Column<int>(type: "int", nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    AnswererName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Answers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Answers_Questions",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Answers_Users",
                        column: x => x.AnswererId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Q_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    Q_CommenterId = table.Column<int>(type: "int", nullable: false),
                    QCommenterName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Q_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Q_Comments_Questions",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Q_Comments_Users",
                        column: x => x.Q_CommenterId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "QuestionsUpvoters",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestionId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UpvoteStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QuestionsUpvoters", x => x.Id);
                    table.ForeignKey(
                        name: "FK_QuestionsUpvoters_Question",
                        column: x => x.QuestionId,
                        principalTable: "Questions",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_QuestionsUpvoters_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "A_Comments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comment = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_A_Comments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_A_Comments_Answers",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_A_Comments_Users",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnswerUpvoter",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnswerId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UpvoteStatus = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnswerUpvoter", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnswerUpvoters_Answer",
                        column: x => x.AnswerId,
                        principalTable: "Answers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnswerUpvoters_User",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_A_Comments_AnswerId",
                table: "A_Comments",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_A_Comments_UserId",
                table: "A_Comments",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_AnswererId",
                table: "Answers",
                column: "AnswererId");

            migrationBuilder.CreateIndex(
                name: "IX_Answers_QuestionId",
                table: "Answers",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUpvoter_AnswerId",
                table: "AnswerUpvoter",
                column: "AnswerId");

            migrationBuilder.CreateIndex(
                name: "IX_AnswerUpvoter_UserId",
                table: "AnswerUpvoter",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Q_Comments_Q_CommenterId",
                table: "Q_Comments",
                column: "Q_CommenterId");

            migrationBuilder.CreateIndex(
                name: "IX_Q_Comments_QuestionId",
                table: "Q_Comments",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_Questions_QuestionaireId",
                table: "Questions",
                column: "QuestionaireId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsUpvoters_QuestionId",
                table: "QuestionsUpvoters",
                column: "QuestionId");

            migrationBuilder.CreateIndex(
                name: "IX_QuestionsUpvoters_UserId",
                table: "QuestionsUpvoters",
                column: "UserId");*/
        }

    }
}
