using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Bamboo.Data.EF.Migrations
{
    public partial class AddConfiguration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfigurationEntity",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CreatedBy = table.Column<int>(nullable: false),
                    CreatedDateTime = table.Column<DateTimeOffset>(nullable: false),
                    DeletedBy = table.Column<int>(nullable: true),
                    DeletedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Key = table.Column<string>(nullable: true),
                    LastUpdatedBy = table.Column<int>(nullable: true),
                    LastUpdatedDateTime = table.Column<DateTimeOffset>(nullable: true),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfigurationEntity", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfigurationEntity");
        }
    }
}
