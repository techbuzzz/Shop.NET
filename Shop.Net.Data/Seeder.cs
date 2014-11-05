﻿namespace Shop.Net.Data
{
    using System;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Model;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Shipping;
    using Shop.Net.Resources;

    internal class Seeder
    {
        private readonly ShopDbContext context;

        private readonly CountryLoader countryLoader;

        public Seeder(ShopDbContext context, CountryLoader countryLoader)
        {
            this.context = context;
            this.countryLoader = countryLoader;
        }

        public void SeedCountries()
        {
            if (this.context.Countries.Any())
            {
                return;
            }

            var countryList = this.countryLoader.RetrieveCountries();

            foreach (var country in countryList)
            {
                this.context.Countries.Add(new Country { Code = country.Key, Name = country.Value });
            }

            this.context.SaveChanges();
        }

        public void SeedRolesAndUsers()
        {
            var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this.context));
            var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this.context));

            CreateRoleIfItDoesntExist(roleManager, GlobalConstants.AdministratorRole);
            CreateRoleIfItDoesntExist(roleManager, GlobalConstants.EmployeeRole);
            CreateRoleIfItDoesntExist(roleManager, GlobalConstants.CustomerRole);

            var user = new ApplicationUser { UserName = GlobalConstants.DefaultAdminUser };

            if (userManager.FindByName(GlobalConstants.DefaultAdminUser) == null)
            {
                var result = userManager.Create(user, GlobalConstants.DefaultAdminUser);

                if (result.Succeeded)
                {
                    userManager.AddToRole(user.Id, GlobalConstants.AdministratorRole);
                }
            }

            this.context.SaveChanges();
        }

        public void SeedProducts()
        {
            if (this.context.Products.Any())
            {
                return;
            }

            var dslr = new Category { Name = "Dslr", MetaTitle = "This is the Home Category", FriendlyUrl = "dslr" };

            const string Description =
                "The D7000 sits above the D90 in Nikon's current lineup, and as befits its new position in the range, the D7000 combines elements of the D90 with elements of the D300S - Nikon's current APS-C flagship. The most obvious physical clue to its new position is a magnesium alloy body shell, which up to now has been reserved for Nikon's top-end APS-C and full frame cameras";

            this.context.Products.Add(
                new Product
                    {
                        Name = "EOS 5D mk3", 
                        Manufacturer = "Canon", 
                        Category = dslr, 
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        FriendlyUrl = "canon-eos-5d-mk3",
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Canon EOS 5D mk3", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            AltText = "Canon EOS 5D mk3", 
                                            Url =
                                                "http://www.dpreview.com/reviews/CanonEOS5D/Images/frontview.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "EOS 7D mk2", 
                        Manufacturer = "Canon", 
                        Category = dslr, 
                        Price = 2000,
                        FriendlyUrl = "canon-eos-7d-mk2",
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Canon EOS 5D mk3", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            AltText = "Canon EOS 7D mk2", 
                                            Url =
                                                "http://www.dpreview.com/reviews/CanonEOS7D/Images/Front.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "D7000", 
                        Manufacturer = "Nikon", 
                        Category = dslr, 
                        Price = 1500,
                        FriendlyUrl = "nikon-d7000",
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Nikon D7000", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            AltText = "D7000", 
                                            Url = "http://www.kenrockwell.com/nikon/d7000/D3S_2871-1200.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "D5100", 
                        Manufacturer = "Nikon", 
                        Category = dslr, 
                        Price = 700,
                        FriendlyUrl = "nikon-d5100",
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Nikon D5100", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            AltText = "D5100", 
                                            Url =
                                                "http://www.dpreview.com/reviews/NikonD5100/images/Front.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "K-5", 
                        Manufacturer = "Pentax", 
                        Category = dslr, 
                        Price = 1500,
                        FriendlyUrl = "pentax-k5",
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Pentax K-5", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            AltText = "Pentax K-5", 
                                            Url = "http://www.dpreview.com/reviews/pentaxk5/images/intro.jpg"
                                        }
                                }
                    });

            this.context.Products.Add(
                new Product
                    {
                        Name = "K-3", 
                        Manufacturer = "Pentax", 
                        Category = dslr, 
                        Price = 1600,
                        FriendlyUrl = "pentax-k3",
                        CreatedOnUtc = DateTime.UtcNow, 
                        UpdatedOnUtc = DateTime.UtcNow, 
                        Description = Description, 
                        MetaDescription = Description, 
                        MetaTitle = "Pentax K-3", 
                        Images =
                            new[]
                                {
                                    new Image
                                        {
                                            AltText = "Pentax K-3", 
                                            Url =
                                                "http://www.blogcdn.com/www.engadget.com/media/2013/10/pentax-k-3.jpg"
                                        }
                                }
                    });

            this.context.SaveChanges();
        }

        private static void CreateRoleIfItDoesntExist(RoleManager<IdentityRole> roleManager, string role)
        {
            if (!roleManager.RoleExists(role))
            {
                roleManager.Create(new IdentityRole(role));
            }
        }
    }
}