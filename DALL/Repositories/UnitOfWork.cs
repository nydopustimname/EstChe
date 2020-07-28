using DALL.Interfaces;
using DALL.Context;
using Common.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Threading.Tasks;
using DALL.Identity;

namespace DALL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
       

        private readonly ApContext _context;
        private bool disposed = false;
        public UnitOfWork(ApContext context)
        {
            _context = context;

            Itemss = new ItemRepository(_context);
            Orders = new OrderRepository(_context);
            ClientManager = new ClientManager(_context);
            RoleManager = new AppRoleManager(new RoleStore<AppRole>(_context));
            UserManager = new AppUserManager(new UserStore<User>(_context));
        }

        public UnitOfWork (string connectionString)
        {
            _context = new ApContext(connectionString);
            Itemss = new ItemRepository(_context);
            Orders = new OrderRepository(_context);
            ClientManager = new ClientManager(_context);
            RoleManager = new AppRoleManager(new RoleStore<AppRole>(_context));
            UserManager = new AppUserManager(new UserStore<User>(_context));
        }

        public IItemRepository Itemss { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IClientManager ClientManager { get; private set; }

        public AppRoleManager RoleManager { get; private set; }
        public AppUserManager UserManager { get; private set; }

        // public Microsoft.AspNet.Identity.UserManager<User> UserManager { get; private set; }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    UserManager.Dispose();
                    RoleManager.Dispose();
                    ClientManager.Dispose();
                }
                disposed = true;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }

        public Task SaveAsync()
        {
           return _context.SaveChangesAsync();
        }
    }
}
