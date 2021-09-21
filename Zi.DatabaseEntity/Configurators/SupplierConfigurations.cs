using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class SupplierConfigurations : EntityTypeConfiguration<Supplier>
    {
        public SupplierConfigurations()
        {
            ToTable("Suppliers");
            HasKey(x=>x.SupplierId);
            Property(x => x.SupplierId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Address)
                .IsUnicode(true)
                .HasMaxLength(100);
            Property(x => x.PhoneNumber)
                .IsUnicode(false)
                .HasMaxLength(11);
            Property(x => x.Email)
                .IsUnicode(false)
                .HasMaxLength(50);
        }
    }
}
