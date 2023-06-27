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
                        Id= new Guid("7D10D6E7-FCBD-469A-AAA4-744AB5CE65AA"),
                        UserName = "duytuong0503@gmail.com",
                        Email = "duytuong0503@gmail.com",
                        EmailConfirmed = true,
                        PasswordHash = hasher.HashPassword(null, "Tuong123$")
                    }
                );

            // Configuraion Data Extensions for table UserRole
            modelBuilder.Entity<UserRole>().HasData(
                    new UserRole()
                    {
                        UserID = "05032000",
                        RoleID = "0000Admin",
                        DateCreate = DateTime.Now.Date,
                        Delegator = "05032000",
                        IsDeleteFlag = false
                    }
                );
        }
    }
}
