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
    public class ImageItemMasterConfiguration : IEntityTypeConfiguration<ImageItemMaster>
    {
        /// <summary>
        /// COnfiguration Table ImageItemMaster
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ImageItemMaster> builder)
        {
            builder.ToTable("ImageItemMasters");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ImageItemID);
            // Configuration Propeties
            builder.Property(x => x.ImageItemID).IsRequired(true);
            builder.Property(x => x.ItemCode).IsRequired(true);
            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDefault).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.Url).IsRequired(false);
            builder.Property(x => x.Url).HasColumnType("Nvarchar(MAX)");

            builder.Property(x => x.NameImage).IsRequired(false);
            builder.Property(x => x.NameImage).HasMaxLength(200);

        }
    }
}
