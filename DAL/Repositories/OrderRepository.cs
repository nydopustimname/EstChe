using DAL.Interfaces;
using EstChe.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
  public  class OrderRepository : IRepository<Order>
    {
        private ItemContext db;

        public OrderRepository(ItemContext context)
        {
            db = context;
        }

        public void Create(Order order)
        {
            db.Orders.Add(order);
        }

        public void Delete(int id)
        {
            Order order = db.Orders.Find(id);
            if (order != null)
                db.Orders.Remove(order); 
        }

        public IEnumerable<Order> Find(Func<Order, bool> predicate)
        {
            return db.Orders.Include(o => o.Item).Where(predicate).ToList();
        }

        public Order Get(int id)
        {
            return db.Orders.Find(id);
        }

        public IEnumerable<Order> GetAll()
        {
            return db.Orders;
        }

        public void Update(Order order)
        {
            db.Entry(order).State = EntityState.Modified;
        }
    }
}
