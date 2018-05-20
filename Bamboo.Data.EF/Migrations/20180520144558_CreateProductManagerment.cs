using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class CreateProductManagerment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "FileIds",
                table: "ProjectEntity",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ProductEntityId",
                table: "FileEntity",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ProductCategoryEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    LastUpdatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductCategoryEntity", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Efficiency = table.Column<string>(nullable: true),
                    Investor = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    LastUpdatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    ProductCategoryId = table.Column<int>(nullable: false),
                    Progress = table.Column<string>(nullable: true),
                    Standard = table.Column<string>(nullable: true),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ProductEntity_ProductCategoryEntity_ProductCategoryId",
                        column: x => x.ProductCategoryId,
                        principalTable: "ProductCategoryEntity",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FileEntity_ProductEntityId",
                table: "FileEntity",
                column: "ProductEntityId");

            migrationBuilder.CreateIndex(
                name: "IX_ProductEntity_ProductCategoryId",
                table: "ProductEntity",
                column: "ProductCategoryId");

            migrationBuilder.AddForeignKey(
                name: "FK_FileEntity_ProductEntity_ProductEntityId",
                table: "FileEntity",
                column: "ProductEntityId",
                principalTable: "ProductEntity",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FileEntity_ProductEntity_ProductEntityId",
                table: "FileEntity");

            migrationBuilder.DropTable(
                name: "ProductEntity");

            migrationBuilder.DropTable(
                name: "ProductCategoryEntity");

            migrationBuilder.DropIndex(
                name: "IX_FileEntity_ProductEntityId",
                table: "FileEntity");

            migrationBuilder.DropColumn(
                name: "FileIds",
                table: "ProjectEntity");

            migrationBuilder.DropColumn(
                name: "ProductEntityId",
                table: "FileEntity");
        }
    }
}
