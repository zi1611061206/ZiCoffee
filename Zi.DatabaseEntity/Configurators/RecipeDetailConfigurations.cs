using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class RecipeDetailConfigurations : EntityTypeConfiguration<RecipeDetail>
    {
        public RecipeDetailConfigurations()
        {
            ToTable("RecipeDetails");
            HasKey(x => new { x.RecipeId, x.MaterialId });
            Property(x => x.RecipeId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.MaterialId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Quantitative)
                .IsRequired();

            //FK
            HasRequired(s => s.Recipe)
                .WithMany(g => g.RecipeDetails)
                .HasForeignKey(s => s.RecipeId);
            HasRequired(s => s.Material)
                .WithMany(g => g.RecipeDetails)
                .HasForeignKey(s => s.MaterialId);
        }
    }
}
