using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChessApp.Migrations
{
    public partial class AddEnrollDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_players",
                table: "players");

            migrationBuilder.DropColumn(
                name: "BirthDate",
                table: "players");

            migrationBuilder.RenameTable(
                name: "players",
                newName: "EnrollDetails");

            migrationBuilder.RenameColumn(
                name: "Country",
                table: "EnrollDetails",
                newName: "PhoneNumber");

            migrationBuilder.AddColumn<string>(
                name: "EmailID",
                table: "EnrollDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FideId",
                table: "EnrollDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "FideRating",
                table: "EnrollDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Level",
                table: "EnrollDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnrollDetails",
                table: "EnrollDetails",
                column: "PlayerID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_EnrollDetails",
                table: "EnrollDetails");

            migrationBuilder.DropColumn(
                name: "EmailID",
                table: "EnrollDetails");

            migrationBuilder.DropColumn(
                name: "FideId",
                table: "EnrollDetails");

            migrationBuilder.DropColumn(
                name: "FideRating",
                table: "EnrollDetails");

            migrationBuilder.DropColumn(
                name: "Level",
                table: "EnrollDetails");

            migrationBuilder.RenameTable(
                name: "EnrollDetails",
                newName: "players");

            migrationBuilder.RenameColumn(
                name: "PhoneNumber",
                table: "players",
                newName: "Country");

            migrationBuilder.AddColumn<DateTime>(
                name: "BirthDate",
                table: "players",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddPrimaryKey(
                name: "PK_players",
                table: "players",
                column: "PlayerID");
        }
    }
}
