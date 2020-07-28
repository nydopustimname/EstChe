using BLL.Interfaces;
using DAL.Repositories;
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

        AppUserManager UserManager { get; }
       // IUserManager UserManager { get; }
        Task SaveAsync();

        void Save();
    }
}
