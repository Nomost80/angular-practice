using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class CreateUsers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_events_Title",
                table: "events");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "events",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "events",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "events",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Slug",
                table: "events",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "users",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    UpdatedAt = table.Column<DateTime>(nullable: true),
                    FirstName = table.Column<string>(nullable: false),
                    LastName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: false),
                    Password = table.Column<string>(nullable: false),
                    SchoolGroup = table.Column<string>(nullable: false),
                    Avatar = table.Column<string>(nullable: true),
                    EmailAlert = table.Column<bool>(nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_events_AuthorId",
                table: "events",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_events_Image",
                table: "events",
                column: "Image",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_events_Slug",
                table: "events",
                column: "Slug",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Avatar",
                table: "users",
                column: "Avatar",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_users_Email",
                table: "users",
                column: "Email",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_events_users_AuthorId",
                table: "events",
                column: "AuthorId",
                principalTable: "users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_events_users_AuthorId",
                table: "events");

            migrationBuilder.DropTable(
                name: "users");

            migrationBuilder.DropIndex(
                name: "IX_events_AuthorId",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_Image",
                table: "events");

            migrationBuilder.DropIndex(
                name: "IX_events_Slug",
                table: "events");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Slug",
                table: "events");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "events",
                nullable: false,
                oldClrType: typeof(string));

            migrationBuilder.CreateIndex(
                name: "IX_events_Title",
                table: "events",
                column: "Title",
                unique: true);
        }
    }
}
