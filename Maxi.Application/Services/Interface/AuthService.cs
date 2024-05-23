using Maxi.Application.Common;
using Maxi.Application.InputModel;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maxi.Application.Services.Interface
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<ApplicationUser> _usermanager;
        private ApplicationUser ApplicationUser;
        public AuthService(UserManager<ApplicationUser> usermanager)
        {
            _usermanager = usermanager;
            ApplicationUser = new();
        }
        public async Task<IEnumerable<IdentityError>> Register(Register register)
        {
            ApplicationUser.FirstName = register.FirstName;
            ApplicationUser.LastName = register.LastName;
            ApplicationUser.Email = register.Email;
            ApplicationUser.UserName=register.Email;
            
            var result=await _usermanager.CreateAsync(ApplicationUser);
            if (result.Succeeded)
            {
                await _usermanager.AddToRoleAsync(ApplicationUser, "ADMIN");
            }
            return result.Errors;
        }
    }
}
