using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class AddAbout : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "IX_AboutEntity_FileId",
                table: "AboutEntity",
                column: "FileId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AboutEntity");
        }
    }
}
