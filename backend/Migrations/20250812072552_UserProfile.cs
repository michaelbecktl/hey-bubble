using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class UserProfile : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserProfiles",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Dob = table.Column<DateOnly>(type: "date", nullable: false),
                    ProfilePhoto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NativeLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LearningLanguage = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                  table.PrimaryKey("PK_UserProfiles", x => x.UserId);
                  table.ForeignKey(
                    name: "FK_UserProfiles_Users_UserId",
                    column: x => x.UserId,
                    principalTable: "Users",
                    principalColumn: "Id",
                    onDelete: ReferentialAction.Cascade
                  );
                });

            migrationBuilder.InsertData(
                table: "UserProfiles",
                columns: new[] { "UserId", "Country", "DisplayName", "Dob", "Gender", "LearningLanguage", "NativeLanguage", "ProfilePhoto" },
                values: new object[,]
                {
                    { -3, "NZ", "Hana", new DateOnly(2001, 1, 31), "Female", "EN", "JP", null },
                    { -2, "NZ", "Alice", new DateOnly(1991, 7, 2), "Female", "JP", "EN", null },
                    { -1, "NZ", "Maya", new DateOnly(1991, 12, 6), "Female", "JP", "EN", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "UserProfiles");
        }
    }
}
