using AutoMapper;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using Wufio.Core;
using Wufio.Core.Domain;
using Wufio.Core.Infastructure;
using Wufio.Core.Models;

namespace Wufio.Api.Controllers
{
    public class WufioUsersController : ApiController
    {
        private WufioDbContext db = new WufioDbContext();

        // GET: api/WufioUsers
        public IEnumerable<WufioUserModel> GetIdentityUsers()
        {
            return Mapper.Map<IEnumerable<WufioUserModel>>(db.Users);
        }

        // GET: api/WufioUsers/5
        [ResponseType(typeof(WufioUserModel))]
        public IHttpActionResult GetWufioUser(string id)
        {
            WufioUser dbWufioUser = db.Users.Find(id);
            if (dbWufioUser == null)
            {
                return NotFound();
            }

            WufioUserModel wufioUser = Mapper.Map<WufioUserModel>(dbWufioUser);

            return Ok(wufioUser);
        }

        // PUT: api/WufioUsers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutWufioUser(string id, WufioUserModel wufioUser)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != wufioUser.Id)
            {
                return BadRequest();
            }

            db.Entry(wufioUser).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!WufioUserExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        //// POST: api/WufioUsers
        //[ResponseType(typeof(WufioUserModel))]
        //public IHttpActionResult PostWufioUser(WufioUserModel wufioUser)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.Users.Add(wufioUser);

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateException)
        //    {
        //        if (WufioUserExists(wufioUser.Id))
        //        {
        //            return Conflict();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return CreatedAtRoute("DefaultApi", new { id = wufioUser.Id }, wufioUser);
       // }

        // DELETE: api/WufioUsers/5
        [ResponseType(typeof(WufioUserModel))]
        public IHttpActionResult DeleteWufioUser(string id)
        {
            WufioUser wufioUser = db.Users.Find(id);
            if (wufioUser == null)
            {
                return NotFound();
            }

            db.Users.Remove(wufioUser);
            db.SaveChanges();

            return Ok(wufioUser);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool WufioUserExists(string id)
        {
            return db.Users.Count(e => e.Id == id) > 0;
        }
    }
}