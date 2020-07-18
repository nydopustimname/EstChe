using DAL.Identity;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
   public interface IUnitOfWorkIdentity
    {
        AppUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        AppRoleManager RoleManager { get; }
        Task SaveAsync();
    }
}
