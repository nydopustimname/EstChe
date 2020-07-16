//using EstChe.Models;
//using System;
//using System.Collections.Generic;
//using System.Data.Entity;
//using System.Linq;
//using System.Web;

//namespace EstChe.DB
//{
//    public class ShopDbInitializer : DropCreateDatabaseAlways<ItemContext>
//    {
//        protected override void Seed(ItemContext db)
//        {
//            db.Items.Add(new Item { Name = "Coffee", Category = Categories["Food"], Descr = "tasty", Price = 3 });
//            db.Items.Add(new Item { Name = "pc", Category = Categories["Tech"], Descr = "usefull", Price = 5000 });
//            db.Items.Add(new Item { Name = "sql", Category = Categories["Another"], Descr = "uuf too much pein", Price = 200 });
//            db.Items.Add(new Item { Name = "smh", Category = Categories["404"], Descr = "hzzz", Price = 3 });
//            db.SaveChanges();
//        }


//        private static Dictionary<string, Category> category;
//        public static Dictionary<string, Category> Categories
//        {
//            get
//            {
//                if (category == null)
//                {
//                    var list = new Category[]
//                    {
//                       new Category{CategoryName="Food"},
//                       new Category {CategoryName="Tech"},
//                       new Category {CategoryName="Another"},
//                       new Category {CategoryName="404"}
//                    };

//                    category = new Dictionary<string, Category>();
//                    foreach (Category c in list)
//                    {
//                        category.Add(c.CategoryName, c);
//                    }
//                }
//                return category;

//                //если category содержит объекты, возвращаем ее
//                // если нет, создаем словарь категорий и заполняем переменную чз цикл по словарю
//            }
//        }
//    }
//}