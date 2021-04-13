namespace SklepUKW.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using SklepUKW.DAL;

    public sealed class Configuration : DbMigrationsConfiguration<SklepUKW.DAL.FilmsContext> //internal
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "SklepUKW.DAL.FilmsContext";
        }

        protected override void Seed(SklepUKW.DAL.FilmsContext context)
        {
            FilmsInitializer.SeedFilmy(context);
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
