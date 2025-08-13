﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "Id", "Email", "Password", "Username" },
                values: new object[,]
                {
                    { -3, "alice@heybubble.co.nz", "$2a$11$fzXCnjrZ3KKnm3nI1nbdm.XQjaF3x/mXUIcmWMe3r2dMjBsSuRQ7u", "aliceuser" },
                    { -2, "hana@heybubble.co.nz", "$2a$12$kMngNi/lnbyCxnixyC7Swuq99AWEvm9YGk8M.y9uneD49W3wJqvWm", "hanauser" },
                    { -1, "maya@heybubble.co.nz", "$2a$12$J8d2vGlMWUiW6dWIszp2F.rzAw7qBYq5Hbd/6ijGX5o6x3Q5oX2G2", "mayauser" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
