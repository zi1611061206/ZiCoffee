using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class CategoryConfigurations : EntityTypeConfiguration<Category>
    {
        public CategoryConfigurations()
        {
            ToTable("Categories");
            HasKey(x=>x.CategoryId);
            Property(x => x.CategoryId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Description)
                .IsUnicode(true)
                .IsMaxLength();
            Property(x => x.Status)
                .IsRequired();
            Property(x => x.ParentId)
                .HasColumnType("UNIQUEIDENTIFIER");
        }
    }
}
