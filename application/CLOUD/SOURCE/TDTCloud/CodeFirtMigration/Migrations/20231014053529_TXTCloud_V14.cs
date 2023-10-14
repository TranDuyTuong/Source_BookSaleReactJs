using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V14 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "IssuingCompanys");

            migrationBuilder.DropTable(
                name: "Jobs");

            migrationBuilder.DropTable(
                name: "PublishingCompanys");

            migrationBuilder.DropColumn(
                name: "IssuingCompanyID",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "PageNumber",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "PublicationDate",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "PublishingCompanyID",
                table: "ItemMasters");

            migrationBuilder.DropColumn(
                name: "JobID",
                table: "CategoryItemMasters");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IssuingCompanyID",
                table: "ItemMasters",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PageNumber",
                table: "ItemMasters",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublicationDate",
                table: "ItemMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "PublishingCompanyID",
                table: "ItemMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "JobID",
                table: "CategoryItemMasters",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateTable(
                name: "IssuingCompanys",
                columns: table => new
                {
                    IssuingCompanyID = table.Column<string>(type: "nvarchar(26)", maxLength: 26, nullable: false),
                    Address = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIncorporation = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(100)", maxLength: 100, nullable: false),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TaxCode = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IssuingCompanys", x => x.IssuingCompanyID);
                });

            migrationBuilder.CreateTable(
                name: "Jobs",
                columns: table => new
                {
                    JobID = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", maxLength: 250, nullable: false),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    LasUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Jobs", x => x.JobID);
                });

            migrationBuilder.CreateTable(
                name: "PublishingCompanys",
                columns: table => new
                {
                    PublishingCompanyID = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Address = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: false),
                    ContentLastUpdateDate = table.Column<string>(type: "Nvarchar(300)", maxLength: 300, nullable: true),
                    DateCraete = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateOfIncorporation = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Description = table.Column<string>(type: "Nvarchar(150)", maxLength: 150, nullable: false),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleteFlag = table.Column<bool>(type: "bit", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UserID = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublishingCompanys", x => x.PublishingCompanyID);
                });

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
    }
}
