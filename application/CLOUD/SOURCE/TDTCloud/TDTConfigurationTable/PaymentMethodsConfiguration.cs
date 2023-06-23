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
    public class PaymentMethodsConfiguration : IEntityTypeConfiguration<PaymentMethods>
    {
        /// <summary>
        /// COnfiguration Table PaymentMethods
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PaymentMethods> builder)
        {
            builder.ToTable("PaymentMethods");
            // Configuration PrimaryKey
            builder.HasKey(x => x.PaymentMethodID);
            // Configuration Properties
            builder.Property(x => x.PaymentMethodID).IsRequired(true);
            builder.Property(x => x.PaymentMethodID).HasMaxLength(20);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.LasUpdateDate).IsRequired(false);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
