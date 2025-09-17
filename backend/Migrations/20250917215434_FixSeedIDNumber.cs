using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class FixSeedIDNumber : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "hana@heybubble.co.nz", "$2a$12$kMngNi/lnbyCxnixyC7Swuq99AWEvm9YGk8M.y9uneD49W3wJqvWm", "hanauser" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "alice@heybubble.co.nz", "$2a$11$fzXCnjrZ3KKnm3nI1nbdm.XQjaF3x/mXUIcmWMe3r2dMjBsSuRQ7u", "aliceuser" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -3,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "alice@heybubble.co.nz", "$2a$11$fzXCnjrZ3KKnm3nI1nbdm.XQjaF3x/mXUIcmWMe3r2dMjBsSuRQ7u", "aliceuser" });

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "Id",
                keyValue: -2,
                columns: new[] { "Email", "Password", "Username" },
                values: new object[] { "hana@heybubble.co.nz", "$2a$12$kMngNi/lnbyCxnixyC7Swuq99AWEvm9YGk8M.y9uneD49W3wJqvWm", "hanauser" });
        }
    }
}
