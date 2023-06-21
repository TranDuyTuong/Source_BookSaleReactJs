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
    public class GenderConfiguration : IEntityTypeConfiguration<Gender>
    {
        /// <summary>
        /// Configuration Table Gender
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Gender> builder)
        {
            builder.ToTable("Genders");
            // Configuration PrimaryKey
            builder.HasKey(x => x.GenderID);

            // Configuration Propeties
            builder.Property(x => x.GenderID).IsRequired(true);
            builder.Property(x => x.GenderID).HasMaxLength(10);
            builder.Property(x => x.GenderID).HasColumnType("varchar");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(20);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.LasUpdateDate).IsRequired(false);
            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
