using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class LogConfigurations : EntityTypeConfiguration<Log>
    {
        public LogConfigurations()
        {
            ToTable("Logs");
            HasKey(x => x.LogId);
            Property(x => x.UserId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.EventId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Time)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.Content)
                .IsUnicode(true)
                .IsMaxLength();

            //FK
            HasRequired(s => s.User)
                .WithMany(g => g.Logs)
                .HasForeignKey(s => s.UserId);
            HasRequired(s => s.Event)
                .WithMany(g => g.Logs)
                .HasForeignKey(s => s.EventId);
        }
    }
}
