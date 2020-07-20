using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using DAL.Entities;
using DAL.Interfaces;
using Microsoft.AspNet.Identity;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using DAL.Repositories;

namespace BLL.Services
{
    public class UserService : IUserService
    {
        UnitOfWork DB { get; set; }

        public UserService (UnitOfWork unitOfWork)
        {
            DB = unitOfWork;
        }

        public async Task<OperationInfo> Create(UserDTO userDto)
        {
            User user = await DB.UserManager.FindByEmailAsync(userDto.Email);

            if (user==null)
            {

                user = new User
                {
                    Email = userDto.Email
                };
                var res = await DB.UserManager.CreateAsync(user, userDto.Password);
                if (res.Errors.Count()>0)
                {
                    return new OperationInfo(false, res.Errors.FirstOrDefault(), "");

                }
                await DB.UserManager.AddToRoleAsync(user.Id, userDto.Role);

                UserProfile userProfile = new UserProfile
                {
                    Id = user.Id,
                    Address = userDto.Address,
                    Name = userDto.Name
                };
                await DB.SaveAsync();
                return new OperationInfo(true, "Successfull registrated", "");

            }
            else
            {
                return new OperationInfo(false, "Login already exists", "Email");
            }
        }

        public async Task<ClaimsIdentity> Authenticate(UserDTO userDto)
        {
            ClaimsIdentity claimsIdentity = null;

            User user = await DB.UserManager.FindAsync(userDto.Email, userDto.Password);
            if (user!=null)
            {
                claimsIdentity = await DB.UserManager.CreateIdentityAsync(user, DefaultAuthenticationTypes.ApplicationCookie);
            }
                return claimsIdentity;

        }

        public async Task SetInitialData(UserDTO adminDto, List<string> roles)
        {
            foreach (var roleName in roles)
            {
                var role = await DB.RoleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    role = new AppRole
                    {
                        Name = roleName
                    };
                    await DB.RoleManager.CreateAsync(role);
                }
            }
                await Create(adminDto);
        }

        public void Dispose()
        {
            DB.Dispose();
        }
    }
}
