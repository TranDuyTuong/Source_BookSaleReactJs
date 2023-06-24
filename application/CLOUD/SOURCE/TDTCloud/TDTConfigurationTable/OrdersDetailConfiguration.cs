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
    public class OrdersDetailConfiguration : IEntityTypeConfiguration<OrdersDetail>
    {
        /// <summary>
        /// Configuration Table OrdersDetail
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<OrdersDetail> builder)
        {
            builder.ToTable("OrdersDetails");
            // Configuration PrimaryKey
            builder.HasKey(x => x.OrderDetailID);
            // Configuration Propeties
            builder.Property(x => x.OrderDetailID).IsRequired(true);
            builder.Property(x => x.OrderCode).IsRequired(true);

            builder.Property(x => x.ItemCode).IsRequired(true);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(200)");

            builder.Property(x => x.Quatity).IsRequired(true);
            builder.Property(x => x.PriceSale).IsRequired(true);

            builder.Property(x => x.QuantityDiscountID).IsRequired(false);
            builder.Property(x => x.PairDiscountID).IsRequired(false);
            builder.Property(x => x.SpecialDiscountID).IsRequired(false);
            builder.Property(x => x.IssuingCompany).IsRequired(true);
            builder.Property(x => x.PublishingCompany).IsRequired(true);
            builder.Property(x => x.StatusPairDiscount).IsRequired(false);
            builder.Property(x => x.StatusQuatityDiscount).IsRequired(false);
        }
    }
}
