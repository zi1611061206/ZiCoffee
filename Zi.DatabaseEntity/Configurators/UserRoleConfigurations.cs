using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class UserRoleConfigurations : EntityTypeConfiguration<UserRole>
    {
        public UserRoleConfigurations()
        {
            ToTable("UserRole");
            HasKey(x => new { x.UserId, x.RoleId });
            Property(x => x.UserId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.RoleId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");

            //FK
            HasRequired(s => s.User)
                .WithMany(g => g.UserRoles)
                .HasForeignKey(s => s.UserId);
            HasRequired(s => s.Role)
                .WithMany(g => g.UserRoles)
                .HasForeignKey(s => s.RoleId);
        }
    }
}
