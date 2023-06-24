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
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        /// <summary>
        /// Configuration Table Job
        /// </summary>
        /// <param name="builder"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            builder.ToTable("Jobs");
            // Configuration PrimaryKey
            builder.HasKey(x => x.JobID);
            // Configuration Propeties
            builder.Property(x => x.JobID).IsRequired(true);
            builder.Property(x => x.JobID).HasMaxLength(10);
            
            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(250)");
            
            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.LasUpdateDate).IsRequired(false);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
