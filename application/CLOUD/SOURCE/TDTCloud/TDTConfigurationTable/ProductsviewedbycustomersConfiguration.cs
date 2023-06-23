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
    public class ProductsviewedbycustomersConfiguration : IEntityTypeConfiguration<Productsviewedbycustomers>
    {
        /// <summary>
        /// Configuration Table Productsviewedbycustomers
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Productsviewedbycustomers> builder)
        {
            builder.ToTable("Productsviewedbycustomers");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ViewerID);
            // Configuration Propeties
            builder.Property(x => x.ViewerID).IsRequired(true);
            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.Property(x => x.ItemCode).IsRequired(true);
            builder.Property(x => x.LastDateViewer).IsRequired(false);
            builder.Property(x => x.ViewerNumber).IsRequired(true);
        }
    }
}
