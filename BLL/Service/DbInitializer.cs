using BLL.IServices;
using BLL.Utilities.Extensions;
using DAL;
using DAL.Data;
using DAL.Models;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Service
{
    public class DbInitializer : BaseBL, IDbInitializer
    {
        private readonly CustomUserStore _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public DbInitializer(IUnitOfWork unit, CustomUserStore userManager, RoleManager<IdentityRole> roleManager) : base(unit)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task SeedDatabase()
        {
            await CheckRoles();
            var currUser1 = await _userManager.FindByEmailAsync("johndoe@gmail.com");
            if (currUser1 == null)
            {
                var user = new ApplicationUser()
                {
                    Email = "johndoe@gmail.com",
                    IsDeleted = false,
                    EmailConfirmed = true,
                    UserName = "johndoe@gmail.com",
                    PhoneNumberConfirmed = true,
                    CreatedDate = DateTime.UtcNow,

                };
                
                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, "User");
                var customer = new Customer()
                {
                    CreatedDate = DateTime.UtcNow,
                    Balance = 0,
                    FirstName = "John",
                    LastName = "Doe",
                    UserId = user.Id
                };
                await _uow.CustomerRepo.Create(customer);
            }
            var currUser2 = await _userManager.FindByEmailAsync("janedoe@gmail.com");
            if (currUser2 == null)
            {
                var user = new ApplicationUser()
                {
                    Email = "janedoe@gmail.com",
                    IsDeleted = false,
                    EmailConfirmed = true,
                    UserName = "janedoe@gmail.com",
                    PhoneNumberConfirmed = true,
                    CreatedDate = DateTime.UtcNow,

                };

                await _userManager.CreateAsync(user);
                await _userManager.AddToRoleAsync(user, "User");
                var customer = new Customer()
                {
                    CreatedDate = DateTime.UtcNow,
                    Balance = 0,
                    FirstName = "Jane",
                    LastName = "Doe",
                    UserId = user.Id
                };
                await _uow.CustomerRepo.Create(customer);
            }

        }

        private async Task CheckRoles()
        {
            if (!await _roleManager.RoleExistsAsync(AppSetting.UserRole))
            {
                await _roleManager.CreateAsync(new IdentityRole { Name = AppSetting.UserRole, NormalizedName = AppSetting.UserRole.ToUpper() });
            }
            
        }
    }
}
