using DALL.Interfaces;
using DALL.Context;
using Common.Entities;

using System.Collections.Generic;

namespace DALL.Repositories
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