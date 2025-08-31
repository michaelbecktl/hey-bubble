using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddedCommentCountToPostTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CommentCount",
                table: "Posts",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "CommentLikes",
                columns: new[] { "CommentId", "UserId" },
                values: new object[,]
                {
                    { 1, -3 },
                    { 1, -2 }
                });

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "LikeCount",
                value: 1);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "LikeCount",
                value: 1);

            migrationBuilder.InsertData(
                table: "PostLikes",
                columns: new[] { "PostId", "UserId" },
                values: new object[,]
                {
                    { 1, -1 },
                    { 2, -1 }
                });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                columns: new[] { "CommentCount", "LikeCount" },
                values: new object[] { 2, 2 });

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 2,
                column: "CommentCount",
                value: null);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, -3 });

            migrationBuilder.DeleteData(
                table: "CommentLikes",
                keyColumns: new[] { "CommentId", "UserId" },
                keyValues: new object[] { 1, -2 });

            migrationBuilder.DeleteData(
                table: "PostLikes",
                keyColumns: new[] { "PostId", "UserId" },
                keyValues: new object[] { 1, -1 });

            migrationBuilder.DeleteData(
                table: "PostLikes",
                keyColumns: new[] { "PostId", "UserId" },
                keyValues: new object[] { 2, -1 });

            migrationBuilder.DropColumn(
                name: "CommentCount",
                table: "Posts");

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 1,
                column: "LikeCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Comments",
                keyColumn: "CommentId",
                keyValue: 2,
                column: "LikeCount",
                value: null);

            migrationBuilder.UpdateData(
                table: "Posts",
                keyColumn: "PostId",
                keyValue: 1,
                column: "LikeCount",
                value: null);
        }
    }
}
