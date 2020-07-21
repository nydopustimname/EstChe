using Common.Entities;

using DAL.Interfaces;
using System.Web.Mvc;

namespace BLL.Interfaces
{
    public interface IItemRepository : IRepository<Item>
    {
    }
}
