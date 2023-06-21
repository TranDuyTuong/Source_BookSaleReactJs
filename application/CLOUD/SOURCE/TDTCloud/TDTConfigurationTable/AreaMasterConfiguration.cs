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
    public class AreaMasterConfiguration : IEntityTypeConfiguration<AreaMaster>
    {
        /// <summary>
        /// Configuration Table AreaMaster
        /// </summary>
        public void Configure(EntityTypeBuilder<AreaMaster> builder)
        {
            builder.ToTable("AreaMasters");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CompanyCode);

            // Configuration Properties
            builder.Property(x => x.CompanyCode).IsRequired(true);
            builder.Property(x => x.CompanyCode).HasMaxLength(10);
            builder.Property(x => x.CompanyCode).HasColumnType("Nvarchar(10)");

            builder.Property(x => x.AreaCode).IsRequired(true);
            builder.Property(x => x.AreaCode).HasMaxLength(10);
            builder.Property(x => x.AreaCode).HasColumnType("Nvarchar(10)");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(20);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(20)");
        }
    }
}
