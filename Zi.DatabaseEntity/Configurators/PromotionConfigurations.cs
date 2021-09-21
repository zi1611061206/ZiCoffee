using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class PromotionConfigurations : EntityTypeConfiguration<Promotion>
    {
        public PromotionConfigurations()
        {
            ToTable("Promotions");
            HasKey(x => x.PromotionId);
            Property(x => x.PromotionId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Description)
                .IsUnicode(true)
                .IsMaxLength();
            Property(x => x.IsActived)
                .IsRequired();
            Property(x => x.IsAutoApply)
                .IsRequired();
            Property(x => x.IsPercent)
                .IsRequired();
            Property(x => x.Value)
                .IsRequired();
            Property(x => x.StartTime)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.EndTime)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.MinValue)
                .IsRequired();
            Property(x => x.CodeList)
                .IsUnicode(false)
                .IsMaxLength();
            Property(x => x.PromotionTypeId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");

            //FK
            HasRequired(s => s.PromotionType)
                .WithMany(g => g.Promotions)
                .HasForeignKey(s => s.PromotionTypeId);
        }
    }
}
