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
    public class ItemMasterConfiguration : IEntityTypeConfiguration<ItemMaster>
    {
        /// <summary>
        /// Confiuguraiton Table ItemMaster
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ItemMaster> builder)
        {
            builder.ToTable("ItemMasters");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CompanyCode);
            builder.HasKey(x => x.StoreCode);
            builder.HasKey(x => x.ItemCode);

            // Configuration Properties
            builder.Property(x => x.CompanyCode).IsRequired(true);
            builder.Property(x => x.CompanyCode).HasColumnType("Nvarchar");

            builder.Property(x => x.StoreCode).IsRequired(true);
            builder.Property(x => x.StoreCode).HasColumnType("Nvarchar");

            builder.Property(x => x.ItemCode).IsRequired(true);
            builder.Property(x => x.ItemCode).HasMaxLength(26);
            builder.Property(x => x.ItemCode).HasColumnType("varchar");

            builder.Property(x => x.ApplyDate).IsRequired(false);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(50);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.DescriptionShort).IsRequired(true);
            builder.Property(x => x.DescriptionShort).HasMaxLength(25);
            builder.Property(x => x.DescriptionShort).HasColumnType("Nvarchar");

            builder.Property(x => x.DescriptionLong).IsRequired(true);
            builder.Property(x => x.DescriptionLong).HasMaxLength(100);
            builder.Property(x => x.DescriptionLong).HasColumnType("Nvarchar");

            builder.Property(x => x.PriceOrigin).IsRequired(true);
            builder.Property(x => x.PercentDiscount).IsRequired(true);
            builder.Property(x => x.priceSale).IsRequired(true);

            builder.Property(x => x.QuantityDiscountID).IsRequired(false);
            builder.Property(x => x.QuantityDiscountID).HasColumnType("varchar");

            builder.Property(x => x.PairDiscountID).IsRequired(false);
            builder.Property(x => x.PairDiscountID).HasColumnType("varchar");

            builder.Property(x => x.PercentDiscount).IsRequired(false);
            builder.Property(x => x.Quantity).IsRequired(true);
            builder.Property(x => x.Viewer).IsRequired(true);
            builder.Property(x => x.Buy).IsRequired(true);

            builder.Property(x => x.CategoryItemMasterID).IsRequired(true);
            builder.Property(x => x.AuthorID).IsRequired(true);

            builder.Property(x => x.DateCreate).IsRequired(true);

            builder.Property(x => x.IssuingCompanyID).IsRequired(false);
            builder.Property(x => x.PublicationDate).IsRequired(true);
            builder.Property(x => x.size).IsRequired(true);
            builder.Property(x => x.size).HasMaxLength(100);
            builder.Property(x => x.size).HasColumnType("Nvarchar");

            builder.Property(x => x.PageNumber).IsRequired(true);

            builder.Property(x => x.PublishingCompanyID).IsRequired(true);
            builder.Property(x => x.IsSale).IsRequired(true);

            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.Note).IsRequired(false);

            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
            builder.Property(x => x.TaxGroupCodeID).IsRequired(false);
        }
    }
}
