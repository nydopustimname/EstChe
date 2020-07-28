using Common.Entities;
using DAL.Context;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;

namespace DAL.Repositories
{
    public class AppRoleManager : RoleManager<IdentityRole>/*, IAppRoleManager*/
    {
        public AppRoleManager(RoleStore<IdentityRole> store)
                    : base(store)
        { }

    }
    
}
