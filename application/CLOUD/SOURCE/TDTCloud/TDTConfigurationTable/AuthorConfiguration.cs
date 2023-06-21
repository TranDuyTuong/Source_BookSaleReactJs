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
    public class AuthorConfiguration : IEntityTypeConfiguration<Author>
    {
        /// <summary>
        /// Configuration Table Author
        /// </summary>
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Authors");
            // Configuration PrimaryKey
            builder.HasKey(x => x.AuthorID);

            // Configuration Properties
            builder.Property(x => x.AuthorID).IsRequired(true);
            builder.Property(x => x.AuthorID).HasMaxLength(26);
            builder.Property(x => x.AuthorID).HasColumnType("varchar");

            builder.Property(x => x.NameAuthor).IsRequired(true);
            builder.Property(x => x.NameAuthor).HasMaxLength(50);
            builder.Property(x => x.NameAuthor).HasColumnType("Nvarchar");

            builder.Property(x => x.Birthday).IsRequired(true);

            builder.Property(x => x.Hometown).IsRequired(true);
            builder.Property(x => x.Hometown).HasMaxLength(100);
            builder.Property(x => x.Hometown).HasColumnType("Nvarchar");

            builder.Property(x => x.Description).IsRequired(true);
            builder.Property(x => x.Description).HasMaxLength(250);
            builder.Property(x => x.Description).HasColumnType("Nvarchar");

            builder.Property(x => x.DateCreate).IsRequired(true);

            builder.Property(x => x.UserID).IsRequired(true);

            builder.Property(x => x.HeadquartersLastUpdateDateTime).IsRequired(false);

            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.ContentLastUpdateDate).IsRequired(false);
            builder.Property(x => x.ContentLastUpdateDate).HasMaxLength(300);
            builder.Property(x => x.ContentLastUpdateDate).HasColumnType("Nvarchar");

            builder.Property(x => x.TotalBook).IsRequired(true);

            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
