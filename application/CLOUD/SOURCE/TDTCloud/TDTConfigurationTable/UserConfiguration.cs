using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TDTSettingTable;

namespace TDTConfigurationTable
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        /// <summary>
        /// Configuration Table User
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");
            // Configuration PrimaryKey
            builder.HasKey(x => x.UserID);
            // Configuration Propeties
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.UserID).HasMaxLength(150);

            builder.Property(x => x.FistName).IsRequired(true);
            builder.Property(x => x.FistName).HasMaxLength(50);
            builder.Property(x => x.FistName).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.LastName).IsRequired(true);
            builder.Property(x => x.LastName).HasMaxLength(50);
            builder.Property(x => x.LastName).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.Birthday).IsRequired(true);
            builder.Property(x => x.GenderID).IsRequired(true);
            builder.Property(x => x.MarriageID).IsRequired(true);
            builder.Property(x => x.CityID).IsRequired(true);
            builder.Property(x => x.DistrictID).IsRequired(true);

            builder.Property(x => x.DetailAddress).IsRequired(true);
            builder.Property(x => x.DetailAddress).HasMaxLength(300);
            builder.Property(x => x.DetailAddress).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.Phone).IsRequired(true);
            builder.Property(x => x.Phone).HasMaxLength(20);

            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(50);
            builder.Property(x => x.Email).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.DateCreate).IsRequired(true);

            builder.Property(x => x.level).IsRequired(true);
            builder.Property(x => x.level).HasMaxLength(150);
            builder.Property(x => x.level).HasColumnType("Nvarchar(150)");

            builder.Property(x => x.AddressCurent).IsRequired(true);
            builder.Property(x => x.AddressCurent).HasMaxLength(300);
            builder.Property(x => x.AddressCurent).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
