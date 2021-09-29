using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zi.DatabaseEntity.Configurators;
using Zi.DatabaseEntity.Entities;

namespace Zi.DatabaseEntity
{
    public class ZiDbContext : DbContext
    {
        public ZiDbContext() : base("ZiDbConnectionString")
        {
            Database.SetInitializer(new DropCreateDatabaseIfModelChanges<ZiDbContext>());
            //Database.SetInitializer<ZiDbContext>(new CreateDatabaseIfNotExists<ZiDbContext>());
            //Database.SetInitializer<ZiDbContext>(new DropCreateDatabaseAlways<ZiDbContext>());
            //Database.SetInitializer<ZiDbContext>(new ZiDbInitializer());
        }

        #region Declare entities
        public DbSet<Area> Areas { get; set; }
        public DbSet<Bill> Bills { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Log> Logs { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<PromotionType> PromotionTypes { get; set; }
        public DbSet<Receipt> Receipts { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<Table> Tables { get; set; }
        public DbSet<User> Users { get; set; }

        public DbSet<BillDetail> BillDetails { get; set; }
        public DbSet<DiscountDetail> DiscountDetails { get; set; }
        public DbSet<ReceiptDetail> ReceiptDetails { get; set; }
        public DbSet<RecipeDetail> RecipeDetails { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        #endregion

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            #region Add configurations for entities
            modelBuilder.Configurations.Add(new UserConfigurations());
            modelBuilder.Configurations.Add(new RoleConfigurations());
            modelBuilder.Configurations.Add(new CategoryConfigurations());
            modelBuilder.Configurations.Add(new ProductConfigurations());
            modelBuilder.Configurations.Add(new SupplierConfigurations());
            modelBuilder.Configurations.Add(new MaterialConfigurations());
            modelBuilder.Configurations.Add(new AreaConfigurations());
            modelBuilder.Configurations.Add(new TableConfigurations());
            modelBuilder.Configurations.Add(new EventConfigurations());
            modelBuilder.Configurations.Add(new LogConfigurations());

            modelBuilder.Configurations.Add(new ReceiptConfigurations());
            modelBuilder.Configurations.Add(new ReceiptDetailConfigurations());
            modelBuilder.Configurations.Add(new RecipeConfigurations());
            modelBuilder.Configurations.Add(new RecipeDetailConfigurations());

            modelBuilder.Configurations.Add(new PromotionTypeConfigurations());
            modelBuilder.Configurations.Add(new PromotionConfigurations());
            modelBuilder.Configurations.Add(new BillConfigurations());
            modelBuilder.Configurations.Add(new BillDetailConfigurations());
            modelBuilder.Configurations.Add(new DiscountDetailConfigurations());

            modelBuilder.Configurations.Add(new UserRoleConfigurations());
            #endregion
        }
    }
}
