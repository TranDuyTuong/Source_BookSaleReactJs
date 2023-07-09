using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "EventCodeLimit",
                table: "UserRoles",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                column: "ConcurrencyStamp",
                value: "0fff9499-27a4-4352-be54-4086b4507104");

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "be22bafb-b1fc-4cf1-990d-858cbb417fab", "AQAAAAEAACcQAAAAECZs0g+NR0IvyzHOn+9+1EwMynMQm5AziWLQlmPC3mpoq3uK9syAynPaUh1X4DGSxQ==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "EventCodeLimit",
                value: "101");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EventCodeLimit",
                table: "UserRoles");

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                column: "ConcurrencyStamp",
                value: "828530c4-4412-451e-a8e1-0db5bdd75206");

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "PasswordHash" },
                values: new object[] { "40967f3b-683f-4913-a101-e8125c95cd43", "AQAAAAEAACcQAAAAEPXm1kvn+6t+WVgZp7ueuZ+xMAoK0bB2Gi0PBKybJy06u86z7GX35SjUEQIjdtn1nA==" });
        }
    }
}
