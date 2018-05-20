using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class UpdateFileEntity_Ver2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ContentBase64",
                table: "FileEntity");

            migrationBuilder.DropColumn(
                name: "EncodeFileName",
                table: "FileEntity");

            migrationBuilder.RenameColumn(
                name: "FileName",
                table: "FileEntity",
                newName: "Url");

            migrationBuilder.RenameColumn(
                name: "FileExtension",
                table: "FileEntity",
                newName: "Name");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Url",
                table: "FileEntity",
                newName: "FileName");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "FileEntity",
                newName: "FileExtension");

            migrationBuilder.AddColumn<string>(
                name: "ContentBase64",
                table: "FileEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EncodeFileName",
                table: "FileEntity",
                nullable: true);
        }
    }
}
