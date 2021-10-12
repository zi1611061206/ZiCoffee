using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class RoleConfigurations : EntityTypeConfiguration<Role>
    {
        public RoleConfigurations()
        {
            ToTable("Roles");
            HasKey(x => x.RoleId);
            Property(x => x.RoleId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.Name)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.Description)
                .IsUnicode(true)
                .IsMaxLength();
            Property(x => x.AccessLevel)
                .IsRequired();
        }
    }
}
