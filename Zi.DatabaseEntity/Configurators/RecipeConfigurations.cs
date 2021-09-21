using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class RecipeConfigurations : EntityTypeConfiguration<Recipe>
    {
        public RecipeConfigurations()
        {
            ToTable("Recipes");
            HasKey(x => x.RecipeId);
            Property(x => x.RecipeId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.ProductId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Guide)
                .IsUnicode(true)
                .IsMaxLength();

            //FK
            HasRequired(s => s.Product)
                .WithMany(g => g.Recipes)
                .HasForeignKey(s => s.ProductId);
        }
    }
}
