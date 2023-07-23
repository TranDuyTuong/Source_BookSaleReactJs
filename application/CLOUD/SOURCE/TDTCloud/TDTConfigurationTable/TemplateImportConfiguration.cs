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
    public class TemplateImportConfiguration : IEntityTypeConfiguration<TemplateImport>
    {
        /// <summary>
        /// Configuration Table Template Import
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<TemplateImport> builder)
        {
            builder.ToTable("TemplateImports");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ID);

            // Configuration Propeties
            builder.Property(x => x.TypeId).IsRequired();
            builder.Property(x => x.TypeId).HasMaxLength(100);

            builder.Property(x => x.Description).IsRequired();
            builder.Property(x => x.Description).HasColumnType("Nvarchar(250)");

            builder.Property(x => x.Content).IsRequired();
            builder.Property(x => x.Content).HasColumnType("Nvarchar(500)");

            builder.Property(x => x.DateCreate).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.IsDelete).IsRequired();
        }
    }
}
