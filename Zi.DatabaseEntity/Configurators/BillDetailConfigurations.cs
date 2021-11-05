using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class BillDetailConfigurations : EntityTypeConfiguration<BillDetail>
    {
        public BillDetailConfigurations()
        {
            ToTable("BillDetails");
            HasKey(x => new { x.BillId, x.ProductId });
            Property(x => x.BillId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.ProductId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Quantity)
                .IsRequired();
            Property(x => x.PromotionValue)
                .IsRequired();
            Property(x => x.IntoMoney)
                .IsRequired();

            //FK
            HasRequired(s => s.Bill)
                .WithMany(g => g.BillDetails)
                .HasForeignKey(s => s.BillId);
            HasRequired(s => s.Product)
                .WithMany(g => g.BillDetails)
                .HasForeignKey(s => s.ProductId);
        }
    }
}
