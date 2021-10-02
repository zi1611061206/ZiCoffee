using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Infrastructure.Annotations;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;
using Zi.DatabaseEntity.Enumerators;

namespace Zi.DatabaseEntity.Configurators
{
    public class UserConfigurations : EntityTypeConfiguration<User>
    {
        public UserConfigurations()
        {
            ToTable("Users");
            HasKey(x=>x.UserId);
            Property(x => x.UserId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.FirstName)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(10);
            Property(x => x.MiddleName)
                .IsUnicode(true)
                .HasMaxLength(30);
            Property(x => x.LastName)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(10);
            Property(x => x.Username)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(10);
            Property(x => x.DisplayName)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(50);
            Property(x => x.PhoneNumber)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(11);
            Property(x => x.Email)
                .IsRequired()
                .IsUnicode(false)
                .HasMaxLength(50);
            Property(x => x.DateOfBirth)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.PasswordHash)
                .IsUnicode(false)
                .HasMaxLength(100);
            Property(x => x.Gender)
                .IsRequired();
            Property(x => x.Avatar)
                .HasColumnType("VARBINARY(MAX)");
            Property(x => x.CitizenId)
                .IsUnicode(false)
                .HasMaxLength(15);
            Property(x => x.Address)
                .IsRequired()
                .IsUnicode(true)
                .HasMaxLength(100);
            Property(x => x.Salt)
                .IsUnicode(false)
                .HasMaxLength(50);
        }
    }
}
