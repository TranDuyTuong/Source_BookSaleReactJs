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
    public class LogConfiguration : IEntityTypeConfiguration<Log>
    {
        /// <summary>
        /// Configuration Table Log
        /// </summary>
        public void Configure(EntityTypeBuilder<Log> builder)
        {
            builder.ToTable("Logs");
            // Configuration PrimaryKey
            builder.HasKey(x => x.Id);

            // Configuration Properties
            builder.Property(x => x.Id).IsRequired(true);
            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.Message).IsRequired(true);
            builder.Property(x => x.Message).HasColumnType("Nvarchar(MAX)");

            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.Status).IsRequired(true);
        }
    }
}
