using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleID", "ConcurrencyStamp", "ContentLastUpdateDate", "DateCreate", "Description", "Id", "IsDeleteFlag", "LastUpdateDate", "Name", "NormalizedName", "UserID" },
                values: new object[] { "0000Admin", "ef69f884-db09-45e7-9570-86e9fecdec10", null, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), "Administrator", new Guid("cde6664e-f48a-43af-bbe8-93e90e32c193"), false, null, null, null, "05032000" });

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.InsertData(
                table: "UserAccounts",
                columns: new[] { "UserID", "AccessFailedCount", "ConcurrencyStamp", "DateCreate", "Email", "EmailConfirmed", "Id", "IsActiver", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "RemmenberAccount", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "05032000", 0, "c01b191a-9747-43b7-95c3-562dc4158559", new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), "duytuong0503@gmail.com", true, new Guid("7d10d6e7-fcbd-469a-aaa4-744ab5ce65aa"), false, false, null, null, null, "AQAAAAEAACcQAAAAECIN5J4riTWLfs8P90DlL0pgjWuDIZNHUUxNK3rLNk+0IInGyYs7Dvrqu8RE8lJlwg==", null, false, false, null, false, "duytuong0503@gmail.com" });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserID", "ContentLastUpdateDtae", "DateCreate", "Delegator", "IsDeleteFlag", "LastUpdateDate", "RoleID" },
                values: new object[] { "05032000", null, new DateTime(2023, 6, 27, 0, 0, 0, 0, DateTimeKind.Local), "05032000", false, null, "0000Admin" });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserID", "AddressCurent", "Birthday", "CityID", "DateCreate", "DetailAddress", "DistrictID", "Email", "FistName", "GenderID", "IsDeleteFlag", "LastName", "LastUpdateDate", "MarriageID", "Phone", "level" },
                values: new object[] { "05032000", " Đường Bùi Thị Xuân, phường 13, quận Tân Bình, Tp.HCM", new DateTime(2000, 3, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), "0001", "6/27/2023 12:00:00 AM", "Khu 13, xã Long Đức, huyện Long Thành, tỉnh Đồng Nai", "0001", "duytuong0503@gmail.com", "Trần Duy", "0001", false, "Tường", null, "0001", "0335520146", "Trình độ đại học, chuyên ngành CNTT" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin");

            migrationBuilder.DeleteData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000");

            migrationBuilder.DeleteData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000");

            migrationBuilder.DeleteData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000");

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 6, 26, 0, 0, 0, 0, DateTimeKind.Local));
        }
    }
}
