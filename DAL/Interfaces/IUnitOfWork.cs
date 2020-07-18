using EstChe.Models;
using System;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Item> Itemss { get; }
        IRepository<Order> Orders { get; }
        void Save();

        
    }
}
