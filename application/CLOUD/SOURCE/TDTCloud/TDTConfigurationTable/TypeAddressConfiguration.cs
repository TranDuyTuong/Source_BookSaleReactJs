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
    public class TypeAddressConfiguration : IEntityTypeConfiguration<TypeAddress>
    {
        /// <summary>
        /// Configuration Table TypeAddress
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TypeAddress> builder)
        {
            builder.ToTable("TypeAddress");
            // Configuration PrimaryKey
            builder.HasKey(x => x.TypeAddressID);
            // Configuration Propeties
            builder.Property(x => x.TypeAddressID).IsRequired(true);
            builder.Property(x => x.TypeAddressID).HasMaxLength(10);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.DateTimeCreate).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
