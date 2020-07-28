using BLL.Interfaces;
using DAL.Context;
using Common.Entities;

using System.Collections.Generic;
namespace DAL.Repositories
{
    class ItemRepository : Repository<Item>, IItemRepository
    {

        public ItemRepository(ApContext context) : base(context) { }

        public IEnumerable<Order> OrdersCount(int id)
        {
            return context.Orders;
        }
    }
}