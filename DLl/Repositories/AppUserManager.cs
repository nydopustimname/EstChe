using Common.Entities;
using DAL.Context;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class AppUserManager : UserManager<User>
    {
        public AppUserManager(IUserStore<User> store)
                : base(store) { }


    }
}
