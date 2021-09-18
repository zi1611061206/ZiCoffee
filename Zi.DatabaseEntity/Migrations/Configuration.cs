namespace Zi.DatabaseEntity.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Data.Entity.Validation;
    using System.Linq;
    using Zi.DatabaseEntity.Seeders;

    internal sealed class Configuration : DbMigrationsConfiguration<Zi.DatabaseEntity.ZiDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ZiDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
            try
            {
                new UserSeeder(context);
                new RoleSeeder(context);
                new UserRoleSeeder(context);

                new AreaSeeder(context);
                new TableSeeder(context);

                new CategorySeeder(context);
                new ProductSeeder(context);

                new SupplierSeeder(context);
                new MaterialSeeder(context);

                new PromotionTypeSeeder(context);
                new PromotionSeeder(context);
                base.Seed(context);
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Value: \"{1}\", Error: \"{2}\"",
                            ve.PropertyName,
                            eve.Entry.CurrentValues.GetValue<object>(ve.PropertyName),
                            ve.ErrorMessage);
                    }
                }
                throw;
            }
        }
    }
}
