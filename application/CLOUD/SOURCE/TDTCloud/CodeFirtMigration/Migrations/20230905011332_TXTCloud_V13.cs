using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V13 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 342, DateTimeKind.Local).AddTicks(9888));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "bf64243a-8810-4ddb-a24f-d4dafa8b244f", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(1378));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2851));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2856));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2847));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2862));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2842));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2868));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2866));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 8, 13, 32, 343, DateTimeKind.Local).AddTicks(2566));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "867b249c-9f34-44cf-b3ba-fbda22f2088e", new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEDEVSpLdsqf+SxNkhOdIn0oZ7Y65hl5wzs/Rfj4Q+KiW+OzJH7p1NJlBQocRCAuAlw==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 9, 5, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "9/5/2023 12:00:00 AM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(1962));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "96e0b03e-d2e9-432d-b184-4d4dd5dd86c1", new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(4250));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6720));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6724));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6716));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6703));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6733));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6730));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 15, 55, 25, 35, DateTimeKind.Local).AddTicks(6250));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "ddddf7e3-15d3-4652-a712-a88a09a6551b", new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEJandhmnHnnKYzNOquCFWTWjzqYt8ugHYKyEOg98buemF8aooFLYIGp9iOr7wTpJhw==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 9, 4, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "9/4/2023 12:00:00 AM");
        }
    }
}
