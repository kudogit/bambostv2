using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class UpdateProjectV2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProjectEntityId",
                table: "FileEntity",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_ProjectEntityId",
                table: "FileEntity",
                column: "ProjectEntityId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileEntity_ProjectEntity_ProjectEntityId",
                table: "FileEntity",
                column: "ProjectEntityId",
                principalTable: "ProjectEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileEntity_ProjectEntity_ProjectEntityId",
                table: "FileEntity");

            migrationBuilder.DropIndex(
                name: "IX_FileEntity_ProjectEntityId",
                table: "FileEntity");

            migrationBuilder.DropColumn(
                name: "ProjectEntityId",
                table: "FileEntity");
        }
    }
}
