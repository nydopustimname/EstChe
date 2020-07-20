using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using BLL.Services;
using Microsoft.AspNet.Identity;
using BLL.Interfaces;
using System;

[assembly: OwinStartup(typeof(EstChe.App_Start.Startup))]

namespace EstChe.App_Start
{
    public class Startup
    {
        IServiceCreator serviceCreator = new ServiceCreator();

        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(CreateUserService);

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Account/Login"),
            });
        }

        private IUserService CreateUserService()
        {
            return serviceCreator.CreateUserService("DefaultConnection");
        }
    }
}