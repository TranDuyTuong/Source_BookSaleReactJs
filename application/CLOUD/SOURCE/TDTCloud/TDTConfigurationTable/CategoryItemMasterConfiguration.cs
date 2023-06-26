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
    public class CategoryItemMasterConfiguration : IEntityTypeConfiguration<CategoryItemMaster>
    {
        /// <summary>
        /// Cinfiguration Table CategoryItemMaster
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CategoryItemMaster> builder)
        {
            builder.ToTable("CategoryItemMasters");
            // Confiuguration PrimaryKey
            builder.HasKey(x => x.CategoryItemMasterID);

            // Configuration Properties
            builder.Property(x => x.CategoryItemMasterID).IsRequired(true);
            builder.Property(x => x.CategoryItemMasterID).HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.DateCreate).IsRequired(true);

            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(300);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.JobID).IsRequired(true);

            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
