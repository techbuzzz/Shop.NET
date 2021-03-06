namespace Shop.Net.Data.Migrations
{
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Shop.Net.Resources;

    internal sealed class Configuration : DbMigrationsConfiguration<ShopDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
            this.AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(ShopDbContext context)
        {
            if (context.Products.Any())
            {
                return;
            }

            context.Configuration.AutoDetectChangesEnabled = false;
            var seeder = new Seeder(context, new CountryLoader(), new RandomDataGenerator());
            seeder.SeedRolesAndUsers();
            seeder.SeedCountries();
            seeder.SeedContactInformaton(50);
            seeder.SeedCarrier();
            seeder.SeedCategories(15);
            seeder.SeedProducts(200);
            seeder.SeedOrders(30);
            seeder.SeedReviews(15); // reviews per product
            context.Configuration.AutoDetectChangesEnabled = true;
        }
    }
}