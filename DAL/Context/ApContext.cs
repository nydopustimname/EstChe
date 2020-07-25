using Common.DTO;
using Common.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;

namespace DAL.Context
{
    public class ApContext : IdentityDbContext<User>
    {
        
        public ApContext(string connectionString) : base(connectionString) { }
        public ApContext() : base("ApContext") { }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<AppRole> Roles { get; set; }

       public static ApContext Create()
        {
            return new ApContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UserProfile>();
            modelBuilder.Conventions.Remove<IncludeMetadataConvention>();
        }
    }

    //public class UserDbInitializer : DropCreateDatabaseAlways<ApContext>
    //{
    //    protected override void Seed(ApContext db)
    //    {
    //        Database.SetInitializer(new UserDbInitializer());
    //        AppRole admin = new AppRole { Name = "admin" };
    //        AppRole user = new AppRole { Name = "user" };
    //        db.Roles.Add(admin);
    //        db.Roles.Add(user);
    //        db.Users.Add(new User
    //        {
    //            Email = "somemail@gmail.com",
    //            Password = "123456",
    //            Role = "admin"
    //        });
    //        base.Seed(db);
    //    }
    //}


    //public class IdentityDbInit : DropCreateDatabaseAlways<ApContext>
    //{
    //    protected override void Seed(ApContext context)
    //    {
    //        PerformInitialSetup(context);
    //        base.Seed(context);
    //    }

    //    private void PerformInitialSetup(ApContext context)
    //    {
    //        context.UserProfiles.Include(i => i.User);
    //    }
    //}

    //public class ItemsDBInitializer : DropCreateDatabaseIfModelChanges<ApContext>
    //{
    //    protected override void Seed(ApContext db)
    //    {
    //        db.Items.Add(new Item { Name = "Coffee", Category = Categories["Phones"], Descr = "tasty", Price = 3 });
    //        db.Items.Add(new Item { Name = "pc", Category = Categories["PCs"], Descr = "usefull", Price = 5000 });
    //        db.Items.Add(new Item { Name = "sql", Category = Categories["Another"], Descr = "uuf too much pein", Price = 200 });
    //        db.Items.Add(new Item { Name = "smh", Category = Categories["Laptops"], Descr = "hzzz", Price = 3 });
    //        db.SaveChanges();
    //    }

    //    private static Dictionary<string, Category> category;

    //    public static Dictionary<string, Category> Categories
    //    {
    //        get
    //        {
    //            if (category == null)
    //            {
    //                var list = new Category[]
    //                {
    //                   new Category{CategoryName="Phones"},
    //                   new Category {CategoryName="PCs"},
    //                   new Category {CategoryName="Home appliances"},
    //                   new Category {CategoryName="Laptops"},
    //                   new Category {CategoryName="Details"},
    //                   new Category {CategoryName="Another"},
    //                };

    //                category = new Dictionary<string, Category>();
    //                foreach (Category c in list)
    //                {
    //                    category.Add(c.CategoryName, c);
    //                }
    //            }
    //            return category;

    //            //если category содержит объекты, возвращаем ее
    //            // если нет, создаем словарь категорий и заполняем переменную чз цикл по словарю
    //        }
    //    }
    //}
}
