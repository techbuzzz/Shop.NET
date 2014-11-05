﻿namespace Shop.Net.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Shop.Net.Data.Contracts;
    using Shop.Net.Data.Migrations;
    using Shop.Net.Model;
    using Shop.Net.Model.Catalog;
    using Shop.Net.Model.Marketing;
    using Shop.Net.Model.Shipping;

    public class ShopDbContext : IdentityDbContext<ApplicationUser>, IDbContext
    {
        public ShopDbContext()
            : base("DefaultConnection", false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ShopDbContext, Configuration>());
        }

        public IDbSet<Country> Countries { get; set; }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Review> Reviews { get; set; }

        public IDbSet<Product> Products { get; set; }

        public IDbSet<Image> Images { get; set; }

        public IDbSet<Review> Manufacturers { get; set; }

        public IDbSet<Comment> Comments { get; set; }

        public static ShopDbContext Create()
        {
            return new ShopDbContext();
        }


        public new IDbSet<T> Set<T>() where T : class
        {
            return base.Set<T>();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}