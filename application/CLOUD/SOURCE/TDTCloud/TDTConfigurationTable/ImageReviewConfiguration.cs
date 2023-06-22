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
    public class ImageReviewConfiguration : IEntityTypeConfiguration<ImageReview>
    {
        /// <summary>
        /// Configuration Table ImageReview
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ImageReview> builder)
        {
            builder.ToTable("ImageReviews");
            // Configruation PrimaryKey
            builder.HasKey(x => x.ImageID);
            // Configuration Properties
            builder.Property(x => x.ImageID).IsRequired(true);
            builder.Property(x => x.ReviewID).IsRequired(true);

            builder.Property(x => x.ImageName).IsRequired(true);
            builder.Property(x => x.ImageName).HasMaxLength(50);
            builder.Property(x => x.ImageName).HasColumnType("varchar");

            builder.Property(x => x.TypeImage).IsRequired(true);
            builder.Property(x => x.TypeImage).HasMaxLength(10);
            builder.Property(x => x.TypeImage).HasColumnType("varchar");

            builder.Property(x => x.Url).IsRequired(false);
            builder.Property(x => x.Url).HasColumnType("varchar");

            builder.Property(x => x.DateCreate).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
