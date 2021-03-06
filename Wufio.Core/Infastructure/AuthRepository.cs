﻿using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Wufio.Core.Domain;
using Wufio.Core.Infastructure;
using Wufio.Core.Models;

namespace Wufio.Core
{
    public class AuthRepository : IDisposable
    {
        private WufioDbContext _ctx;

        private UserManager<WufioUser> _userManager;

        public AuthRepository()
        {
            _ctx = new WufioDbContext();
            _userManager = new UserManager<WufioUser>(new UserStore<WufioUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterRescuePrimaryUser(RegisterRescuePrimaryModel userModel)
        {
            // create rescue from info in model
            var rescue = new Rescue
            {
                RescueName = userModel.RescueName,
                NonProfitLink = userModel.NonProfitLink,
                Email = userModel.RescueEmail,
                Address1 = userModel.Address1,
                Address2 = userModel.Address2,
                City = userModel.City,
                State = userModel.State,
                Zipcode = userModel.Zipcode,
                ImageUrl = userModel.RescueImageUrl
            };

            WufioUser user = new WufioUser
            {
                Rescue = rescue,
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                ImageUrl = userModel.ImageUrl
            };

            _ctx.Rescues.Add(rescue);

            var result = await _userManager.CreateAsync(user, userModel.Password);

            _ctx.AddUserRole(user, "Primary");

            _ctx.SaveChanges();

            return result;
        }

        public async Task<IdentityResult> RegisterVolunteerUser(RegisterVolunteerModel userModel, string userId)
        {
            var loggedInUser = _ctx.Users.FirstOrDefault(u => u.Id == userId);

            WufioUser user = new WufioUser
            {
                RescueId = loggedInUser.RescueId,
                UserName = userModel.UserName,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                Email = userModel.Email,
                ImageUrl = userModel.ImageUrl
            };

            _ctx.AddUserRole(user, "Volunteer");

            _ctx.SaveChanges();

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityResult> RegisterAppUser(RegisterAppUserModel userModel)
        {
            WufioUser user = new WufioUser
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                ImageUrl = userModel.ImageUrl
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            _ctx.AddUserRole(user, "AppUser");

            

            return result;
        }

        public async Task<WufioUser> FindUser(string userName, string password)
        {
            WufioUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}