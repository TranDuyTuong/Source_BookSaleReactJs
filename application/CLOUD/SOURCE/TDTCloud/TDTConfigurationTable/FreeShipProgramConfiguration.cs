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
    public class FreeShipProgramConfiguration : IEntityTypeConfiguration<FreeShipProgram>
    {
        /// <summary>
        /// Configuration Table FreeShipProgram
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<FreeShipProgram> builder)
        {
            builder.ToTable("FreeShipPrograms");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CompanyCode);
            builder.HasKey(x => x.FreeShipProgramID);

            // Configuration Propeties
            builder.Property(x => x.CompanyCode).IsRequired(true);
            builder.Property(x => x.CompanyCode).HasMaxLength(10);
            builder.Property(x => x.CompanyCode).HasColumnType("Nvarchar");

            builder.Property(x => x.FreeShipProgramID).IsRequired(true);
            builder.Property(x => x.FreeShipProgramID).HasMaxLength(10);
            builder.Property(x => x.FreeShipProgramID).HasColumnType("varchar");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(200);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.ApplyDate).IsRequired(true);
            builder.Property(x => x.EndApplyDate).IsRequired(true);
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
        }
    }
}
