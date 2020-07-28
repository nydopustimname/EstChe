
using DALL.Identity;
using DALL.Repositories;
using System;
using System.Threading.Tasks;

namespace DALL.Interfaces
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
