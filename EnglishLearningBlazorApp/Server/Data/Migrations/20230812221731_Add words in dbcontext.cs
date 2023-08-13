using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EnglishLearningBlazorApp.Server.Data.Migrations
{
    public partial class Addwordsindbcontext : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Words",
                columns: table => new
                {
                    wordId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    simpleTense = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    definition = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UKAudioURI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    USAudioURI = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    creatorId = table.Column<int>(type: "int", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Words", x => x.wordId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Words");
        }
    }
}
