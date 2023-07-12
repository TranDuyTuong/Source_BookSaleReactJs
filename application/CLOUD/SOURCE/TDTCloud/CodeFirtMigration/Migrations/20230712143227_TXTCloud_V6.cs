using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "EmailTemplates",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Description = table.Column<string>(type: "NVARCHAR(150)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActiver = table.Column<bool>(type: "bit", nullable: false),
                    TitleBody = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    ContentBody = table.Column<string>(type: "NVARCHAR(MAX)", nullable: false),
                    Goodbye = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    TemSystem = table.Column<string>(type: "NVARCHAR(500)", nullable: false),
                    PhoneContact = table.Column<string>(type: "NVARCHAR(250)", nullable: false),
                    LastUpdateDate = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmailTemplates", x => x.ID);
                });

            migrationBuilder.InsertData(
                table: "EmailTemplates",
                columns: new[] { "ID", "ContentBody", "DateCreate", "Description", "Goodbye", "IsActiver", "LastUpdateDate", "PhoneContact", "TemSystem", "TitleBody", "TypeCode" },
                values: new object[] { new Guid("c0198715-f805-419d-8249-c7851de721ae"), "Wellcome you become a member, system TDT now you can use this account login into system. If have problem you can contact for Manage", new DateTime(2023, 7, 12, 21, 32, 26, 831, DateTimeKind.Local).AddTicks(117), "Email", "Wish you a good job", false, null, "Phone Number: 0335520146", "TDT SYSTEM WELLCOM", "Dear:", "01" });

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "ec467608-f61b-4a83-9e6c-3fcb3d536795", new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "b3bab24e-09f7-4107-b54c-4ceea84e1924", new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAENUkJdomitKWH/Nx6c9DRvCZDaQZOf8lGWrXePnAdLtNepTHyLdGnd7BPTrZmiHVqA==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 7, 12, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "7/12/2023 12:00:00 AM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmailTemplates");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "0fff9499-27a4-4352-be54-4086b4507104", new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "be22bafb-b1fc-4cf1-990d-858cbb417fab", new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAECZs0g+NR0IvyzHOn+9+1EwMynMQm5AziWLQlmPC3mpoq3uK9syAynPaUh1X4DGSxQ==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 7, 8, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "7/8/2023 12:00:00 AM");
        }
    }
}
