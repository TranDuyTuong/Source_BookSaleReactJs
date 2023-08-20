using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaMasters",
                table: "AreaMasters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "Districts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "ApplyDate");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaMasters",
                table: "AreaMasters",
                column: "AreaCode");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 8, 20, 16, 20, 29, 293, DateTimeKind.Local).AddTicks(3038));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "f858f147-936c-4dad-a461-9b83c2a24e28", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 8, 20, 16, 20, 29, 293, DateTimeKind.Local).AddTicks(8759));

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("092d5d54-4499-4f26-8152-7783f0182086"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "DistrictID,CityID,Description,Identifier,DateCreate,PriceShip,ApplyDate,PriceShipNew (NULL),LasUpdateDate (NULL),HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4045) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "AuthorID,NameAuthor,Birthday,Hometown,Description,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate (NULL),ContentLastUpdateDate (NULL),TotalBook (Number),IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4052) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "CityID,Description,AreaCode (Number),Symbol,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4037) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "PublishingCompanyID,Description,Address,DateCraete,DateOfIncorporation,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate (NULL),ContentLastUpdateDate (NULL),IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4059) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "CategoryItemMasterID,Description,DateCreate,UserID,LastUpdateDate (NULL),HeadquartersLastUpdateDateTime,ContentLastUpdateDate (NULL),JobID,IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4012) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "BankID,Description,BankCode,DateCreate,UserID,LasUpdateDate (NULL),Content (NULL),UrlImageBank,IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4071) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                columns: new[] { "Content", "DateCreate", "Description" },
                values: new object[] { "IssuingCompanyID,Description,TaxCode,DateOfIncorporation,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate (NULL),ContentLastUpdateDate (NULL),Address,IsDeleteFlag (TRUE/FALSE)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(4065), "ImportIssuingCompanyKikanSystem.xlsx" });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "ItemCode,CompanyCode,StoreCode,ApplyDate,Description,DescriptionShort,DescriptionLong,PriceOrigin,PercentDiscount,priceSale,QuantityDiscountID (NULL),PairDiscountID (NULL),SpecialDiscountID (NULL),Quantity,Viewer (0),Buy (0),CategoryItemMasterID,AuthorID,DateCreate,IssuingCompanyID,PublicationDate,size,PageNumber (Number),PublishingCompanyID,IsSale (TRUE/FALSE),LastUpdateDate (NULL),Note,HeadquartersLastUpdateDateTime,IsDeleteFlag (TRUE/FALSE),UserID,TaxGroupCodeID (NULL)", new DateTime(2023, 8, 20, 16, 20, 29, 294, DateTimeKind.Local).AddTicks(3014) });

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "5a2521d7-561b-4385-9dee-2a5472bf097e", new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAED9mmlLQFpFVmD+aCGUL24FTu0VyhGW8pEMY2UvZV0FPID1J2IrrBWcVN8qA2ZgXBg==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 8, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "8/20/2023 12:00:00 AM");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_Districts",
                table: "Districts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_AreaMasters",
                table: "AreaMasters");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ApplyDate",
                table: "Districts",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Districts",
                table: "Districts",
                column: "DistrictID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_AreaMasters",
                table: "AreaMasters",
                column: "CompanyCode");

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
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "DistrictID,CityID,Description,Identifier,DateCreate,PriceShip,ApplyDate,PriceShipNew,LasUpdateDate,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4426) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "AuthorID,NameAuthor,Birthday,Hometown,Description,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,TotalBook,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4434) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "CityID,Description,AreaCode,Symbol,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4417) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "PublishingCompanyID,Description,Address,DateCraete,DateOfIncorporation,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4442) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "CategoryItemMasterID,Description,DateCreate,UserID,LastUpdateDate,HeadquartersLastUpdateDateTime,ContentLastUpdateDate,JobID,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4394) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"),
                columns: new[] { "Content", "DateCreate" },
                values: new object[] { "BankID,Description,BankCode,DateCreate,UserID,LasUpdateDate,Content,UrlImageBank,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4458) });

            migrationBuilder.UpdateData(
                table: "TemplateImports",
                keyColumn: "ID",
                keyValue: new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"),
                columns: new[] { "Content", "DateCreate", "Description" },
                values: new object[] { "IssuingCompanyID,Description,TaxCode,DateOfIncorporation,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,Address,IsDeleteFlag", new DateTime(2023, 7, 26, 21, 5, 52, 374, DateTimeKind.Local).AddTicks(4450), "ImportIssuingCompanysCompanyKikanSystem.xlsx" });

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
    }
}
