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
        public void Configure(EntityTypeBuilder<Orders> builder)
        {
            builder.ToTable("Orders");
            // Configuration primaryKey
            builder.HasKey(x => x.OrderID);
            builder.HasKey(x => x.OrderCode);
            // Configuration Properties 

            builder.Property(x => x.OrderID).IsRequired(true);
            builder.Property(x => x.OrderCode).IsRequired(true);

            builder.Property(x => x.CustomerID).IsRequired(true);

            builder.Property(x => x.OrderDate).IsRequired(true);
            builder.Property(x => x.TotalAmountItem).IsRequired(true);

            builder.Property(x => x.FullName).IsRequired(true);
            builder.Property(x => x.FullName).HasMaxLength(50);
            builder.Property(x => x.FullName).HasColumnType("Nvarchar(50)");

            builder.Property(x => x.Phone).IsRequired(true);
            builder.Property(x => x.Phone).HasMaxLength(20);

            builder.Property(x => x.CityID).IsRequired(true);
            builder.Property(x => x.DistrictID).IsRequired(true);
            builder.Property(x => x.CustomerAddressOrdersID).IsRequired(true);
            builder.Property(x => x.TypeAddressID).IsRequired(true);
            builder.Property(x => x.ShipPrice).IsRequired(true);
            builder.Property(x => x.TotalPrice).IsRequired(true);
            builder.Property(x => x.ReceiveApplication).IsRequired(true);
            builder.Property(x => x.ReceiptStatusID).IsRequired(true);
            builder.Property(x => x.PaymentMethodID).IsRequired(true);
            builder.Property(x => x.StatusPayment).IsRequired(true);

            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.EstimatedDeliveryDate).IsRequired(false);
            builder.Property(x => x.IsDelete).IsRequired(true);
            builder.Property(x => x.IsSuccess).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.Note).IsRequired(false);
            builder.Property(x => x.Note).HasMaxLength(500);
            builder.Property(x => x.Note).HasColumnType("Nvarchar(500)");

            builder.Property(x => x.DateTimeCustomerGetItem).IsRequired(false);
            builder.Property(x => x.TotalPoint).IsRequired(true);
            builder.Property(x => x.FreeShipProgram).IsRequired(false);
            builder.Property(x => x.BankID).IsRequired(false);
        }
    }
}
