using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class PromotionTypeConfigurations : EntityTypeConfiguration<PromotionType>
    {
        public PromotionTypeConfigurations()
        {
            ToTable("PromotionTypes");
            HasKey(x => x.PromotionTypeId);
            Property(x => x.PromotionTypeId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Description)
                .IsUnicode(true)
                .IsMaxLength();
        }
    }
}
