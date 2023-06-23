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
    public class ReceiptPaymentOnlineConfiguration : IEntityTypeConfiguration<ReceiptPaymentOnline>
    {
        /// <summary>
        /// COnfiguration Table ReceiptPaymentOnline
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ReceiptPaymentOnline> builder)
        {
            builder.ToTable("ReceiptPaymentOnlines");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ReceiptPaymentOnlineID);
            // Configuration Propeties
            builder.Property(x => x.ReceiptPaymentOnlineID).IsRequired(true);
            builder.Property(x => x.OrderCode).IsRequired(true);
            builder.Property(x => x.CustomerID).IsRequired(true);

            builder.Property(x => x.OrderDescription).IsRequired(true);
            builder.Property(x => x.OrderDescription).HasMaxLength(500);
            builder.Property(x => x.OrderDescription).HasColumnType("Nvarchar(500)");

            builder.Property(x => x.TransactionId).IsRequired(true);
            builder.Property(x => x.TransactionId).HasMaxLength(500);

            builder.Property(x => x.OrderId).IsRequired(true);

            builder.Property(x => x.PaymentMethod).IsRequired(true);
            builder.Property(x => x.PaymentMethod).HasMaxLength(200);
            builder.Property(x => x.PaymentMethod).HasColumnType("Nvarchar(200)");

            builder.Property(x => x.IsSuccess).IsRequired(true);

            builder.Property(x => x.token).IsRequired(true);
            builder.Property(x => x.token).HasColumnType("Nvarchar(MAX)");

            builder.Property(x => x.vnPayResponseCode).IsRequired(false);
            builder.Property(x => x.vnPayResponseCode).HasMaxLength(200);

            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.TotalMoney).IsRequired(true);
            builder.Property(x => x.TransactionExecutionTime).IsRequired(true);

            builder.Property(x => x.BankPayment).IsRequired(false);
            builder.Property(x => x.BankPayment).HasMaxLength(200);
            builder.Property(x => x.BankPayment).HasColumnType("Nvarchar(200)");

            builder.Property(x => x.BankCode).IsRequired(false);
            builder.Property(x => x.BankCode).HasMaxLength(150);
            builder.Property(x => x.BankCode).HasColumnType("Nvarchar(150)");

            builder.Property(x => x.TimeCreate).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
