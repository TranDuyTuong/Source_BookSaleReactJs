using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace CodeFirtMigration.DataExtestion
{
    public static class ModelBuilderExtensions
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            // Configuration Data Extensions for table Gender
            modelBuilder.Entity<Gender>().HasData(
                    new Gender()
                    {
                        GenderID = "0001",
                        Description = "Nam",
                        CreateDate = DateTime.Now.Date,
                        IsDeleteFlag = false,
                    },
                    new Gender()
                    {
                        GenderID = "0002",
                        Description = "Nữ",
                        CreateDate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    },
                    new Gender()
                    {
                        GenderID = "0003",
                        Description = "Chưa rỏ",
                        CreateDate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    }
                );

            // Configuration Data Extensions for table Marriage
            modelBuilder.Entity<Marriage>().HasData(
                    new Marriage()
                    {
                        MarriageID = "0001",
                        Description = "Độc thân",
                        CreateDate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    },
                    new Marriage()
                    {
                        MarriageID = "0002",
                        Description = "Đã kết hôn",
                        CreateDate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    },
                    new Marriage()
                    {
                        MarriageID = "0003",
                        Description = "Đã ly dị",
                        CreateDate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    }
                );

            // Configuration Data Extensions for table TypeAddress
            modelBuilder.Entity<TypeAddress>().HasData(
                    new TypeAddress()
                    {
                        TypeAddressID = "0001",
                        Description = "Nhà riêng",
                        DateTimeCreate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    },
                    new TypeAddress()
                    {
                        TypeAddressID = "0002",
                        Description = "Văn phòng",
                        DateTimeCreate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    },
                    new TypeAddress()
                    {
                        TypeAddressID = "0003",
                        Description = "Công ty",
                        DateTimeCreate = DateTime.Now.Date,
                        IsDeleteFlag = false
                    }
                );

            // Configuration Data Extensions for table AreaMaster
            modelBuilder.Entity<AreaMaster>().HasData(
                     new AreaMaster()
                     {
                         CompanyCode = "10000005",
                         AreaCode = "10001",
                         Description = "Việt Nam - Tp.Hcm"
                     }
                );

            // Configuration Data Extensions for table Role
            modelBuilder.Entity<Role>().HasData(
                    new Role()
                    {
                        RoleID = "0000Admin",
                        Description = "Administrator",
                        DateCreate = DateTime.Now.Date,
                        UserID = "05032000",
                        IsDeleteFlag = false,
                        Id = new Guid("CDE6664E-F48A-43AF-BBE8-93E90E32C193")
                    }
                );

            // Configuration Data Extensions for table Users
            modelBuilder.Entity<User>().HasData(
                    new User()
                    {
                        UserID = "05032000",
                        FistName = "Trần Duy",
                        LastName = "Tường",
                        Birthday = new DateTime(2000, 03, 05),
                        GenderID = "0001",
                        MarriageID = "0001",
                        DetailAddress = "Khu 13, xã Long Đức, huyện Long Thành, tỉnh Đồng Nai",
                        Phone = "0335520146",
                        Email = "duytuong0503@gmail.com",
                        DateCreate = DateTime.Now.Date.ToString(),
                        level = "Trình độ đại học, chuyên ngành CNTT",
                        AddressCurent = " Đường Bùi Thị Xuân, phường 13, quận Tân Bình, Tp.HCM",
                        IsDeleteFlag = false,
                        CityID = "0001",
                        DistrictID = "0001"
                    }
                );

            // Configuration Data Extensions for table UserAccount
            var hasher = new PasswordHasher<UserAccount>();
            modelBuilder.Entity<UserAccount>().HasData(
                    new UserAccount()
                    {
                        UserID = "05032000",
                        DateCreate = DateTime.Now.Date,
                        RemmenberAccount = false,
                        IsActiver = false,
                        Id = new Guid("7D10D6E7-FCBD-469A-AAA4-744AB5CE65AA"),
                        UserName = "duytuong0503@gmail.com",
                        Email = "duytuong0503@gmail.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Tuong123$"),
                        SecurityStamp = "ORCXRTJM2OU6MN2TASFSQX4R5K3TFVRH"
                    }
                );

            // Configuraion Data Extensions for table UserRole
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole()
                    {
                        UserID = "05032000",
                        RoleID = "0000Admin",
                        EventCodeLimit = "101",
                        DateCreate = DateTime.Now.Date,
                        Delegator = "05032000",
                        IsDeleteFlag = false
                    }
                );

            // Configuration Data Extensions for table EmailTemplate
            modelBuilder.Entity<EmailTemplate>().HasData(
                    new EmailTemplate()
                    {
                        ID = new Guid("C0198715-F805-419D-8249-C7851DE721AE"),
                        TypeCode = "01",
                        Description = "Email",
                        DateCreate = DateTime.Now,
                        IsActiver = false,
                        TitleBody = "Dear:",
                        ContentBody = "Wellcome you become a member, system TDT now you can use this account login into system. If have problem you can contact for Manage",
                        Goodbye = "Wish you a good job",
                        TemSystem = "TDT SYSTEM WELLCOM",
                        PhoneContact = "Phone Number: 0335520146"
                    }
                );

            // Configuration Data Extensions for table Store
            modelBuilder.Entity<Store>().HasData(
                    new Store()
                    {
                        StoreCode = "0001",
                        Description = "Store Tân Bình",
                        DateCreate = DateTime.Now,
                        IsDeleteFlag = false,
                        Address = "Phường 2, Quận Tân Bình, Tp.HCM"
                    }
                );

            // Configuration Data Extensions for table TemplateImport
            modelBuilder.Entity<TemplateImport>().HasData(
                    new TemplateImport()
                    {
                        ID = new Guid("E5D9B502-150F-44E2-8FDA-DE1A3957A72E"),
                        TypeId = "Excelimport_Books",
                        Description = "ImportBooksKikanSystem.xlsx",
                        Content = "ItemCode,CompanyCode,StoreCode,ApplyDate,Description,DescriptionShort,DescriptionLong,PriceOrigin,PercentDiscount,priceSale,QuantityDiscountID (NULL),PairDiscountID (NULL),SpecialDiscountID (NULL),Quantity,Viewer (0),Buy (0),CategoryItemMasterID,AuthorID,DateCreate,IssuingCompanyID,PublicationDate,size,PageNumber,PublishingCompanyID,IsSale,LastUpdateDate (NULL),Note,HeadquartersLastUpdateDateTime,IsDeleteFlag,UserID,TaxGroupCodeID (NULL)",
                        DateCreate = DateTime.Now,
                        IsDelete = false,

                    },
                    new TemplateImport()
                    {
                        ID = new Guid("597FA09B-56B3-40A8-AAD4-4CBDD8EFE445"),
                        TypeId = "Excelimport_Category",
                        Description = "ImportCategoryKikanSystem.xlsx",
                        Content = "CategoryItemMasterID,Description,DateCreate,UserID,LastUpdateDate,HeadquartersLastUpdateDateTime,ContentLastUpdateDate,JobID,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    },
                    new TemplateImport()
                    {
                        ID = new Guid("3D8B3620-EC8B-44E7-8CDB-2B688C406AC2"),
                        TypeId = "Excelimport_City",
                        Description = "ImportCityKikanSystem.xlsx",
                        Content = "CityID,Description,AreaCode,Symbol,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    },
                    new TemplateImport()
                    {
                        ID = new Guid("092D5D54-4499-4F26-8152-7783F0182086"),
                        TypeId = "Excelimport_District",
                        Description = "ImportDistrictKikanSystem.xlsx",
                        Content = "DistrictID,CityID,Description,Identifier,DateCreate,PriceShip,ApplyDate,PriceShipNew,LasUpdateDate,HeadquartersLastUpdateDateTime,UserID,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    },
                    new TemplateImport()
                    {
                        ID = new Guid("0C0A1511-2955-4015-9792-0A42E11D011B"),
                        TypeId = "Excelimport_Author",
                        Description = "ImportAuthorKikanSystem.xlsx",
                        Content = "AuthorID,NameAuthor,Birthday,Hometown,Description,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,TotalBook,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    },
                    new TemplateImport()
                    {
                        ID = new Guid("56AD3CF4-F6CC-4030-8570-2B3CC5CF2E4D"),
                        TypeId = "Excelimport_PublishingCompany",
                        Description = "ImportPublishingCompanyKikanSystem.xlsx",
                        Content = "PublishingCompanyID,Description,Address,DateCraete,DateOfIncorporation,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    },
                    new TemplateImport()
                    {
                        ID = new Guid("DA2F7E92-722C-43A5-B180-A4B741FD8A04"),
                        TypeId = "Excelimport_IssuingCompanys",
                        Description = "ImportIssuingCompanysCompanyKikanSystem.xlsx",
                        Content = "IssuingCompanyID,Description,TaxCode,DateOfIncorporation,DateCreate,UserID,HeadquartersLastUpdateDateTime,LasUpdateDate,ContentLastUpdateDate,Address,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    },
                    new TemplateImport()
                    {
                        ID = new Guid("D25B73EE-B319-4565-BE89-9BD6120CF759"),
                        TypeId = "Excelimport_BankSuport",
                        Description = "ImportBankSuportKikanSystem.xlsx",
                        Content = "BankID,Description,BankCode,DateCreate,UserID,LasUpdateDate,Content,UrlImageBank,IsDeleteFlag",
                        DateCreate = DateTime.Now,
                        IsDelete = false,
                    }

                );
        }
    }
}
