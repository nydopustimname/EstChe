using DAL.Interfaces;
using EstChe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class ContextUnitOfWork : IUnitOfWork
    {
        private ItemContext db;
        private ItemRepository itemRepository;
        private OrderRepository orderRepository;

        public ContextUnitOfWork(string connectionString)
        {
            db = new ItemContext(connectionString);
        }

        public IRepository<Item> Itemss
        {
            get
            {
                if (itemRepository == null)
                    itemRepository = new ItemRepository(db);
                return itemRepository;
            }
        }

        public IRepository<Order> Orders
        {
            get
            {
                if (orderRepository == null)
                    orderRepository = new OrderRepository(db);
                return orderRepository;
            }
        }

        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
