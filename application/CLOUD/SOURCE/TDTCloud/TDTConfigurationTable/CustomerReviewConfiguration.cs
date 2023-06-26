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
    public class CustomerReviewConfiguration : IEntityTypeConfiguration<CustomerReview>
    {
        /// <summary>
        /// Configuration Table CustomerReview
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<CustomerReview> builder)
        {
            builder.ToTable("CustomerReviews");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ReviewID);

            // Configuration Propeties
            builder.Property(x => x.ReviewID).IsRequired(true);
            builder.Property(x => x.CustomerID).IsRequired(true);
            builder.Property(x => x.ItemCode).IsRequired(true);
            builder.Property(x => x.DateTimeCreate).IsRequired(true);

            builder.Property(x => x.Description).IsRequired(false);
            builder.Property(x => x.Description).HasMaxLength(300);
            builder.Property(x => x.Description).HasColumnType("Nvarchar(300)");

            builder.Property(x => x.StartReview).IsRequired(true);
            builder.Property(x => x.Like).IsRequired(true);

            builder.Property(x => x.SatisfactionLevelID).IsRequired(true);
            builder.Property(x => x.QuantityProductsPurchased).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);
        }
    }
}
