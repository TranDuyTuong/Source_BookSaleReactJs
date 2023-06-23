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
    public class SpecialDiscountConfiguration : IEntityTypeConfiguration<SpecialDiscount>
    {
        /// <summary>
        /// Configuration Table SpecialDiscount
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<SpecialDiscount> builder)
        {
            builder.ToTable("SpecialDiscounts");
            // Configuration PrimaryKey
            builder.HasKey(x => x.SpecialDiscountID);
            // Configuration Propeties
            builder.Property(x => x.SpecialDiscountID).IsRequired(true);
            builder.Property(x => x.SpecialDiscountID).HasMaxLength(10);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.ApplyDate).IsRequired(true);
            builder.Property(x => x.StartDate).IsRequired(true);
            builder.Property(x => x.EndDate).IsRequired(true);
            builder.Property(x => x.PercentReduction).IsRequired(true);
            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.Expired).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(300);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
