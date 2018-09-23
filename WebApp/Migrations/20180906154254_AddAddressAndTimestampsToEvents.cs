using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp.Migrations
{
    public partial class AddAddressAndTimestampsToEvents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "VoteDeadline",
                table: "events",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidatedAt",
                table: "events",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "events",
                nullable: true,
                oldClrType: typeof(float));

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDeadline",
                table: "events",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "events",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddColumn<string>(
                name: "Address",
                table: "events",
                nullable: false);
            
            migrationBuilder.AddColumn<string>(
                name: "Postcode",
                table: "events",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "City",
                table: "events",
                nullable: false);

            migrationBuilder.AddColumn<string>(
                name: "Country",
                table: "events",
                nullable: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreatedAt",
                table: "events",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedAt",
                table: "events",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Address",
                table: "events");

            migrationBuilder.DropColumn(
                name: "City",
                table: "events");

            migrationBuilder.DropColumn(
                name: "Country",
                table: "events");

            migrationBuilder.DropColumn(
                name: "CreatedAt",
                table: "events");

            migrationBuilder.DropColumn(
                name: "UpdatedAt",
                table: "events");

            migrationBuilder.RenameColumn(
                name: "Postcode",
                table: "events",
                newName: "Place");

            migrationBuilder.AlterColumn<DateTime>(
                name: "VoteDeadline",
                table: "events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ValidatedAt",
                table: "events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<float>(
                name: "Price",
                table: "events",
                nullable: false,
                oldClrType: typeof(float),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "EnrollmentDeadline",
                table: "events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "events",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);
        }
    }
}
