using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace KeesingTechnologies.Assessment.CalendarService.Api.Data.Migrations
{
    public partial class _001Initialdb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Name = table.Column<string>(type: "TEXT", maxLength: 60, nullable: false),
                    Time = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Location = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    Members = table.Column<string>(type: "TEXT", nullable: true),
                    EventOrganizer = table.Column<string>(type: "TEXT", maxLength: 60, nullable: true),
                    CreatedByIp = table.Column<string>(type: "TEXT", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastModifiedByIp = table.Column<string>(type: "TEXT", nullable: true),
                    LastModifiedDate = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByIp", "CreatedDate", "EventOrganizer", "LastModifiedByIp", "LastModifiedDate", "Location", "Members", "Name", "Time" },
                values: new object[] { new Guid("b69ab758-4324-40b8-b761-71b14cb96e8a"), "151.139.128.11", new DateTime(2021, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "KeesingTechnologies", null, null, "Bangkok, Thailand", "[\"NXP\",\"Laxton\"]", "Sixth Border Management and Identity Conference", new DateTime(2021, 12, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByIp", "CreatedDate", "EventOrganizer", "LastModifiedByIp", "LastModifiedDate", "Location", "Members", "Name", "Time" },
                values: new object[] { new Guid("3e8f4a34-31b0-4106-82e6-68dfbdb34c1e"), "104.248.80.94", new DateTime(2021, 1, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Secure ID Forum", "104.248.80.94", new DateTime(2021, 6, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "Riga, Latvia", "[\"Infotech\",\"Infineon\",\"Integrated biometrics\"]", "Secure ID Forum", new DateTime(2022, 5, 24, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByIp", "CreatedDate", "EventOrganizer", "LastModifiedByIp", "LastModifiedDate", "Location", "Members", "Name", "Time" },
                values: new object[] { new Guid("67a03173-624a-402d-b3e1-818d24e9dc1a"), "99.86.113.17", new DateTime(2021, 1, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Ascential Events", "99.86.113.17", new DateTime(2021, 6, 20, 0, 0, 0, 0, DateTimeKind.Unspecified), "Amsterdam, Netherlands", "[\"Banking Circle\",\"Discover Global Network\",\"Nexi\",\"OpenPayd\",\"Solarisbank\",\"Truelayer\",\"Trustly\",\"Youlend\"]", "Money20/20 Europe", new DateTime(2021, 9, 21, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByIp", "CreatedDate", "EventOrganizer", "LastModifiedByIp", "LastModifiedDate", "Location", "Members", "Name", "Time" },
                values: new object[] { new Guid("e4a20e6d-bee0-44cb-a1de-e558d2d3d5d8"), "151.139.128.11", new DateTime(2021, 9, 27, 0, 0, 0, 0, DateTimeKind.Unspecified), "KeesingTechnologies", null, null, "Skype, Online", "[\"Paula van Rossen\",\"Amin Mesbahi\"]", "Technical Interview", new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.InsertData(
                table: "Events",
                columns: new[] { "Id", "CreatedByIp", "CreatedDate", "EventOrganizer", "LastModifiedByIp", "LastModifiedDate", "Location", "Members", "Name", "Time" },
                values: new object[] { new Guid("8f853347-dcb1-4b21-a77c-b2a3332ccc08"), "151.139.128.11", new DateTime(2021, 9, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), "KeesingTechnologies", null, null, "Skype, Online", "[\"Paula van Rossen\",\"Amin Mesbahi\",\"Team\",\"Managing Director\"]", "non-Technical Interview with team and possibly with the Managing Director", new DateTime(2021, 10, 4, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Events");
        }
    }
}
