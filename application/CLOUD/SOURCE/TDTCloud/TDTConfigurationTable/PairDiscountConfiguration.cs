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
    public class PairDiscountConfiguration : IEntityTypeConfiguration<PairDiscount>
    {
        /// <summary>
        /// Configuration table PairDiscount
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PairDiscount> builder)
        {
            builder.ToTable("PairDiscounts");
            // Configuration PrimaryKey
            builder.HasKey(x => x.PairDiscountID);
            // Configuration Properties
            builder.Property(x => x.PairDiscountID).IsRequired(true);
            builder.Property(x => x.PairDiscountID).HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.ApplyDate).IsRequired(true);
            builder.Property(x => x.StartDate).IsRequired(true);
            builder.Property(x => x.EndDate).IsRequired(true);
            builder.Property(x => x.PercentReduction).IsRequired(true);
            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(300);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.Expired).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
