using Common.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DALL.Identity
{
    public class AppUserManager : UserManager<User>
    {
        private UserStore<User> userStore;

        public AppUserManager(IUserStore<User> store)
                : base(store) { }

        
    }
}
