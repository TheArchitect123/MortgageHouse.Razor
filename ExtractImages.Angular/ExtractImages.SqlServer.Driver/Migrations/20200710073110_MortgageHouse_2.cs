using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ExtractImages.SqlServer.Driver.Migrations
{
    public partial class MortgageHouse_2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateTable(
                name: "New",
                schema: "dbo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    image_id = table.Column<int>(nullable: false),
                    upload_obua_id = table.Column<int>(nullable: false),
                    document_type_id = table.Column<int>(nullable: false),
                    upload_date = table.Column<DateTime>(nullable: false),
                    Record_Create_Date = table.Column<DateTime>(nullable: false),
                    last_download_timestamp = table.Column<DateTime>(nullable: false),
                    last_download_obua_id = table.Column<int>(nullable: false),
                    description = table.Column<string>(nullable: true),
                    filename = table.Column<string>(nullable: true),
                    imagePath = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_New", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "New",
                schema: "dbo");
        }
    }
}
