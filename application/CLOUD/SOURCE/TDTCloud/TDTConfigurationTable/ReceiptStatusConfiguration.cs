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
    public class ReceiptStatusConfiguration : IEntityTypeConfiguration<ReceiptStatus>
    {
        /// <summary>
        /// Configuration Table ReceiptStatus
        /// </summary>
        /// <param name="builder"></param>
        public void Configure(EntityTypeBuilder<ReceiptStatus> builder)
        {
            builder.ToTable("ReceiptStatus");
            // Configuration PrimaryKey
            builder.HasKey(x => x.ReceiptStatusID);
            // Configuration Propeties
            builder.Property(x => x.CompanyCode).IsRequired(true);
            builder.Property(x => x.CompanyCode).HasMaxLength(10);
            builder.Property(x => x.CompanyCode).HasColumnType("Nvarchar(10)");

            builder.Property(x => x.ReceiptStatusID).IsRequired(true);
            builder.Property(x => x.ReceiptStatusID).HasMaxLength(20);

            builder.Property(x => x.CreateDate).IsRequired(true);
            builder.Property(x => x.LasUpdateDate).IsRequired(false);
            builder.Property(x => x.UserID).IsRequired(true);
            builder.Property(x => x.IsDeleteFlag).IsRequired(true);

            builder.Property(x => x.Step1).IsRequired(true);
            builder.Property(x => x.Step1).HasMaxLength(100);
            builder.Property(x => x.Step1).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.Step2).IsRequired(true);
            builder.Property(x => x.Step2).HasMaxLength(100);
            builder.Property(x => x.Step2).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.Step3).IsRequired(true);
            builder.Property(x => x.Step3).HasMaxLength(100);
            builder.Property(x => x.Step3).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.Step4).IsRequired(true);
            builder.Property(x => x.Step4).HasMaxLength(100);
            builder.Property(x => x.Step4).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.Step5).IsRequired(true);
            builder.Property(x => x.Step5).HasMaxLength(100);
            builder.Property(x => x.Step5).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.Step6).IsRequired(true);
            builder.Property(x => x.Step6).HasMaxLength(100);
            builder.Property(x => x.Step6).HasColumnType("Nvarchar(100)");

            builder.Property(x => x.IDStep1).IsRequired(true);
            builder.Property(x => x.IDStep2).IsRequired(true);
            builder.Property(x => x.IDStep3).IsRequired(true);
            builder.Property(x => x.IDStep4).IsRequired(true);
            builder.Property(x => x.IDStep5).IsRequired(true);
            builder.Property(x => x.IDStep6).IsRequired(true);
        }
    }
}
