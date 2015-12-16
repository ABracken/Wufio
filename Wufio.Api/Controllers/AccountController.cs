using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Wufio.Core;
using Wufio.Core.Infastructure;
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    [RoutePrefix("api/Account")]
    public class AccountController : ApiController
    {
        private AuthRepository _repo = null;

        public AccountController()
        {
            _repo = new AuthRepository();
        }

        // POST api/Account/RegisterAppUser
        [AllowAnonymous]
        [Route("RegisterAppUser")]
        public async Task<IHttpActionResult> RegisterAppUser(RegisterAppUserModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                IdentityResult result = await _repo.RegisterAppUser(userModel);

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        // POST api/Account/RegisterRescuePrimaryUser
        [AllowAnonymous]
        [Route("RegisterRescuePrimaryUser")]
        public async Task<IHttpActionResult> RegisterRescuePrimaryUser(RegisterRescuePrimaryModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                IdentityResult result = await _repo.RegisterRescuePrimaryUser(userModel);

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }
            }
            catch (Exception e)
            {
                throw e;
            }

            return Ok();
        }

        // POST api/Account/RegisterVolunteerUser
        [AllowAnonymous]
        [Route("RegisterVolunteerUser")]
        public async Task<IHttpActionResult> RegisterVolunteerUser(RegisterVolunteerModel userModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                IdentityResult result = await _repo.RegisterVolunteerUser(userModel, User.Identity.GetUserId());

                IHttpActionResult errorResult = GetErrorResult(result);

                if (errorResult != null)
                {
                    return errorResult;
                }

                return Ok();
            }
            catch (Exception e)
            {

                throw;
            }
            
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                _repo.Dispose();
            }

            base.Dispose(disposing);
        }

        private IHttpActionResult GetErrorResult(IdentityResult result)
        {
            if (result == null)
            {
                return InternalServerError();
            }

            if (!result.Succeeded)
            {
                if (result.Errors != null)
                {
                    foreach (string error in result.Errors)
                    {
                        ModelState.AddModelError("", error);
                    }
                }

                if (ModelState.IsValid)
                {
                    // No ModelState errors are available to send, so just return an empty BadRequest.
                    return BadRequest();
                }

                return BadRequest(ModelState);
            }

            return null;
        }
    }
}