using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class TableConfigurations : EntityTypeConfiguration<Table>
    {
        public TableConfigurations()
        {
            ToTable("Tables");
            HasKey(x => x.TableId);
            Property(x => x.TableId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Status)
                .IsRequired();

            //FK
            HasRequired(s => s.Area)
                .WithMany(g => g.Tables)
                .HasForeignKey(s => s.AreaId);
        }
    }
}
