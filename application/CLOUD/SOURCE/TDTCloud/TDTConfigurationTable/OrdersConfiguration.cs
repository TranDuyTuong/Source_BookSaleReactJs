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
    public class OrdersConfiguration : IEntityTypeConfiguration<Orders>
    {
        /// <summary>
        /// Configuration Table Orders
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            // Configuration primaryKey
            builder.HasKey(x => x.OrderID);
            builder.HasKey(x => x.OrderCode);
            // Configuration Properties
            throw new NotImplementedException();
        }
    }
}
