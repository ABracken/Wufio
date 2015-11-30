using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Wufio.Core.Domain;
using Wufio.Core.Models;

namespace Wufio.Core.Controllers
{
    public class AuthRepository : IDisposable
    {
        private AuthContext _ctx;

        private UserManager<WufioUser> _userManager;

        public AuthRepository()
        {
            _ctx = new AuthContext();
            _userManager = new UserManager<WufioUser>(new UserStore<WufioUser>(_ctx));
        }

        public async Task<IdentityResult> RegisterAppUser(RegisterAppUserModel userModel)
        {
            WufioUser user = new WufioUser
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                ImageUrl = userModel.ImageUrl,
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityResult> RegisterRescuePrimaryUser(RegisterRescuePrimaryModel userModel)
        {
            Rescue rescue = new Rescue
            {
                RescueName = userModel.RescueName,
                NonProfitLink = userModel.NonProfitLink,
                Email = userModel.Email,
                Address1 = userModel.Address1,
                Address2 = userModel.Address2,
                City = userModel.City,
                State = userModel.State,
                Zipcode = userModel.Zipcode,
                ImageUrl = userModel.ImageUrl

            };

            WufioUser user = new WufioUser
            {                
                UserName = userModel.UserName,
                Email = userModel.Email,
                FirstName = userModel.FirstName,
                LastName = userModel.LastName,
                ImageUrl = userModel.ImageUrl
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityResult> RegisterVolunteerUser(RegisterVolunteerModel userModel)
        {
            WufioUser user = new WufioUser
            {
                UserName = userModel.UserName,
                Email = userModel.Email,
                ImageUrl = userModel.ImageUrl,
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }

        public async Task<IdentityUser> FindUser(string userName, string password)
        {
            IdentityUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            _ctx.Dispose();
            _userManager.Dispose();

        }
    }
}
