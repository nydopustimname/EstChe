using Common.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace DALL.Identity
{
    public class AppRoleManager : RoleManager<AppRole>
    {
        private RoleStore<IdentityRole> roleStore;

        public AppRoleManager(RoleStore<AppRole> store)
                    : base(store)
        { }

       
    }
    
}
