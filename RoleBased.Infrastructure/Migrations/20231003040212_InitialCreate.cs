using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RoleBased.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginDb",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginDb", x => x.RegNo);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    RegNo = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoB = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    PhoneNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EmailNo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastModified = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: false),
                    LastModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.RegNo);
                });

            migrationBuilder.InsertData(
                table: "StudentInfo",
                columns: new[] { "RegNo", "Created", "CreatedBy", "DoB", "EmailNo", "LastModified", "LastModifiedBy", "Name", "PhoneNo", "Status" },
                values: new object[] { "1", new DateTimeOffset(new DateTime(2023, 10, 3, 10, 2, 12, 492, DateTimeKind.Unspecified).AddTicks(1192), new TimeSpan(0, 6, 0, 0, 0)), "1", new DateTimeOffset(new DateTime(2023, 10, 3, 10, 2, 12, 492, DateTimeKind.Unspecified).AddTicks(1157), new TimeSpan(0, 6, 0, 0, 0)), "pejus4490@gmail.Com", new DateTimeOffset(new DateTime(2023, 10, 3, 10, 2, 12, 492, DateTimeKind.Unspecified).AddTicks(1194), new TimeSpan(0, 6, 0, 0, 0)), null, "Pejus Kanti Sazzon", "01650xxxx", 1 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginDb");

            migrationBuilder.DropTable(
                name: "StudentInfo");
        }
    }
}
