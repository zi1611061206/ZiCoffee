using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class MaterialConfigurations : EntityTypeConfiguration<Material>
    {
        public MaterialConfigurations()
        {
            ToTable("Materials");
            HasKey(x => x.MaterialId);
            Property(x => x.MaterialId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Unit)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(10);
            Property(x => x.Quantity)
                .IsRequired();
        }
    }
}
