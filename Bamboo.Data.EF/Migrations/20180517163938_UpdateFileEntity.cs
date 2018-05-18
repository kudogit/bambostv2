using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class UpdateFileEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarouselEntity_FileEntity_FileId",
                table: "CarouselEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_FileEntity_AdvisoryEntity_AdvisoryId",
                table: "FileEntity");

            migrationBuilder.DropForeignKey(
                name: "FK_FileEntity_ProjectEntity_ProjectId",
                table: "FileEntity");

            migrationBuilder.DropTable(
                name: "AboutEntity");

            migrationBuilder.DropIndex(
                name: "IX_FileEntity_AdvisoryId",
                table: "FileEntity");

            migrationBuilder.DropIndex(
                name: "IX_FileEntity_ProjectId",
                table: "FileEntity");

            migrationBuilder.DropIndex(
                name: "IX_CarouselEntity_FileId",
                table: "CarouselEntity");

            migrationBuilder.DropColumn(
                name: "AdvisoryId",
                table: "FileEntity");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "FileEntity");

            migrationBuilder.DropColumn(
                name: "ProjectId",
                table: "FileEntity");

            migrationBuilder.DropColumn(
                name: "FileId",
                table: "CarouselEntity");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AdvisoryId",
                table: "FileEntity",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "FileEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProjectId",
                table: "FileEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "FileId",
                table: "CarouselEntity",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "AboutEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    FileId = table.Column<int>(nullable: true),
                    IsSelected = table.Column<bool>(nullable: false),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    LastUpdatedDateTime = table.Column<DateTimeOffset>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AboutEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AboutEntity_FileEntity_FileId",
                        column: x => x.FileId,
                        principalTable: "FileEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_AdvisoryId",
                table: "FileEntity",
                column: "AdvisoryId");

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_ProjectId",
                table: "FileEntity",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_CarouselEntity_FileId",
                table: "CarouselEntity",
                column: "FileId");

            migrationBuilder.CreateIndex(
                name: "IX_AboutEntity_FileId",
                table: "AboutEntity",
                column: "FileId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarouselEntity_FileEntity_FileId",
                table: "CarouselEntity",
                column: "FileId",
                principalTable: "FileEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_FileEntity_AdvisoryEntity_AdvisoryId",
                table: "FileEntity",
                column: "AdvisoryId",
                principalTable: "AdvisoryEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_FileEntity_ProjectEntity_ProjectId",
                table: "FileEntity",
                column: "ProjectId",
                principalTable: "ProjectEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
