using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RazorVue.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Lists",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Lists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Materials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ExternalReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    OriginatingSystem = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Materials", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Segments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Start = table.Column<TimeSpan>(type: "time", nullable: false),
                    Length = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Type = table.Column<int>(type: "int", nullable: false),
                    Rights = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MaterialId = table.Column<int>(type: "int", nullable: true),
                    ListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Segments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Segments_Lists_ListId",
                        column: x => x.ListId,
                        principalTable: "Lists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Segments_Materials_MaterialId",
                        column: x => x.MaterialId,
                        principalTable: "Materials",
                        principalColumn: "Id");
                });

            migrationBuilder.InsertData(
                table: "Lists",
                columns: new[] { "Id", "Start", "Title" },
                values: new object[] { 1, new DateTime(2022, 7, 1, 19, 14, 23, 0, DateTimeKind.Unspecified), "Mountain Mike" });

            migrationBuilder.InsertData(
                table: "Materials",
                columns: new[] { "Id", "Description", "ExternalReference", "OriginatingSystem" },
                values: new object[,]
                {
                    { 1, "First steps of Mountain Mike", "4/100512274", "Archive" },
                    { 2, "Mountain Mike is hiking", "4/101426827", "Archive" },
                    { 3, "Hiking is a new movement", "4/101526914; 510/12/000.434.997", "Archive;PreEditor" },
                    { 4, "Mountain Mike takes a rest", "4/101427138", "Archive" },
                    { 5, "Local mountain tours for intermediates", "4/101536989; 510/12/000.434.998", "Archive;PreEditor" },
                    { 7, "Say goodbye to Mountain Mike", "4/101429299", "Archive" }
                });

            migrationBuilder.InsertData(
                table: "Segments",
                columns: new[] { "Id", "Description", "Length", "ListId", "MaterialId", "Rights", "Start", "Type" },
                values: new object[,]
                {
                    { 1, "Mountain Mike tells about the beginning", 12, 1, 1, "w/o", new TimeSpan(0, 0, 0, 0, 0), 1 },
                    { 2, "Mountain Mike tells about the beginning", 24, 1, 2, "w/o", new TimeSpan(0, 0, 0, 12, 0), 0 },
                    { 3, "Everybody loves hiking", 18, 1, 3, "Property of the content group, usage allowed", new TimeSpan(0, 0, 0, 36, 0), 1 },
                    { 4, "Take a break, Mike", 6, 1, 4, "w/o", new TimeSpan(0, 0, 0, 54, 0), 0 },
                    { 5, "Local mountain tours", 18, 1, 5, "Property of the local hiking club, usage allowed", new TimeSpan(0, 0, 1, 0, 0), 1 },
                    { 6, "Map of local mountain tours", 12, 1, null, "Property of the local hiking club, usage allowed only for current broadcast", new TimeSpan(0, 0, 1, 3, 0), 3 },
                    { 7, "Time to say goodbye", 6, 1, 7, "w/o", new TimeSpan(0, 0, 1, 18, 0), 0 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Segments_ListId",
                table: "Segments",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_Segments_MaterialId",
                table: "Segments",
                column: "MaterialId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Segments");

            migrationBuilder.DropTable(
                name: "Lists");

            migrationBuilder.DropTable(
                name: "Materials");
        }
    }
}
