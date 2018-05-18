using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class UpdateProjectV1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Efficiency",
                table: "ProjectEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Investor",
                table: "ProjectEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Progress",
                table: "ProjectEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Standard",
                table: "ProjectEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Title",
                table: "ProjectEntity",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Efficiency",
                table: "ProjectEntity");

            migrationBuilder.DropColumn(
                name: "Investor",
                table: "ProjectEntity");

            migrationBuilder.DropColumn(
                name: "Progress",
                table: "ProjectEntity");

            migrationBuilder.DropColumn(
                name: "Standard",
                table: "ProjectEntity");

            migrationBuilder.DropColumn(
                name: "Title",
                table: "ProjectEntity");
        }
    }
}
