using Common.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;

using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity.EntityFramework;
using Common.Entities;
using EstChe.Models;

namespace EstChe.Controllers
{
    public class AccountController : Controller
    {

        private IUserService UserService
        {
            get
            {
                return HttpContext.GetOwinContext().GetUserManager<IUserService>();
            }
        }

        private IAuthenticationManager AuthenticationManager => HttpContext.GetOwinContext().Authentication;


        // GET: Account
        public string Index()
        {
            string result = "Вы не авторизованы";
            if (User.Identity.IsAuthenticated)
            {
                result = "Ваш логин: " + User.Identity.Name;
            }
            return result;
        }

        //  [Authorize]
        public ActionResult Login(LoginModel loginModel)
        {
           // ViewBag.returlUrl = returnUrl;
            return View(loginModel);
        }


        [HttpPost]
    
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task< ActionResult> Login(LoginModel loginModel, string returnUrl)
        {
            await SetinitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    Email = loginModel.Email,
                    Password = loginModel.Password
                };

                ClaimsIdentity claims = await UserService.Authenticate(userDTO);
                if (claims==null)
                {
                    ModelState.AddModelError("","Wrong login or password");
                }

                else
                {
                    AuthenticationManager.SignOut();
                    AuthenticationManager.SignIn(new AuthenticationProperties
                    {
                        IsPersistent = true
                    }, claims);
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(loginModel);
        }
        public ActionResult LogOut()
        {
            Session.Clear();
            return RedirectToAction("Login");

        }

        public ActionResult Register(RegisterModel registerModel)
        {
            return View(registerModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<ActionResult> Register (RegisterModel registerModel, string message)
        {
            await SetinitialDataAsync();
            if (ModelState.IsValid)
            {
                UserDTO userDTO = new UserDTO
                {
                    Email = registerModel.Email,
                    Name = registerModel.Name,
                    Address = registerModel.Address,
                    Password = registerModel.Password,
                    Role = "user"
                };
                OperationInfo operationInfo = await UserService.Create(userDTO);
                if (operationInfo.IsSuccess)
                    return View("SuccessRegister");
                else
                {
                    ModelState.AddModelError(operationInfo.Property, operationInfo.Message);
                    return View(operationInfo.Message);
                }

            }
            return View(registerModel);
        }


        private async Task SetinitialDataAsync()
        {
            await UserService.SetInitialData(new UserDTO
            {
                Email = "t.a.dubkovskaya@gmail.com",
                Password = "123465789",
                Name = "FriendlyFire",
                Address = "ул. Спортивная, д.30, кв.75",
                Role = "admin",
            }, new List<string> { "user", "admin" });
        }
    }
}