using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class ReceiptConfigurations : EntityTypeConfiguration<Receipt>
    {
        public ReceiptConfigurations()
        {
            ToTable("Receipts");
            HasKey(x => x.ReceiptId);
            Property(x => x.ReceiptId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.SupplierId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");

            //FK
            HasRequired(s => s.Supplier)
                .WithMany(g => g.Receipts)
                .HasForeignKey(s => s.SupplierId);
        }
    }
}
