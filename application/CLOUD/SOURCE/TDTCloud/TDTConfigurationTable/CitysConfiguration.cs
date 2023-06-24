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
    public class CitysConfiguration : IEntityTypeConfiguration<Citys>
    {
        /// <summary>
        /// Configuration Table Citys
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Citys> builder)
        {
            builder.ToTable("Citys");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CityID);

            // Configuration Properties
            builder.Property(x => x.CityID).IsRequired(true);
            builder.Property(x => x.CityID).HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.AreaCode).IsRequired(true);

            builder.Property(x => x.Symbol).IsRequired(true);
            builder.Property(x => x.Symbol).HasMaxLength(5);

            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
