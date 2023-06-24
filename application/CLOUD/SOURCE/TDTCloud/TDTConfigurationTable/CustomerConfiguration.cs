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
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        /// <summary>
        /// Configuration Table Customer
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customers");
            // Configuration PrimaryKey
            builder.HasKey(x => x.CustomerID);

            // Configuration Properties
            builder.Property(x => x.CustomerID).IsRequired(true);

            builder.Property(x => x.FullName).IsRequired(true);
            builder.Property(x => x.FullName).HasMaxLength(50);
            builder.Property(x => x.FullName).HasColumnType("Nvarchar(500)");

            builder.Property(x => x.Birthday).IsRequired(true);

            builder.Property(x => x.Email).IsRequired(true);
            builder.Property(x => x.Email).HasMaxLength(100);

            builder.Property(x => x.Phone).IsRequired(true);
            builder.Property(x => x.Phone).HasMaxLength(20);

            builder.Property(x => x.Password).IsRequired(true);

            builder.Property(x => x.CityID).IsRequired(true);

            builder.Property(x => x.DistrictID).IsRequired(true);

            builder.Property(x => x.GenderID).IsRequired(true);

            builder.Property(x => x.MarriageID).IsRequired(true);

            builder.Property(x => x.DateRegiter).IsRequired(true);

            builder.Property(x => x.Vip).IsRequired(true);

            builder.Property(x => x.StatusAccount).IsRequired(true);

            builder.Property(x => x.JobID).IsRequired(true);

            builder.Property(x => x.LastUpdateDate).IsRequired(false);

            builder.Property(x => x.DescriptionLastUpdateDate).IsRequired(false);
            builder.Property(x => x.DescriptionLastUpdateDate).HasMaxLength(400);
            builder.Property(x => x.DescriptionLastUpdateDate).HasColumnType("Nvarchar(400)");

            builder.Property(x => x.DetailAddress).IsRequired(false);
            builder.Property(x => x.DetailAddress).HasMaxLength(250);
            builder.Property(x => x.DetailAddress).HasColumnType("Nvarchar(250)");
        }
    }
}
