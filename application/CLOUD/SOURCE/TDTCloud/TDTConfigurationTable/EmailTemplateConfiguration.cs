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
    public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
    {
        /// <summary>
        /// Configuration Table EmailTemplate
        /// </summary>
        public void Configure(EntityTypeBuilder<EmailTemplate> builder)
        {
            builder.ToTable("EmailTemplates");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ID);

            // Configuration Properties
            builder.Property(x => x.TypeCode).IsRequired().HasMaxLength(10);
            builder.Property(x => x.Description).IsRequired().HasColumnType("NVARCHAR(150)");
            builder.Property(x => x.DateCreate).IsRequired();
            builder.Property(x => x.IsActiver).IsRequired();
            builder.Property(x => x.LastUpdateDate).IsRequired(false);
            builder.Property(x => x.TitleBody).IsRequired().HasColumnType("NVARCHAR(250)");
            builder.Property(x => x.ContentBody).IsRequired().HasColumnType("NVARCHAR(MAX)");
            builder.Property(x => x.Goodbye).IsRequired().HasColumnType("NVARCHAR(500)");
            builder.Property(x => x.TemSystem).IsRequired().HasColumnType("NVARCHAR(500)");
            builder.Property(x => x.PhoneContact).IsRequired().HasColumnType("NVARCHAR(250)");
        }
    }
}
