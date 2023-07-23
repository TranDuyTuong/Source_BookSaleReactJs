using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CodeFirtMigration.Migrations
{
    public partial class TXTCloud_V8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TemplateImports",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    TypeId = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "Nvarchar(250)", nullable: false),
                    Content = table.Column<string>(type: "Nvarchar(500)", nullable: false),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LastUpdateDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    HeadquartersLastUpdateDateTime = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDelete = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TemplateImports", x => x.ID);
                });

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

            migrationBuilder.InsertData(
                table: "TemplateImports",
                columns: new[] { "ID", "Content", "DateCreate", "Description", "HeadquartersLastUpdateDateTime", "IsDelete", "LastUpdateDate", "TypeId" },
                values: new object[,]
                {
                    { new Guid("e5d9b502-150f-44e2-8fda-de1a3957a72e"), "ItemCode,CompanyCode,StoreCode,ApplyDate,Description,DescriptionShort,DescriptionLong,PriceOrigin,PercentDiscount,priceSale,QuantityDiscountID,PairDiscountID,SpecialDiscountID,Quantity,Viewer,Buy,CategoryItemMasterID,AuthorID,DateCreate,IssuingCompanyID,PublicationDate,size,PageNumber,PublishingCompanyID,IsSale,LastUpdateDate,Note,HeadquartersLastUpdateDateTime,IsDeleteFlag,UserID,TaxGroupCodeID", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(7566), "ImportBooksKikanSystem.xlsx", null, false, null, "Excelimport_Books" },
                    { new Guid("da2f7e92-722c-43a5-b180-a4b741fd8a04"), "IssuingCompanyID,Description,TaxCode,DateOfIncorporation,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,Address,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8038), "ImportIssuingCompanysCompanyKikanSystem.xlsx", null, false, null, "Excelimport_IssuingCompanys" },
                    { new Guid("56ad3cf4-f6cc-4030-8570-2b3cc5cf2e4d"), "PublishingCompanyID,Description,Address,DateCraete,DateOfIncorporation,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8035), "ImportPublishingCompanyKikanSystem.xlsx", null, false, null, "Excelimport_PublishingCompany" },
                    { new Guid("0c0a1511-2955-4015-9792-0a42e11d011b"), "AuthorID,NameAuthor,Birthday,Hometown,Description,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,TotalBook,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8032), "ImportAuthorKikanSystem.xlsx", null, false, null, "Excelimport_Author" },
                    { new Guid("092d5d54-4499-4f26-8152-7783f0182086"), "DistrictID,CityID,Description,Identifier,DateCreate,PriceShip,ApplyDate,PriceShipNew,LasUpdateDate,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8029), "ImportDistrictKikanSystem.xlsx", null, false, null, "Excelimport_District" },
                    { new Guid("3d8b3620-ec8b-44e7-8cdb-2b688c406ac2"), "CityID,Description,AreaCode,Symbol,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8025), "ImportCityKikanSystem.xlsx", null, false, null, "Excelimport_City" },
                    { new Guid("597fa09b-56b3-40a8-aad4-4cbdd8efe445"), "CategoryItemMasterID,Description,DateCreate,UserID,LastUpdateDate,HeadquartersLastUpdateDateTime,ContentLastUpdateDate,JobID,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8011), "ImportCategoryKikanSystem.xlsx", null, false, null, "Excelimport_Category" },
                    { new Guid("d25b73ee-b319-4565-be89-9bd6120cf759"), "BankID,Description,BankCode,DateCreate,UserID,LasUpdateDate,Content,UrlImageBank,IsDeleteFlag", new DateTime(2023, 7, 22, 11, 45, 44, 720, DateTimeKind.Local).AddTicks(8041), "ImportBankSuportKikanSystem.xlsx", null, false, null, "Excelimport_BankSuport" }
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TemplateImports");

            migrationBuilder.UpdateData(
                table: "EmailTemplates",
                keyColumn: "ID",
                keyValue: new Guid("c0198715-f805-419d-8249-c7851de721ae"),
                column: "DateCreate",
                value: new DateTime(2023, 7, 20, 20, 49, 28, 998, DateTimeKind.Local).AddTicks(457));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Genders",
                keyColumn: "GenderID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0001",
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0002",
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Marriages",
                keyColumn: "MarriageID",
                keyValue: "0003",
                column: "CreateDate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleID",
                keyValue: "0000Admin",
                columns: new[] { "ConcurrencyStamp", "DateCreate" },
                values: new object[] { "5dcc9d72-a331-4f9c-abaf-bfcf63150eae", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local) });

            migrationBuilder.UpdateData(
                table: "Stores",
                keyColumn: "StoreCode",
                keyValue: "0001",
                column: "DateCreate",
                value: new DateTime(2023, 7, 20, 20, 49, 28, 998, DateTimeKind.Local).AddTicks(2823));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0001",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0002",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "TypeAddress",
                keyColumn: "TypeAddressID",
                keyValue: "0003",
                column: "DateTimeCreate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "UserAccounts",
                keyColumn: "UserID",
                keyValue: "05032000",
                columns: new[] { "ConcurrencyStamp", "DateCreate", "PasswordHash" },
                values: new object[] { "d0f29877-e5c5-4854-9ca8-1662019e9b5a", new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local), "AQAAAAEAACcQAAAAEGv+CchgF2oJSJQCKGCP27U6tyx5xh7/GcHJonROD0ZO/Zr5Gr8NtUpyJ/HNFtRCKg==" });

            migrationBuilder.UpdateData(
                table: "UserRoles",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: new DateTime(2023, 7, 20, 0, 0, 0, 0, DateTimeKind.Local));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: "05032000",
                column: "DateCreate",
                value: "7/20/2023 12:00:00 AM");
        }
    }
}
