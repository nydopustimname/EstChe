using Common.Entities;

using System.Collections.Generic;

namespace DALL.Interfaces
{
    public interface IOrderRepository : IRepository<Order>
    {
        decimal OrderSum(List<Item> items);

    }
}
