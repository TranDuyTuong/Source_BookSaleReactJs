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
    public class IssuingCompanyConfiguration : IEntityTypeConfiguration<IssuingCompany>
    {
        /// <summary>
        /// Configuration Table IssuingCompany
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<IssuingCompany> builder)
        {
            builder.ToTable("IssuingCompanys");
            // Configuration PrimaryKey
            builder.HasKey(x => x.IssuingCompanyID);
            // Configuration Properties
            builder.Property(x => x.IssuingCompanyID).IsRequired(true);
            builder.Property(x => x.IssuingCompanyID).HasMaxLength(26);
            builder.Property(x => x.IssuingCompanyID).HasColumnType("varchar");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(100);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.TaxCode).IsRequired(true);
            builder.Property(x => x.TaxCode).HasMaxLength(250);
            builder.Property(x => x.TaxCode).HasColumnType("varchar");

            builder.Property(x => x.DateOfIncorporation).IsRequired(true);
            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(300);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar");

            builder.Property(x => x.Address).IsRequired(true);
            builder.Property(x => x.Address).HasMaxLength(250);
            builder.Property(x => x.Address).HasColumnType("Nvarchar");

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
