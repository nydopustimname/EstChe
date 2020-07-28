using Common.Entities;
using DALL.Interfaces;
using System;
using System.Collections.Generic;

namespace DALL.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
       
        IEnumerable<Order> OrdersCount(int id);
    }
}
