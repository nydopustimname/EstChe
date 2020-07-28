using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DALL.Interfaces
{
    public interface IAppRoleManager : IUnitOfWork
    {
        Task CreateAsync(object role);
        Task FindByNameAsync(string roleName);
    }
}
