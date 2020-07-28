using Common.Entities;

using System.Collections.Generic;

namespace DAL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        decimal OrderSum(List<Item> items);

    }
}
