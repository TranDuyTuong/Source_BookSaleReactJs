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
    public class DistrictsConfiguration : IEntityTypeConfiguration<Districts>
    {
        /// <summary>
        /// Configuration Table Districts
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Districts> builder)
        {
            builder.ToTable("Districts");
            // Configuration PrimaryKey
            builder.HasKey(x => x.DistrictID);

            // Configuration Properties
            builder.Property(x => x.DistrictID).IsRequired(true);
            builder.Property(x => x.DistrictID).HasMaxLength(50);
            builder.Property(x => x.DistrictID).HasColumnType("varchar");

            builder.Property(x => x.CityID).IsRequired(true);

            builder.Property(x => x.Identifier).IsRequired(true);
            builder.Property(x => x.Identifier).HasMaxLength(100);
            builder.Property(x => x.Identifier).HasColumnType("varchar");

            builder.Property(x => x.DateCreate).IsRequired(true);

            builder.Property(x => x.PriceShip).IsRequired(false);
            builder.Property(x => x.ApplyDate).IsRequired(false);
            builder.Property(x => x.PriceShipNew).IsRequired(false);
            builder.Property(x => x.LasUpdateDate).IsRequired(false);
            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
