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
    public class CustomerWalletConfiguration : IEntityTypeConfiguration<CustomerWallet>
    {
        /// <summary>
        /// Configuration Table CustomerWallet
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CustomerWallet> builder)
        {
            builder.ToTable("CustomerWallets");
            // Configuration PrimaryKey
            builder.HasKey(x => x.WalletID);

            // Configuration Properties
            builder.Property(x => x.WalletID).HasMaxLength(500);
            builder.Property(x => x.WalletID).IsRequired(true);

            builder.Property(x => x.FirstDateTime).IsRequired(true);
            builder.Property(x => x.PointCurent).IsRequired(true);
            builder.Property(x => x.PointMax).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.SatusPointLastUpdate).IsRequired(false);

            builder.Property(x => x.PointPlusLastUpdate).IsRequired(false);
            builder.Property(x => x.PointMinusLastUpdate).IsRequired(false);

            builder.Property(x => x.StatusWallet).IsRequired(true);
            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(500);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(500)");

            builder.Property(x => x.BlockDateTime).IsRequired(false);
        }
    }
}
