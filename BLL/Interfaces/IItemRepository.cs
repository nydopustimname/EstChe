using DAL.Entities;
using DAL.Interfaces;
using EstChe.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BLL.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
        void Create(Item item);
        void Delete(int id);
        IEnumerable<Item> Find(Func<Item, bool> predicate);
        Item Get(int id);
        IEnumerable<Item> GetAll();
        void Update(Item item);
    }
}
