using System.Collections.Generic;
using System.Data.Entity;
using Common.Entities;

namespace EstChe.Models
{
    public class ItemContext : DbContext
    {
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }

        static ItemContext()
        {
            Database.SetInitializer<ItemContext>(new ItemsDBInitializer());
        }

        public ItemContext (string connectionString):base(connectionString)
        { }

    }

    public class ItemsDBInitializer : DropCreateDatabaseIfModelChanges<ItemContext>
    {
        protected override void Seed(ItemContext db)
        {
            db.Items.Add(new Item { Name = "Coffee", Category = Categories["Phones"], Descr = "tasty", Price = 3 });
            db.Items.Add(new Item { Name = "pc", Category = Categories["PCs"], Descr = "usefull", Price = 5000 });
            db.Items.Add(new Item { Name = "sql", Category = Categories["Another"], Descr = "uuf too much pein", Price = 200 });
            db.Items.Add(new Item { Name = "smh", Category = Categories["Laptops"], Descr = "hzzz", Price = 3 });
            db.SaveChanges();
        }

        private static Dictionary<string, Category> category;

        public static Dictionary<string, Category> Categories
        {
            get
            {
                if (category == null)
                {
                    var list = new Category[]
                    {
                       new Category{CategoryName="Phones"},
                       new Category {CategoryName="PCs"},
                       new Category {CategoryName="Home appliances"},
                       new Category {CategoryName="Laptops"},
                       new Category {CategoryName="Details"},
                       new Category {CategoryName="Another"},
                    };

                    category = new Dictionary<string, Category>();
                    foreach (Category c in list)
                    {
                        category.Add(c.CategoryName, c);
                    }
                }
                return category;

                //если category содержит объекты, возвращаем ее
                // если нет, создаем словарь категорий и заполняем переменную чз цикл по словарю
            }
        }
    }

}