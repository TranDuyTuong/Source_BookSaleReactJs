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
    public class CustomerAddressOrdersConfiguration : IEntityTypeConfiguration<CustomerAddressOrders>
    {
        /// <summary>
        /// Configuration Table CustomerAddressOrders
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CustomerAddressOrders> builder)
        {
            builder.ToTable("CustomerAddressOrders");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CustomerAddressOrdersID);

            // Configuration Properties
            builder.Property(x => x.CustomerAddressOrdersID).IsRequired(true);

            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.Property(x => x.CityID).IsRequired(true);
            builder.Property(x => x.DistrictID).IsRequired(true);

            builder.Property(x => x.DetailAddress).IsRequired(true);
            builder.Property(x => x.DetailAddress).HasMaxLength(200);
            builder.Property(x => x.DetailAddress).HasColumnType("Nvarchar");

            builder.Property(x => x.IsAddressDefaul).IsRequired(true);
            builder.Property(x => x.IsAddressHome).IsRequired(true);

            builder.Property(x => x.ShipPrice).IsRequired(true);
            builder.Property(x => x.DateRegiter).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
