using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class ReceiptDetailConfigurations : EntityTypeConfiguration<ReceiptDetail>
    {
        public ReceiptDetailConfigurations()
        {
            ToTable("ReceiptDetails");
            HasKey(x => new { x.ReceiptId, x.MaterialId });
            Property(x => x.ReceiptId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.MaterialId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Quantity)
                .IsRequired();
            Property(x => x.ImportPrice)
                .IsRequired();

            //FK
            HasRequired(s => s.Receipt)
                .WithMany(g => g.ReceiptDetails)
                .HasForeignKey(s => s.ReceiptId);
            HasRequired(s => s.Material)
                .WithMany(g => g.ReceiptDetails)
                .HasForeignKey(s => s.MaterialId);
        }
    }
}
