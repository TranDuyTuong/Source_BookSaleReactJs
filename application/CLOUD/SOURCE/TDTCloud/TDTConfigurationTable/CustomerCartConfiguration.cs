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
    public class CustomerCartConfiguration : IEntityTypeConfiguration<CustomerCart>
    {
        /// <summary>
        /// Configuration Table CustomerCart
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CustomerCart> builder)
        {
            builder.ToTable("CustomerCarts");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CartID);

            // Configuration Properties
            builder.Property(x => x.CartID).IsRequired(true);

            builder.Property(x => x.ItemCode).IsRequired(true);
            builder.Property(x => x.Quantity).IsRequired(true);
            builder.Property(x => x.DateAddPrtoduct).IsRequired(true);
            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.Property(x => x.StatusProduct).IsRequired(true);
            builder.Property(x => x.PriceSale).IsRequired(true);
            builder.Property(x => x.PriceOrigin).IsRequired(true);
            builder.Property(x => x.PercentReduction).IsRequired(true);
            builder.Property(x => x.TotalPrice).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}
