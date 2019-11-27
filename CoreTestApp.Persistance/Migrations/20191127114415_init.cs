using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CoreTestApp.Persistance.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "test");

            migrationBuilder.CreateTable(
                name: "BroadcastType",
                schema: "test",
                columns: table => new
                {
                    BroadcastTypeId = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BroadcastType", x => x.BroadcastTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Broadcast",
                schema: "test",
                columns: table => new
                {
                    BroadcastId = table.Column<Guid>(nullable: false),
                    BroadcastTypeId = table.Column<Guid>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    FirstOnline = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Broadcast", x => x.BroadcastId);
                    table.ForeignKey(
                        name: "FK_Broadcast_BroadcastType_BroadcastTypeId",
                        column: x => x.BroadcastTypeId,
                        principalSchema: "test",
                        principalTable: "BroadcastType",
                        principalColumn: "BroadcastTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                schema: "test",
                table: "BroadcastType",
                columns: new[] { "BroadcastTypeId", "Name" },
                values: new object[] { new Guid("0151059b-a859-4931-f3f2-08d773208df1"), "Basketball" });

            migrationBuilder.CreateIndex(
                name: "IX_Broadcast_BroadcastTypeId",
                schema: "test",
                table: "Broadcast",
                column: "BroadcastTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Broadcast",
                schema: "test");

            migrationBuilder.DropTable(
                name: "BroadcastType",
                schema: "test");
        }
    }
}
