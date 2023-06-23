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
    public class PublishingCompanyConfiguration : IEntityTypeConfiguration<PublishingCompany>
    {
        /// <summary>
        /// COnfiguration Table PublishingCompany
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<PublishingCompany> builder)
        {
            builder.ToTable("PublishingCompanys");
            // Configuration PrimaryKey
            builder.HasKey(x => x.PublishingCompanyID);
            // Configuration Propeties
            builder.Property(x => x.PublishingCompanyID).IsRequired(true);
            builder.Property(x => x.PublishingCompanyID).HasMaxLength(50);

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(150);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(150)");

            builder.Property(x => x.Address).IsRequired(true);
            builder.Property(x => x.Address).HasMaxLength(300);
            builder.Property(x => x.Address).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.DateCraete).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(300);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
