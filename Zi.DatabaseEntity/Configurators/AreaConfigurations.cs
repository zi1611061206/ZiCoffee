using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class AreaConfigurations : EntityTypeConfiguration<Area>
    {
        public AreaConfigurations()
        {
            ToTable("Areas");
            HasKey(x => x.AreaId);
            Property(x => x.AreaId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.ParentId)
                .HasColumnType("UNIQUEIDENTIFIER");
        }
    }
}
