using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V15 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                columns: new[] { "DistrictID", "ApplyDate" });

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 461, DateTimeKind.Local).AddTicks(8132));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "569b5ace-094c-4ac0-b05b-6f7c01daa4c0", new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(492));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3051));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3055));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3046));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3058));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3034));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3065));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(3061));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 20, 41, 58, 462, DateTimeKind.Local).AddTicks(2540));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "48436aeb-027a-4bc4-a91e-13acf6e571fc", new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEEi1+IzPtJ62Cod1abTD3Up9OasHd/mm2L8ueUZxYCIUAF6cJIvYcTkpEmiBZh0Qvg==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 10, 16, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "10/16/2023 12:00:00 AM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "ApplyDate");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 941, DateTimeKind.Local).AddTicks(9745));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "7b0b9496-6f69-4b4a-a618-f7f830a7e5cb", new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(3231));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6166));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6169));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6162));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6172));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6149));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6179));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(6175));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 12, 35, 28, 942, DateTimeKind.Local).AddTicks(5659));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "f5a98d3a-dad7-4430-b04b-d2a69c56df6d", new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEPeU42mMgA20CZ4iOXvC2gU8PZp14Gj0x7BSzGkbQpveU5mSoJuEh3pLesdg6+/+nw==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 10, 14, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "10/14/2023 12:00:00 AM");
        }
    }
}
