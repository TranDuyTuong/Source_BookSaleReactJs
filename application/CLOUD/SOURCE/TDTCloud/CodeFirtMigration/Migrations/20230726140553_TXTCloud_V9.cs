using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemMasters",
                table: "ItemMasters");

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "TemplateImports",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "ItemMasters",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemMasters",
                table: "ItemMasters",
                column: "ApplyDate");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 373, DateTimeKind.Local).AddTicks(4706));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "7c007243-1cb1-4c23-bf6f-6cd706b88360", new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 373, DateTimeKind.Local).AddTicks(9447));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4426));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4434));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4417));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4442));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4394));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4458));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4450));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "ItemCode,CompanyCode,StoreCode,ApplyDate,Description,DescriptionShort,DescriptionLong,PriceOrigin,PercentDiscount,priceSale,QuantityDiscountID (NULL),PairDiscountID (NULL),SpecialDiscountID (NULL),Quantity,Viewer (0),Buy (0),CategoryItemMasterID,AuthorID,DateCreate,IssuingCompanyID,PublicationDate,size,PageNumber,PublishingCompanyID,IsSale,LastUpdateDate (NULL),Note,HeadquartersLastUpdateDateTime,IsDeleteFlag,UserID,TaxGroupCodeID (NULL)", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(3472) });

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "4d59fd89-f211-48f4-8a71-62237023dd23", new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEKsWcDM0E7pp4SpyPsB1ySvVualBCgfDyviQFV6RQWx/EM/nm1zdcplA517BHSYoHg==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 7, 26, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "7/26/2023 12:00:00 AM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemMasters",
                table: "ItemMasters");

            migrationBuilder.AlterColumn<string>(
                name: "TypeId",
                table: "TemplateImports",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "ItemMasters",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemMasters",
                table: "ItemMasters",
                column: "ItemCode");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(3346));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "c7d6c923-784c-4ef3-85f0-3eea67c41930", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(5640));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8029));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8032));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8025));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8035));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8011));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8041));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8038));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "ItemCode,CompanyCode,StoreCode,ApplyDate,Description,DescriptionShort,DescriptionLong,PriceOrigin,PercentDiscount,priceSale,QuantityDiscountID,PairDiscountID,SpecialDiscountID,Quantity,Viewer,Buy,CategoryItemMasterID,AuthorID,DateCreate,IssuingCompanyID,PublicationDate,size,PageNumber,PublishingCompanyID,IsSale,LastUpdateDate,Note,HeadquartersLastUpdateDateTime,IsDeleteFlag,UserID,TaxGroupCodeID", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(7566) });

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "cd122e06-31e4-4a80-b686-eab3002f2729", new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEA4Qpz2uVVEjVgIcse+tq7DCXEbDkh15dechplitAlZA7Yr6YDhifEuyL/iI8nFtbg==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 7, 22, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "7/22/2023 12:00:00 AM");
        }
    }
}
