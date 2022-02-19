using Microsoft.EntityFrameworkCore.Migrations;

namespace DiscussionForum.Migrations
{
    public partial class AddFirstRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "314b4be6-23e5-4ca8-805d-e11ffab0e884", null, "Admin", "ADMIN" });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dcf431d2-bb40-4009-a37a-7945e221e24c", null, "Member", "MEMBER" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "314b4be6-23e5-4ca8-805d-e11ffab0e884");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dcf431d2-bb40-4009-a37a-7945e221e24c");
        }
    }
}
