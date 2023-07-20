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
    public class StoreConfiguration : IEntityTypeConfiguration<Store>
    {
        /// <summary>
        /// Configuration Table Store
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Store> builder)
        {
            builder.ToTable("Stores");
            // Configuration PrimaryKey
            builder.HasKey(x => x.StoreCode);

            // Configuration Propeties
            builder.Property(x => x.StoreCode).IsRequired(true);
            builder.Property(x => x.StoreCode).HasMaxLength(10);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.Address).IsRequired(true);
            builder.Property(x => x.Address).HasColumnType("Nvarchar(450)");

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
