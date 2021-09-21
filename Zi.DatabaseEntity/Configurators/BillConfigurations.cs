using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity.Configurators
{
    public class BillConfigurations : EntityTypeConfiguration<Bill>
    {
        public BillConfigurations()
        {
            ToTable("Bills");
            HasKey(x => x.BillId);
            Property(x => x.BillId)
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.CreatedDate)
                .IsRequired()
                .HasColumnType("DATETIME2");
            //Property(x => x.Total)
            //    .IsRequired();
            Property(x => x.Vat)
                .IsRequired();
            //Property(x => x.AfterVat)
            //    .IsRequired();
            //Property(x => x.RealPay)
            //    .IsRequired();
            //Property(x => x.Total)
            //    .IsRequired();
            Property(x => x.Status)
                .IsRequired();
            Property(x => x.LastedModify)
                .IsRequired()
                .HasColumnType("DATETIME2");
            Property(x => x.UserId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");
            Property(x => x.TableId)
                .IsRequired()
                .HasColumnType("UNIQUEIDENTIFIER");

            //FK
            HasRequired(s => s.User)
                .WithMany(g => g.Bills)
                .HasForeignKey(s => s.UserId);
            HasRequired(s => s.Table)
                .WithMany(g => g.Bills)
                .HasForeignKey(s => s.TableId);
        }
    }
}
