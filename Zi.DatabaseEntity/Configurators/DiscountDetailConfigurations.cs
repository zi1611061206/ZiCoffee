using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class DiscountDetailConfigurations : EntityTypeConfiguration<DiscountDetail>
    {
        public DiscountDetailConfigurations()
        {
            ToTable("DiscountDetails");
            HasKey(x => new { x.BillId, x.PromotionId });
            Property(x => x.BillId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.PromotionId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");

            //FK
            HasRequired(s => s.Bill)
                .WithMany(g => g.DiscountDetails)
                .HasForeignKey(s => s.BillId);
            HasRequired(s => s.Promotion)
                .WithMany(g => g.DiscountDetails)
                .HasForeignKey(s => s.PromotionId);
        }
    }
}
