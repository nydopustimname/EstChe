using BLL.Interfaces;
using DAL.Identity;
using EstChe.Models;
using System;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IItemRepository Itemss { get; }
        IOrderRepository Orders { get; }
        IClientManager ClientManager { get; }
        AppRoleManager RoleManager { get; }
       // IUserManager UserManager { get; }
        Task SaveAsync();

        void Save();
    }
}
