using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class ProductConfigurations : EntityTypeConfiguration<Product>
    {
        public ProductConfigurations()
        {
            ToTable("Products");
            HasKey(x => x.ProductId);
            Property(x => x.ProductId)
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
            Property(x => x.Thumnail)
                .IsRequired()
                .HasColumnType("VARBINARY(MAX)");
            Property(x => x.Price)
                .IsRequired();
            Property(x => x.PromotionValue)
                .IsRequired();
            Property(x => x.CategoryId)
                .HasColumnType("UNIQUEIDENTIFIER");

            //FK
            HasRequired(s => s.Category)
                .WithMany(g => g.Products)
                .HasForeignKey(s => s.CategoryId);
        }
    }
}
