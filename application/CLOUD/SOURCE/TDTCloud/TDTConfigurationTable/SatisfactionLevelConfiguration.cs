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
    public class SatisfactionLevelConfiguration : IEntityTypeConfiguration<SatisfactionLevel>
    {
        /// <summary>
        /// Configuration Table SatisfactionLevel
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<SatisfactionLevel> builder)
        {
            builder.ToTable("SatisfactionLevels");
            // Configuration PrimaryKey
            builder.HasKey(x => x.SatisfactionLevelID);
            // Configuration Propeties
            builder.Property(x => x.SatisfactionLevelID).IsRequired(true);
            builder.Property(x => x.SatisfactionLevelID).HasMaxLength(10);

            builder.Property(x => x.ReviewID).IsRequired(true);
            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.StartReivew).IsRequired(true);
            builder.Property(x => x.FeelLever).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
