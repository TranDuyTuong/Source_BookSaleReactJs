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
        }
    }
}
