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
    public class HistoryWalletConfiguration : IEntityTypeConfiguration<HistoryWallet>
    {
        /// <summary>
        /// Configuration Table HistoryWallet
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<HistoryWallet> builder)
        {
            builder.ToTable("HistoryWallets");

            // Configuration PrimaryKey
            builder.HasKey(x => x.HistoryWalletID);
            // Configuration Properties
            builder.Property(x => x.HistoryWalletID).IsRequired(true);
            builder.Property(x => x.WalletID).IsRequired(true);
            builder.Property(x => x.CustomerID).IsRequired(true);

            builder.Property(x => x.DateTimeCreate).IsRequired(true);
            builder.Property(x => x.PointsReceived).IsRequired(true);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.IncreaseOrDecrease).IsRequired(true);
            builder.Property(x => x.MethodsReceivingPoints).IsRequired(false);
        }
    }
}
