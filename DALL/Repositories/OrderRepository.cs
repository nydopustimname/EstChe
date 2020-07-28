using DALL.Context;
using DALL.Interfaces;
using Common.Entities;

using System.Collections.Generic;

namespace DALL.Repositories
{
  public  class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(ApContext context) : base(context) { }

        public decimal OrderSum(List<Item> items)
        {
            decimal sum = 0;
            foreach (var i in items)
            {
                sum+= i.Price;
            }
            return sum;
        }
    }
}
