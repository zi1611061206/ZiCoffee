using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class EventConfigurations : EntityTypeConfiguration<Event>
    {
        public EventConfigurations()
        {
            ToTable("Events");
            HasKey(x => x.EventId);
            Property(x => x.EventId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Description)
                .IsRequired()
                .IsUnicode(true)
                .IsMaxLength();
        }
    }
}
